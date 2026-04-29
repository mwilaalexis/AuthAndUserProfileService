using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserProject.Core.DTOs;
using UserProject.Core.Services.Interfaces;

namespace UserProfileServiceProject.Controllers
{

    [Authorize(policy: "ContentManager")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;

        public UserController(IUserService userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page, int pageSize)
        {
            return Ok(await _userServices.GetAllUsers(page, pageSize));
        }

        [HttpDelete("{userId:Guid}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            await _userServices.DeleteUserAccountAsync(userId);
            return NoContent();
        }
        [Authorize(policy: "AdminOnly")]
        [HttpDelete("Monitors/{Id:Guid}")]
        public async Task<IActionResult> DeleteMonitors(Guid userId)
        {
            await _userServices.DeleteAccountAsync(userId);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProfileDto profileDto)
        {
            await _userServices.UpdateAccountAsync(profileDto);

            return NoContent();
        }

        [HttpPatch("role")]
        [Authorize(policy: "AdminOnly")]
        public async Task<IActionResult> Promote(string role, Guid Id)
        {
            await _userServices.PromoteUserAccountAsync(role, Id);

            return NoContent();
        }
       

    }
}
