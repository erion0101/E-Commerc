using E_Commerc.Data;
using E_Commerc.Service;
using Microsoft.AspNetCore.Components;

namespace E_Commerc.Pages
{
    public partial class ViewCartItem : ComponentBase
    {
        [Inject]
        private NavigationManager navigationManager { get; set; }

        public CartItemTshirtDTO cartt { get; set; } = new CartItemTshirtDTO();
        public List<CartItemTshirtDTO> CartItem { get; set; } = new List<CartItemTshirtDTO>();
        [Inject]
        public ICartService cartServices { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CartItem = await cartServices.GetItemAsync();

        }

        public async Task Navigate()
        {
            if (navigationManager != null)
            {
                navigationManager.NavigateTo("/checkout");
            }

        }
        public async Task DeleteCartItem(int cart)
        {
            await cartServices.Delete(cart);
            Console.WriteLine("Produkti është fshirë me sukses!");
            StateHasChanged();
        }
        protected decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var cart in CartItem)
            {
                total += cart.CartTshirtSum * cart.CartTshirtPrice;
            }
            return total;
        }
    }
}
