using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerc.Pages
{
    public class LogOutModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync("Cookies");
            }
            return LocalRedirect("~/");
        }
    }
}
