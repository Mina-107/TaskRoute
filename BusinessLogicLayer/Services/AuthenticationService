
namespace Services
{
    internal class AuthenticationService(UserManager<ApplicationUser> userManager,IConfiguration configuration,IOptions<JwtOptions> options,IMapper mapper)
        : IAuthenticationService
    {
      

        public async Task<UserResultDto> LoginAsync(LoginDto loginDto)
        {
            var User = await userManager.FindByEmailAsync(loginDto.Email);
            if (User == null) throw new UnAuthorizedException("Email Doesn't Exist");
            var Result = await userManager.CheckPasswordAsync(User, loginDto.Password);
            if (!Result) throw new UnAuthorizedException("Password Is InCorrect");
            return new UserResultDto
               (
                User.UserName,
                User.Email,
                 await CreateTokenAsync(User)
                );
        }

        public  async Task<UserResultDto> RegisterAsync(UserRegisterDto registerDto)
        {
            var User = new ApplicationUser()
            {
Email= registerDto.Email,
PhoneNumber= registerDto.PhoneNumber,
UserName= registerDto.UserName,
            };
            var Result = await userManager.CreateAsync(User, registerDto.Password);
            if(!Result.Succeeded)
            {
                var errors = Result.Errors.Select(e => e.Description).ToList();
                throw new DataAccessLayer.Exceptions.ValidationException(errors);
            }
            return new UserResultDto(
                User.UserName,
                User.Email,
                await CreateTokenAsync(User));
           
        }

       

        private async Task<string>CreateTokenAsync(ApplicationUser user)
        {
            var jwtoptions = options.Value;
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName!),
                new Claim(ClaimTypes.Email,user.Email!)
                
            };
            var roles = await userManager.GetRolesAsync(user);
            foreach( var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));

            }
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions.SecretKey));
            var signingCreds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var Token = new JwtSecurityToken(
                audience:jwtoptions.Audience,
                issuer: jwtoptions.Issuer,
                expires:DateTime.UtcNow.AddDays(jwtoptions.DurationInDays),
                claims:authClaims,
                signingCredentials:signingCreds

                );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        
        
        }


    }
}
