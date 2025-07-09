using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ado_Clic.Pages
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
