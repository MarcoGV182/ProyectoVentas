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
using Irony.Parsing;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResponse> SendAsync<T>(APIRequest apiRequest)
        {
            responseModel = new APIResponse();
            try
            {
                var client = _httpClientFactory.CreateClient("Facturacion");                
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                if (!string.IsNullOrEmpty(apiRequest.Token))
                {
                    message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.Token);
                }

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

                // Deserializar el contenido a APIResponse
                responseModel = JsonConvert.DeserializeObject<APIResponse>(apiContent);

                // Crear una instancia de APIResponse
                responseModel.StatusCode = apiResponse.StatusCode;
                responseModel.isExitoso = apiResponse.IsSuccessStatusCode;

                if (apiResponse.IsSuccessStatusCode)
                {
                    // Si la solicitud fue exitosa, deserializa el contenido a T
                    responseModel.Resultado = JsonConvert.DeserializeObject<T>(responseModel.Resultado.ToString());
                }
                else
                {
                    responseModel.isExitoso = false;
                    responseModel.ErrorMessages.Add(apiResponse.ReasonPhrase);

                    try
                    {
                        responseModel.Resultado = JsonConvert.DeserializeObject<T>(apiContent);
                    }
                    catch (Exception)
                    {
                        // Handle case where the response isn't deserializable into the expected type
                        responseModel.ErrorMessages.Add("Error deserializando la respuesta de la API.");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                responseModel.isExitoso = false;
                responseModel.ErrorMessages = new List<string> { ex.Message };
            }
            catch (Exception ex)
            {
                responseModel.isExitoso = false;
                responseModel.ErrorMessages = new List<string> { "Ocurrió un error inesperado.", ex.Message };
            }

            
            return responseModel;
        }
    }
}
