using Microsoft.AspNetCore.Components;

namespace E_Commerc.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        int hoveredImage = 0;
        void ShowHoverImage(int imageNumber)
        {
            hoveredImage = imageNumber;
        }
        void HideHoverImage(int imageNumber)
        {
            hoveredImage = 0;
        }
        private void RedirectToShoesPage()
        {
            NavigationManager.NavigateTo($"/shoes/{31}");
        }
        private void RedirectToShoesPagee()
        {
            NavigationManager.NavigateTo($"/shoes/{30}");
        }
        private void RedirectToShoesPageId()
        {
            NavigationManager.NavigateTo($"/shoes/{29}");
        }
        private void RedirectToShoes()
        {
            NavigationManager.NavigateTo($"/shoes/{26}");
        }
        private void Redirect()
        {
            NavigationManager.NavigateTo("/listofshoes");
        }
        //--------------------------------------------------------------
        private void Maica1()
        {
            NavigationManager.NavigateTo($"/shoes/{27}");
        }
        private void Maica2()
        {
            NavigationManager.NavigateTo($"/shoes/{34}");
        }
        private void Maica3()
        {
            NavigationManager.NavigateTo($"/shoes/{33}");
        }
        private void Maica4()
        {
            NavigationManager.NavigateTo($"/shoes/{38}");
        }
    }
}
