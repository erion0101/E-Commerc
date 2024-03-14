using E_Commerc.Data;

namespace E_Commerc.Service
{
    public interface ICartService
    {
        Task<List<CartItemTshirtDTO>> GetItemAsync();
        Task<CartItemTshirtDTO> Add(CartItemTshirtDTO cartItemTshirtDTO);
        Task Delete(int id);
        Task DeleteALL(CartItemTshirtDTO cartItemTshirtDTO);
    }
}
