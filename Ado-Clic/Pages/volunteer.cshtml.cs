using Business.Requests;
using Business.Responses;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ado_Clic.Pages
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Volunteer")]
    public class VolunteerModel(IInterventionService interventionService, IUserService userService) : PageModel
    {
        private readonly IInterventionService _interventionService = interventionService;
        private readonly IUserService _userService = userService;

        public List<InterventionRequestData> RequestData { get; set; } = [];

        public async Task<IActionResult> OnGet()
        {
            string email = User.Claims.First(c => c.Type.Contains("email")).Value;

            UserProfileData user = await _userService.GetUserProfileDataByEmailAsync(email);

            long[] typeIds = user.InterventionTypes.Select(it => it.Id).ToArray();

            RequestData.AddRange(await _interventionService.GetNotAcceptedByTypeAsync(typeIds));

            return Page();
        }
    }
}
