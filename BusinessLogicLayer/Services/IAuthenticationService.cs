

namespace Services
{
    public interface IAuthenticationService
    {
        public Task<UserResultDto> LoginAsync(LoginDto loginDto);
        public Task<UserResultDto> RegisterAsync(UserRegisterDto registerDto);
        

    }
}

