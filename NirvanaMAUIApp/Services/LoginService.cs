
using NirvanaMAUIApp.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace NirvanaMAUIApp.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;
        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        const string url = "http://192.168.1.145/CORE/api/Auth/login";

        public async Task<bool> Login(LoginRequest loginRequest)
        {
            try
            {
                var httpClient = new HttpClient();
                var json = JsonSerializer.Serialize(loginRequest);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<LoginApiResponse>(responseContent);

                    if (data != null && data.result != null)
                    {
                        var loginResult = data.result;
                        var lg = loginResult.username;
                        var tk = loginResult.tokenId;
                        var tkr = loginResult.refreshToken;
                        var tkac = loginResult.accessToken;
                        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tkr);
                    }

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Manejar la excepción adecuadamente
                return false;
            }
        }

        private void StoreTokens(string accessToken, string refreshToken)
        {
            // Implementar el almacenamiento seguro de los tokens aquí
        }

    }
}
