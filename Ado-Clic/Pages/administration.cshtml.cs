using Ado_Clic.Pages.Administration;
using Business.Responses;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ado_Clic.Pages
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public class AdministrationModel(IUserService userService) : PageModel
    {
        private readonly IUserService _userService = userService;

        public List<UserListData> _userListData = [];

        public async Task OnGet()
        {
            _userListData = await _userService.GetAllUsersAsListDataAsync();
        }

        public IActionResult OnGetUsersPartialAsync()
        {
            return Partial("Administration/_UsersPartial");
        }

        public IActionResult OnGetInterventionsPartial()
        {
            return Partial("Administration/_InterventionsPartial");
        }
    }
}
