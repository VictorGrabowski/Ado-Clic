using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ado_Clic.Pages.Administration
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public class InterventionsPartialModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
