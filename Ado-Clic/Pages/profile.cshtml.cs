using Business.Responses;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ado_Clic.Pages
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProfileModel : PageModel
    {
        private readonly HttpClient _httpClient;

        [BindProperty]
        public UserProfileData? ProfileData { get; set; }

        public ProfileModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<IActionResult> OnGet()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/user/profile");

            if (response.IsSuccessStatusCode)
            {
                ProfileData = await response.Content.ReadFromJsonAsync<UserProfileData>();
                return Page();
            }

            ModelState.AddModelError(string.Empty, "What.");
            return Page();
        }
    }
}
