using NirvanaMAUIApp.Generic;
using NirvanaMAUIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace NirvanaMAUIApp.Services
{
    public class AlmacenService : IAlmacenService
    {
        private readonly HttpClient _httpClient;
        public AlmacenService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        const string url = "http://192.168.1.145/CORE/api/almacen";
        //const string url = "http://192.168.1.145:5207/api/almacen";


        //comentario
       // public async Task<List<UnidadMedidaDTO>> AllAsync()
        public async Task<List<AlmacenModels>> All()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<DataResult<AlmacenModels>>("almacen");
                
                    var list = response.result;
                if (list.Count == null)
                {
                    return new List<AlmacenModels>();
                }
                return list;
                // var httpClient = new HttpClient();
                //httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImFkbSIsImV4cCI6MTcxNTEyMTc1MSwiaXNzIjoiVHVfSXNzdWVyIiwiYXVkIjoiVHVfQXVkaWVuY2UifQ.HQcTt0DXY-cCoovmK2S39FpL_pH32rm7E-r-SWvb87A");
                // var response = await httpClient.GetAsync(url);
                // if (response.IsSuccessStatusCode)
                // {
                //     var content = await response.Content.ReadAsStringAsync();
                //     var data = JsonSerializer.Deserialize<DataResult<AlmacenModels>>(content);
                //     return data.result ?? new List<AlmacenModels>();
                // }
                // return new List<AlmacenModels>();
            }
            catch (Exception ex)
            {
                // Considerar manejar la excepción de manera más específica o registrarla
                throw;
            }
        }

        public async Task<bool> UpdateAlmacen(AlmacenModels almacen)
        {
            try
            {
                var httpclient = new HttpClient();
                var json = JsonSerializer.Serialize(almacen);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await httpclient.PutAsync($"{url}/Modificar/{almacen.almacenId}", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw;
            }
        }
        public async Task<bool> DeleteAlmacen(int almacenId)
      
        {
            try
            {
                var httpclient = new HttpClient();

                var response = await httpclient.DeleteAsync($"{url}/Eliminar/{almacenId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw;
            }
        }

        public async Task<bool> RegistrarNuevoAlmacen(AlmacenModels almacen)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImFkbSIsImV4cCI6MTcxNTEyMTc1MSwiaXNzIjoiVHVfSXNzdWVyIiwiYXVkIjoiVHVfQXVkaWVuY2UifQ.HQcTt0DXY-cCoovmK2S39FpL_pH32rm7E-r-SWvb87A") ;
                var json = JsonSerializer.Serialize(almacen);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"{url}/Registrar", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw;
            }
        }
    }
}
