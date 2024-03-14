﻿using E_Commerc.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace E_Commerc.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private void NavigateToOtherPage()
        {
            NavigationManager.NavigateTo("/createaccount");
        }
        [BindProperty]
        public InputModel Input { get; set; }

        private IAuthService _authService { get; set; }

        public LoginModel(IAuthService authService)
        {
            _authService = authService;
        }

        public class InputModel
        {
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        }


        public async Task<IActionResult> OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return LocalRedirect("~/");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var tokenObject = await _authService.Login(Input.Email, Input.Password);
                    if (tokenObject != null)
                    {

                        var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, "DisplayName", "");
                        claimsIdentity.AddClaim(new Claim("Token", tokenObject.Token));
                        var principal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        return LocalRedirect("~/");
                    }
                    TempData["ErrorMessage"] = "Not Found your Account.";
                }
                return Page();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error Serer Localhost";
                return Page();
            }
        }

    }
}
