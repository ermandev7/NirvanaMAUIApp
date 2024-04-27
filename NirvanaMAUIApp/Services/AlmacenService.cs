using NirvanaMAUIApp.Generic;
using NirvanaMAUIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NirvanaMAUIApp.Services
{
    public class AlmacenService : IAlmacenService
    {
        const string url = "http://192.168.1.145/CORE/api/almacen";
        //const string url = "http://192.168.1.145:5207/api/almacen";



       // public async Task<List<UnidadMedidaDTO>> AllAsync()
        public async Task<List<AlmacenModels>> All()
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<DataResult<AlmacenModels>>(content);
                    return data.result ?? new List<AlmacenModels>();
                }
                return new List<AlmacenModels>();
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
