using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ado_Clic.Pages
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            // Clear the JWT cookie
            Response.Cookies.Delete("jwtToken");

            // Redirect to the home page or login page
            Response.Redirect("/index");
        }
    }
}
