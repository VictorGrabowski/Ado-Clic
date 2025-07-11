using Business.Responses;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ado_Clic.Pages.Administration
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public class UsersPartialModel : PageModel
    {
        public List<UserListData> UserListData { get; set; } = [
            new(){ Email = "john@doe.com", FirstName = "John", LastName = "Doe", Role = "Beneficiary"},
            new(){ Email = "mary.lee@gmail.com", FirstName = "Mary", LastName = "Lee", Role = "Volunteer"}
            ];
    }
}
