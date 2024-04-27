using NirvanaMAUIApp.Generic;
using NirvanaMAUIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NirvanaMAUIApp.Services
{
    public class SucursalService : ISucursalServices
    {
        const string url = "http://192.168.1.145/CORE/api/sucursal";

        public async Task<List<SucursalModels>> All()
        {
            try
            {
                var httpclient = new HttpClient();
                var response = await httpclient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<DataResult<SucursalModels>>(content);
                    return data.result ?? new List<SucursalModels>();
                }
                return  new List<SucursalModels>();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

       
    }
}
