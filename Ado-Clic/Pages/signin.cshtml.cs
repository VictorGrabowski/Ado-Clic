using Business.Requests;
using Business.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ado_Clic.Pages
{
    public class SigninModel : PageModel
    {
        private readonly HttpClient _httpClient;

        [BindProperty]
        public LoginRequest LoginRequest { get; set; }

        public SigninModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/api/auth/login", LoginRequest);

            if (response.IsSuccessStatusCode)
            {
                TokenResponse? result = await response.Content.ReadFromJsonAsync<TokenResponse>();

                Response.Cookies.Append("jwtToken", result.Token, new CookieOptions()
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTimeOffset.UtcNow.AddHours(1)
                });

                return RedirectToPage("/index");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }

    }
}
