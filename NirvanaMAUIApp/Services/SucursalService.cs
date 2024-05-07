using NirvanaMAUIApp.Generic;
using NirvanaMAUIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;


namespace NirvanaMAUIApp.Services
{
    public class SucursalService : ISucursalServices
    {
        private readonly HttpClient _httpClient;
        public SucursalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        const string url = "http://192.168.1.145/CORE/api/sucursal";

        public async Task<List<SucursalModels>> All()
        {
            try
            {
                //var response = await _httpClient.GetFromJsonAsync<DataResult<SucursalModels>>("sucursal");

                //var list = response.result;
                //if (list.Count == null)
                //{
                //    return  new List<SucursalModels>();
                //}
                //return list;

                var httpclient = new HttpClient();
                httpclient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImFkbSIsImV4cCI6MTcxNTEyMTc1MSwiaXNzIjoiVHVfSXNzdWVyIiwiYXVkIjoiVHVfQXVkaWVuY2UifQ.HQcTt0DXY-cCoovmK2S39FpL_pH32rm7E-r-SWvb87A");
                var response = await httpclient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<DataResult<SucursalModels>>(content);
                    return data.result ?? new List<SucursalModels>();
                }
                return new List<SucursalModels>();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

       
    }
}
