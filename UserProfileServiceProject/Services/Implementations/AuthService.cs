using BCrypt.Net;
using UserProfileServiceProject.DTOs;
using UserProfileServiceProject.Entities;
using UserProfileServiceProject.Repositories.Interfaces;
using UserProfileServiceProject.Security;
using UserProfileServiceProject.Services.Interfaces;

namespace UserProfileServiceProject.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IJwtService _jwtService;

        public AuthService(
            IUserRepository userRepository,
            IProfileRepository profileRepository,
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _jwtService = jwtService;
        }

        public async Task RegisterAsync(RegisterDto dto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "User",
                CreatedAt = DateTime.UtcNow
            };

         
            await _userRepository.AddAsync(user);
           // await _profileRepository.AddAsync(profile);

            await _userRepository.SaveChangesAsync();
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Email)) throw new ArgumentException("Email is required.", nameof(dto.Email));
            if (string.IsNullOrWhiteSpace(dto.Password)) throw new ArgumentException("Password is required.", nameof(dto.Password));

            var user = await _userRepository.GetByEmailAsync(dto.Email.Trim().ToLowerInvariant());

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            bool passwordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!passwordValid)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            var token = _jwtService.GenerateToken(user);

            return token;
        }
    }
}
