using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserProject.Core.DTOs;
using UserProject.Core.Services.Interfaces;

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

        [Authorize(policy: "BasicUserAccess")]
        [HttpGet("me")]
        public async Task<IActionResult> GetMyProfile()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var profile = await _profileService.GetProfile(userId);

            return Ok(profile);
        }
      
        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetProfileById(string userId)
        {
            var profile = await _profileService.GetProfileSummary( Guid.Parse(userId));

            return Ok(profile);
        }

        [Authorize(policy: "BasicUserAccess")]
        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromForm] UpdateProfileDto dto)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _profileService.UpdateProfileAsync(userId, dto);

            return Ok();
        }

        [Authorize(policy: "BasicUserAccess")]
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CreateProfileDto dto)
        {
            await _profileService.CreateProfileAsync(dto);
            return Ok();
        }

        [Authorize(policy: "ContentManager")]
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _profileService.DeleteProfileAsync(userId);

            return Ok();
        }
    }
}
