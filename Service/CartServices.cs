using E_Commerc.Data;

namespace E_Commerc.Service
{
    public class CartServices : ICartService
    {
        private readonly IApiService _apiService;
        public CartServices(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task Delete(int id) =>
         await _apiService.HttpDELETE($"CartItem/Delete/{id}");
        public async Task<CartItemTshirtDTO> Add(CartItemTshirtDTO cartItemTshirtDTO)
        {
            try
            {
                return await _apiService.HttpPOST<CartItemTshirtDTO>($"CartItem/Add", cartItemTshirtDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim në dërgimin e kërkesës: {ex.Message}");
                return null;
            }
        }
     

        public async Task<List<CartItemTshirtDTO>> GetItemAsync() =>
            await _apiService.HttpGET<List<CartItemTshirtDTO>>($"CartItem/GetAll");

        public async Task DeleteALL(CartItemTshirtDTO cartItemTshirtDTO) =>
            await _apiService.HttpPOST<CartItemTshirtDTO>($"CartItem/DeleteALL", cartItemTshirtDTO);
    }
}
