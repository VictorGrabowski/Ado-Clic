using Business.Responses;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ado_Clic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet("profile")]
        public async Task<ActionResult<UserProfileData>> GetUserProfileDataAsync()
        {
            string? email = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

            if (email == null) return Unauthorized();

            UserProfileData profileData = await _userService.GetUserProfileDataByEmail(email);

            return Ok(profileData);
        }
    }
}
