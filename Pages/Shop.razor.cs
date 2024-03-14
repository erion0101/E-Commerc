using E_Commerc.Data;
using E_Commerc.Service;
using Microsoft.AspNetCore.Components;

namespace E_Commerc.Pages
{
    public partial class Shop : ComponentBase
    {
        [Parameter]
        public string ShoesPrice { get; set; }
        private string OriginalPrice { get; set; }
        public string? search = "";
        public bool isSearching = false;
        private string imageUrl = "";

        private TshirtDTO selecttshirt;
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        public IEnumerable<TshirtDTO>  tshirtDTO { get; set; }
        public List<TshirtDTO> tshirt { get; set; } = new List<TshirtDTO>();
        [Inject]
        public ITshirtService tshirtServices { get; set; }
        protected override async Task OnInitializedAsync()
        {
            tshirt = (await tshirtServices.GetTshirtAsync()).ToList();
            await Serche();

        }
        public async Task Serche()
        {
            isSearching = !string.IsNullOrWhiteSpace(search);

            if (isSearching)
            {
                var searchResults = await tshirtServices.Serche(search);

                if (searchResults != null)
                {
                    tshirtDTO = searchResults.ToList();
                }
                else
                {
                    tshirtDTO = Enumerable.Empty<TshirtDTO>();
                }
            }
            else
            {
                tshirtDTO = (await tshirtServices.GetTshirtAsync()).ToList();
            }
        }
        private void ShowOriginalPrice()
        {
            OriginalPrice = ShoesPrice;
            StateHasChanged();
        }

        private void ShowHoverPrice()
        {
            OriginalPrice = "Select Option";
            StateHasChanged();
        }
        private void RedirectToShoesPage(string shoesId)
        {
            if (!string.IsNullOrEmpty(shoesId))
            {
                NavigationManager.NavigateTo($"/shoes/{shoesId}");
            }
        }
        private void NavigateTo()
        {
            NavigationManager.NavigateTo($"/create");
        }
        private void ChangeImage(TshirtDTO tshirt)
        {
            imageUrl = tshirt.ImgUrl2;
            selecttshirt = tshirt;
        }

        private void RestoreImage()
        {
            imageUrl = selecttshirt.ImgUrl;
        }
    }
}
