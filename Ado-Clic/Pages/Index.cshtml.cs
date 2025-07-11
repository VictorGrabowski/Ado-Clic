using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ado_Clic.Pages
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (User.IsInRole("Admin"))
            {
                return Redirect("/administration");
            }
            else if (User.IsInRole("Volunteer"))
            {
                return Redirect("/volunteer");
            }
            else if (User.IsInRole("Beneficiary"))
            {
                return Redirect("/beneficiary");
            }

            return Page();
        }
    }
}
