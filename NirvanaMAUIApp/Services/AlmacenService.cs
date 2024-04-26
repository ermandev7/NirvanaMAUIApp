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
    public class AlmacenService :IAlmacenService
    {
        const string url = "http://192.168.1.145/CORE/api/almacen";
        //const string url = "http://192.168.1.145:5207/api/almacen";
        public async Task<Data> get()
        {
            try
            {
                var httpclient = new HttpClient();
                var response = await httpclient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<Data>(content);
                    return (data);
                }
                return new Data();
            }
            catch (Exception ex)
            {

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
    }
}
