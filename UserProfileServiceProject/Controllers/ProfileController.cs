using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserProfileServiceProject.DTOs;
using UserProfileServiceProject.Services.Interfaces;

namespace UserProfileServiceProject.Controllers
{

    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyProfile()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var profile = await _profileService.GetProfile(userId);

            return Ok(profile);
        }

        //  [Authorize("BasicUserAccess")]
        [HttpGet("Guid")]
        public async Task<IActionResult> GetProfileById(Guid userId)
        {
            var profile = await _profileService.GetProfile(userId);

            return Ok(profile);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProfileDto dto)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _profileService.UpdateProfileAsync(userId, dto);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProfileDto dto)
        {
            await _profileService.CreateProfileAsync(dto);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _profileService.DeleteProfileAsync(userId);

            return Ok();
        }
    }
}
