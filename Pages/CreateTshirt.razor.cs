using E_Commerc.Data;
using E_Commerc.Service;
using Microsoft.AspNetCore.Components;

namespace E_Commerc.Pages
{
    public partial class CreateTshirt : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ITshirtService tshirtServices { get; set; }

        public TshirtDTO TshirtDTO { get; set; } = new TshirtDTO();

        public async Task Add()
        {
            if (tshirtServices != null)
            {
                var item = await tshirtServices.Add(TshirtDTO);
            }
        }
        public void Navigate()
        {
            NavigationManager.NavigateTo($"/create", forceLoad: true);
        }
    }
}
