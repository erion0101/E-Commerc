using E_Commerc.Data;
using E_Commerc.Service;
using Microsoft.AspNetCore.Components;

namespace E_Commerc.Pages
{
    public partial class TshirtOption : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        public string selectedImage;
        public string selectedSize = "";
        public string selectedSum = "";
        protected string ButtonText { get; set; } = "Hide Footer";
        protected string CssClass { get; set; } = null;
        [Inject]
        public ICartService cartService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public TshirtDTO TshirtDTO { get; set; } = new TshirtDTO();
        [Inject]
        public ITshirtService tshirtServices { get; set; }
        protected override async Task OnInitializedAsync()
        {
            TshirtDTO = await tshirtServices.GetTshirtById(int.Parse(Id));
            selectedImage = TshirtDTO.ImgUrl;
        }
        public void Navigate()
        {
            NavigationManager.NavigateTo($"/shoes/{TshirtDTO.Id}", forceLoad: true);
        }

        public void ChangeImage(string imageUrl)
        {
            selectedImage = imageUrl;
            StateHasChanged();
        }
        private void UpdateCartShoesSize(ChangeEventArgs e)
        {
            selectedSize = e.Value.ToString();
        }

        private void UpdateCartShoesSum(ChangeEventArgs e)
        {
            selectedSum = e.Value.ToString();
        }
        public async Task Delete()
        {
            await tshirtServices.Delete(TshirtDTO.Id);
        }
        protected async Task AddToCart()
        {
            if (int.TryParse(selectedSize, out int selectedSizeInt) && int.TryParse(selectedSum, out int selectedSumInt))
            {
                CartItemTshirtDTO cart = new CartItemTshirtDTO()
                {
                    CartTshirtName = TshirtDTO.TshirtName,
                    CartTshirtPrice = TshirtDTO.TshirtPrice * selectedSumInt,
                    CartTshirtSum = selectedSumInt,
                    CartTshirtSize = selectedSizeInt,
                    CartImgUrl = TshirtDTO.ImgUrl,
                };
                await cartService.Add(cart);
                Navigate();
            }
            else
            {
                Console.WriteLine("Size and sum is not valid to pars in int");
            }
        }

    }
}
