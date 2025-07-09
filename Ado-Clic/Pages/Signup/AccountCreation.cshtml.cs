using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ado_Clic.Pages;

public class AccountCreation: PageModel
{
    public RedirectToPageResult RedirectToAdminSubscriptionPage()
    {
        return RedirectToPage("./Admin/Subscription");
    }
    public IActionResult OnPostRedirectToAdminSubscriptionPage()
    {
        return RedirectToPage("./Admin/Subscription");
    }
    
}