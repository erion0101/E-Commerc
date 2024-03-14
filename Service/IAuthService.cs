using E_Commerc.Data;

namespace E_Commerc.Service
{
    public interface IAuthService
    {
        Task<TokenDTO> Login(string Email, string Password);
    }
}
