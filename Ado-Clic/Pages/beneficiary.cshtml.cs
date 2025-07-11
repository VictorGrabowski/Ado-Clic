using Business.Requests;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Model;

namespace Ado_Clic.Pages
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Beneficiary")]
    public class BeneficiaryModel(IInterventionService interventionService) : PageModel
    {
        private readonly IInterventionService _interventionService = interventionService;

        [BindProperty]
        public InterventionRequestCreation InterventionRequestCreation { get; set; }

        public List<InterventionType> InterventionTypes { get; set; } = [];

        public List<InterventionRequestData> RequestData { get; set; } = [];

        public async Task<IActionResult> OnGet()
        {
            string? userEmail = User.Claims.FirstOrDefault(claim => claim.Type.Contains("email"))?.Value;

            if (userEmail == null) return NotFound();

            RequestData.AddRange(await _interventionService.GetInterventionRequestDataByUserAsync(userEmail));
            InterventionTypes.AddRange(await _interventionService.GetInterventionTypesAsync());

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            string? userEmail = User.Claims.FirstOrDefault(claim => claim.Type.Contains("email"))?.Value;

            if (userEmail == null) return NotFound();

            await _interventionService.CreateInterventionAsync(InterventionRequestCreation, userEmail);

            return RedirectToPage(); // Reloads the page by redirecting to itself  
        }
    }
}
