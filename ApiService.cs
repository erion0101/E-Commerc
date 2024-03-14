using System.Net;
using System.Security.Claims;
using System.Text.Json;

namespace E_Commerc
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7135/api/");
        }
        public async Task HttpDELETE(string url)
        {
            var token = ClaimsPrincipal.Current?.Claims.FirstOrDefault(f => f.Type == "Token");
            if (token != null)
            {
                _httpClient.DefaultRequestHeaders.Add(HttpRequestHeader.Authorization.ToString(),
                    $"Bearer {token.Value}");
            }
            using (var response = await _httpClient.DeleteAsync(url))
            {
                Console.WriteLine($"HTTP Status Code: {response.StatusCode}");
                if (response.IsSuccessStatusCode)
                {
                     await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Përgjigja e API-së: {errorMessage}");
                    throw new HttpRequestException($"Kërkesa dështoi me statusin {response.StatusCode}. Përgjigja e API-së: {errorMessage}");
                }
            }
           // return default;
        }
        public async Task<T> HttpPOST<T>(string url, object postData)
        {
            var token = ClaimsPrincipal.Current?.Claims.FirstOrDefault(f => f.Type == "Token");
            if (token != null)
            {
                _httpClient.DefaultRequestHeaders.Add(HttpRequestHeader.Authorization.ToString(),
                    $"Bearer {token.Value}");
            }

            using (var response = await _httpClient.PostAsJsonAsync(url, postData))
            {
                Console.WriteLine($"HTTP Status Code: {response.StatusCode}");
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        return await response.Content.ReadFromJsonAsync<T>();
                    }
                    catch (JsonException ex)
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();

                        throw new HttpRequestException($"Kërkesa dështoi me statusin {response.StatusCode}. Përgjigja e API-së: {errorMessage}");

                        Console.Error.WriteLine($"Error reading JSON: {ex.Message}");
                        return default;
                    }
                }
            }

            return default;
        }
        
        public async Task<T> HttpGET<T>(string url)
        {
            try
            {
                using (var response = await _httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadFromJsonAsync<T>();
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        throw new HttpRequestException($"Kërkesa dështoi me statusin {response.StatusCode}. Përgjigja e API-së: {errorMessage}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim në kërkesën HTTP GET: {ex.Message}");
                throw;
            }
            return default;
        }

      
    }
}
