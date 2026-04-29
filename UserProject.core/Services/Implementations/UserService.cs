using AutoMapper;
using UserProject.Core.AppException;
using UserProject.Core.AppExceptions;
using UserProject.Core.DTOs;
using UserProject.Core.Services.Interfaces;
using UserProject.DataAccess.Repositories.Interfaces;

namespace UserProject.Core.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IProfileRepository profileRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> DeleteAccountAsync(Guid id)
        {
            var profile = await _profileRepository.GetByProfileIdAsync(id);
            var userEntity = await _userRepository.GetByEmailAsync(profile.Email);

            if (profile != null && userEntity != null)
            {

                await _userRepository.DeleteAsync(userEntity);
                await _profileRepository.DeleteAsync(profile);
                await SaveChangesAsync();


                return _mapper.Map<UserDto>(userEntity);

            }

            throw new NotFoundAccountException();

        }

        public async Task<UserDto> DeleteUserAccountAsync(Guid id)
        {

            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new NotFoundAccountException($"User {id} not found.");


            var profile = await _profileRepository.GetByProfileIdAsync(id);


            if (profile != null)
                await _profileRepository.DeleteAsync(profile);


            await _userRepository.DeleteAsync(user);

            await SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }


        public async Task<UserDto> UpdateAccountAsync(ProfileDto profileDto)
        {
            var userEntity = await _userRepository.GetByEmailAsync(profileDto.Email);
            var profile = await _profileRepository.GetByProfileIdAsync(profileDto.UserId);

            if (profile != null && userEntity != null)
            {

                if (profile.UserId == userEntity.Id)
                {
                    userEntity.Email = profileDto.Email;
                    userEntity.Role = profileDto.Role;
                    await _userRepository.UpdateAsync(userEntity);
                    await _profileRepository.UpdateAsync(profile);
                    await SaveChangesAsync();

                    return _mapper.Map<UserDto>(userEntity);
                }

                throw new EmailAlreadyTakenException();
            }

            throw new NotFoundAccountException();

        }

        public async Task<UserDto> AddAccountAsync(ProfileDto profileDto)
        {
            var userEntity = await _userRepository.GetByEmailAsync(profileDto.Email);
            var profile = await _profileRepository.GetByProfileIdAsync(profileDto.UserId);

            if (profile == null && userEntity == null)
            {

                if (profile.UserId == userEntity.Id)
                {
                    userEntity.Email = profileDto.Email;
                    userEntity.Role = profileDto.Role;
                    await _userRepository.AddAsync(userEntity);
                    await _profileRepository.AddAsync(profile);
                    await SaveChangesAsync();

                    return _mapper.Map<UserDto>(userEntity);
                }

                throw new MisMacthUserAndProfileIDExeption();
            }

            throw new EmailAlreadyTakenException();

        }

        public async Task<IEnumerable<UserDto>> GetAllUsers(int page, int pageSize)
        {
            var users = await _userRepository.GetAllUsers(page, pageSize);

            var userDtos = _mapper.Map<List<UserDto>>(users);


            return userDtos;
        }

        private async Task SaveChangesAsync()
        {
            await _profileRepository.SaveChangesAsync();
        }

        public async Task<UserDto> PromoteUserAccountAsync(string role, Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user != null)
            {
                user.Role = role;
                await _userRepository.UpdateAsync(user);

                return _mapper.Map<UserDto>(user);
            }

            throw new NotFoundAccountException();
        }
    }

}
