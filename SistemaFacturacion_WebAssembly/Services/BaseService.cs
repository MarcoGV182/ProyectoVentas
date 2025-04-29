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

        public async Task<APIResponse<T>> SendAsync<T>(APIRequest apiRequest) where T : class, new()
        {
            var response = new APIResponse<T>();
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

                response.StatusCode = apiResponse.StatusCode;
                response.isExitoso = apiResponse.IsSuccessStatusCode;

                if (apiResponse.IsSuccessStatusCode)
                {
                    try
                    {
                        response = JsonConvert.DeserializeObject<APIResponse<T>>(apiContent);
                        //response.Resultado = JsonConvert.DeserializeObject<T>(apiContent);
                    }
                    catch (JsonException ex)
                    {
                        response.Resultado = JsonConvert.DeserializeObject<T>(apiContent);
                    }
                }
                else
                {
                    // Manejar errores de la API
                    if (apiResponse.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        response.ErrorMessages = new List<string> { "El token JWT no es válido o ha expirado." };
                    }
                    else if (apiResponse.StatusCode == HttpStatusCode.Forbidden)
                    {
                        response.ErrorMessages = new List<string> { "El token JWT no tiene los permisos necesarios para esta operación." };
                    }
                    else if (apiResponse.StatusCode == HttpStatusCode.BadRequest) // Manejo específico para BadRequest
                    {
                        try
                        {                           
                            // Deserializa directamente como APIResponse para obtener los mensajes de error estructurados
                            var badRequestResponse = JsonConvert.DeserializeObject<APIResponse<T>>(apiContent);

                            if (badRequestResponse != null)
                            {
                                return badRequestResponse;
                            }
                            else
                            {
                                response.ErrorMessages = new List<string> { "Error en la solicitud: Respuesta no válida del servidor" };
                            }
                        }
                        catch (JsonException)
                        {
                            //response.ErrorMessages = new List<string> { "Error al procesar la respuesta de error del servidor" };
                            response.StatusCode = HttpStatusCode.BadRequest; 
                            response.Resultado = JsonConvert.DeserializeObject<T>(apiContent);
                        }
                    }
                    else
                    {
                        response.ErrorMessages = new List<string> { apiResponse.ReasonPhrase ?? "Error desconocido en la solicitud." };

                        try
                        {
                            response.Resultado = JsonConvert.DeserializeObject<T>(apiContent);
                        }
                        catch (JsonException)
                        {
                            response.ErrorMessages.Add("Error al deserializar la respuesta de error.");
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                response.isExitoso = false;
                response.ErrorMessages = new List<string> { $"Acceso no autorizado: {ex.Message}" };
            }
            catch (HttpRequestException ex)
            {
                response.isExitoso = false;
                response.ErrorMessages = new List<string> { $"Error en la solicitud HTTP: {ex.Message}" };
            }
            catch (Exception ex)
            {
                response.isExitoso = false;
                response.ErrorMessages = new List<string> { "Ocurrió un error inesperado.", ex.Message };
            }

            return response;
        }
    }
}
