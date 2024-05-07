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

        public async Task<List<SucursalModels>> All()
        {
            try
            {
                var response = await _httpClient.GetAsync("sucursal");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(content))
                    {
                        var data = JsonSerializer.Deserialize<DataResult<SucursalModels>>(content);
                        return data?.result ?? new List<SucursalModels>();
                    }
                    else
                    {
                        Console.WriteLine("La respuesta está vacía.");
                        return new List<SucursalModels>();
                    }
                }
                else
                {
                    Console.WriteLine($"Error en la petición: {response.StatusCode}");
                    return new List<SucursalModels>();
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error al realizar la petición HTTP: {e.Message}");
                return new List<SucursalModels>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return new List<SucursalModels>();


            }


        }
    }
}
