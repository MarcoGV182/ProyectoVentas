using Newtonsoft.Json;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Models;
using SistemaFacturacion_WebAssembly.Services.IServices;
using System;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static SistemaFacturacion_Utilidad.DS;
using System.Net.Http;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using System.Net.Http.Headers;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class BaseService : IBaseService
    {        
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest) where T: class, new()
        {   
            try
            {
                var client = _httpClientFactory.CreateClient("Facturacion");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");

                message.RequestUri = new Uri(apiRequest.URL, UriKind.RelativeOrAbsolute);


                if (apiRequest.Datos != null)
                {
                    message.Content = new StringContent(
                        JsonConvert.SerializeObject(apiRequest.Datos),
                        Encoding.UTF8,
                        "application/json");
                }

                switch (apiRequest.Tipo)
                {
                    case APITipo.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case APITipo.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case APITipo.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                
                if (apiResponse.IsSuccessStatusCode)
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<T>(apiContent);
                    }
                    catch (JsonException)
                    {
                        throw new Exception("Error al deserializar la respuesta en el tipo especificado.");
                    }
                }
                else
                {
                    // Manejar errores de la API
                    if (apiResponse.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new UnauthorizedAccessException("El token JWT no es válido o ha expirado.");
                    }
                    else if (apiResponse.StatusCode == HttpStatusCode.Forbidden)
                    {
                        throw new UnauthorizedAccessException("El token JWT no tiene los permisos necesarios para esta operación.");
                    }
                    else if (apiResponse.StatusCode == HttpStatusCode.BadRequest) // Manejo específico para BadRequest
                    {
                        try
                        {
                            // Deserializa directamente como APIResponse para obtener los mensajes de error estructurados
                            var badRequestResponse = JsonConvert.DeserializeObject<T>(apiContent);

                            if (badRequestResponse != null)
                            {
                                /*// Lanza una excepción con los mensajes de error del APIResponse
                                throw new HttpRequestException(
                                    $"{string.Join(", ", badRequestResponse.ErrorMessages)}",
                                    null,
                                    apiResponse.StatusCode
                                );*/
                                return badRequestResponse;
                            }
                            else
                            {
                                throw new HttpRequestException(
                                    "Error en la solicitud: Respuesta no válida del servidor",
                                    null,
                                    apiResponse.StatusCode
                                );
                            }
                        }
                        catch (JsonException)
                        {
                            throw new HttpRequestException(
                                "Error al procesar la respuesta de error del servidor",
                                null,
                                apiResponse.StatusCode
                            );
                        }
                    }
                    else
                    {
                        var errorResponse = new APIResponse<T>
                        {
                            StatusCode = apiResponse.StatusCode,
                            isExitoso = false,
                            ErrorMessages = new List<string> { apiResponse.ReasonPhrase ?? "Error desconocido en la solicitud." }
                        };

                        try
                        {
                            errorResponse.Resultado = JsonConvert.DeserializeObject<T>(apiContent);
                        }
                        catch (JsonException)
                        {
                            errorResponse.ErrorMessages.Add("Error al deserializar la respuesta de error.");
                        }

                        throw new Exception(JsonConvert.SerializeObject(errorResponse));
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new Exception($"Acceso no autorizado: {ex.Message}", ex);
            }            
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error en la solicitud HTTP: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado.", ex);
            }
        }
    }
}
