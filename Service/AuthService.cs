using E_Commerc.Data;

namespace E_Commerc.Service
{
    public class AuthService : IAuthService
    {
        private readonly IApiService _apiService;
        public AuthService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<TokenDTO> Login(string Email, string Password) =>
              await _apiService.HttpPOST<TokenDTO>("Auth/Login", new { Email, Password });
    }
}
