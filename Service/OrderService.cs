using E_Commerc.Data;

namespace E_Commerc.Service
{
    public class OrderService : IOrderService
    {
        private readonly IApiService _apiService;
        public OrderService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<OrderProductDTO> AddOrder(OrderProductDTO orderProductDTO) =>
            await _apiService.HttpPOST<OrderProductDTO>($"OrderProduct/Add",orderProductDTO);
    }
}
