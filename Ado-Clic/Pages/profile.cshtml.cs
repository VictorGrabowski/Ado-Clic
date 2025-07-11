using Business.Responses;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ado_Clic.Pages
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProfileModel(IUserService userService, IInterventionService interventionService) : PageModel
    {
        private readonly IUserService _userService = userService;
        private readonly IInterventionService _interventionService = interventionService;

        [BindProperty]
        public UserProfileData? ProfileData { get; set; }

        public async Task<IActionResult> OnGet()
        {
            string email = User.Claims.First(c => c.Type.Contains("email")).Value;

            ProfileData = await _userService.GetUserProfileDataByEmailAsync(email);

            if (ProfileData == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> DeleteInterventionType(long interventionId)
        {
            long userId = ProfileData?.Id ?? throw new ArgumentNullException(nameof(ProfileData.Id));

            await _interventionService.DeleteOneUserTypeAsync(userId, interventionId);

            return RedirectToPage();
        }
    }
}
