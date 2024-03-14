using E_Commerc.Data;

namespace E_Commerc.Service
{
    public interface IOrderService
    {
        Task<OrderProductDTO> AddOrder(OrderProductDTO orderProductDTO);
    }
}
