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

        public async Task<List<AlmacenModels>> All()
        {
            try
            {
                var response = await _httpClient.GetAsync("almacen");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(content))
                    {
                        var data = JsonSerializer.Deserialize<DataResult<AlmacenModels>>(content);
                        return data?.result ?? new List<AlmacenModels>();
                    }
                    else
                    {
                        Console.WriteLine("La respuesta está vacía.");
                        return new List<AlmacenModels>();
                    }
                }
                else
                {
                    Console.WriteLine($"Error en la petición: {response.StatusCode}");
                    return new List<AlmacenModels>();
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error al realizar la petición HTTP: {e.Message}");
                return new List<AlmacenModels>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return new List<AlmacenModels>();
            }
        }


        public async Task<bool> UpdateAlmacen(AlmacenModels almacen)
        {
            var json = JsonSerializer.Serialize(almacen);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"almacen/Modificar/{almacen.almacenId}", content);
            if (!response.IsSuccessStatusCode)
            {
                // Aquí puedes manejar la respuesta si no fue exitosa
                Console.WriteLine($"Error al actualizar: {response.StatusCode}");
            }
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAlmacen(int almacenId)
        {
            var response = await _httpClient.DeleteAsync($"almacen/Eliminar/{almacenId}");
            if (!response.IsSuccessStatusCode)
            {
                // Aquí puedes manejar la respuesta si no fue exitosa
                Console.WriteLine($"Error al eliminar: {response.StatusCode}");
            }
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RegistrarNuevoAlmacen(AlmacenModels almacen)
        {
            var json = JsonSerializer.Serialize(almacen);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("almacen/Registrar", content);
            if (!response.IsSuccessStatusCode)
            {
                // Aquí puedes manejar la respuesta si no fue exitosa
                Console.WriteLine($"Error al registrar: {response.StatusCode}");
            }
            return response.IsSuccessStatusCode;
        }
    }
}
