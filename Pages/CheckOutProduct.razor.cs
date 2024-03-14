using E_Commerc.Data;
using E_Commerc.Service;
using Microsoft.AspNetCore.Components;
using System.Numerics;

namespace E_Commerc.Pages
{
    public partial class CheckOutProduct : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public CartItemTshirtDTO cart { get; set; } = new CartItemTshirtDTO();

        [Inject]
        public OrderProductDTO OrderProductDTO { get; set; } = new OrderProductDTO();

        [Inject]
        public IOrderService orderProduct { get; set; }

        public List<CartItemTshirtDTO> CartItem { get; set; } = new List<CartItemTshirtDTO>();

        [Inject]
        public ICartService cartItemServices { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CartItem = await cartItemServices.GetItemAsync();
        }
        protected async Task DeleteAll(CartItemTshirtDTO cart)
        {
            await cartItemServices.Delete(cart.Id);
        }
        
        protected decimal CalculateTotal()
        {
            return cart.CartTshirtPrice;
            //return CartItem.Sum(cart => cart.TotalPrice);
        }

        public void Navigate()
        {
            NavigationManager.NavigateTo("/checkout", forceLoad: true);
        }

        protected async Task AddToOrderProduct()
        {

            foreach (var cartItem in CartItem)
            {
               
                    OrderProductDTO or = new OrderProductDTO()
                    {
                        FirstName = OrderProductDTO.FirstName,
                        LastName = OrderProductDTO.LastName,
                        Country = OrderProductDTO.Country,
                        StreetAddress = OrderProductDTO.StreetAddress,
                        City = OrderProductDTO.City,
                        State = OrderProductDTO.State,
                        ZipCode = OrderProductDTO.ZipCode,
                        Email = OrderProductDTO.Email,
                        Number = OrderProductDTO.Number,
                        ProductName = cartItem.CartTshirtName,
                        ProductSum = cartItem.CartTshirtSum,
                        ProductPrice = cartItem.CartTshirtPrice,
                    };
                     await orderProduct.AddOrder(or);
                    await cartItemServices.Delete(cartItem.Id);
               


            }
            Navigate();
            
        }
        public static bool IsWholeNumber(object value)
        {
            if (value == null)
                return false;

            return value is byte || value is short || value is int || value is long || value is sbyte ||
                   value is ushort || value is uint || value is ulong || value is decimal || value is BigInteger;
        }
       

        /*  await cartItemServices.Delete(cartItem.Id); */// Thirrja për të fshirë produktin nga karta
    }
}
