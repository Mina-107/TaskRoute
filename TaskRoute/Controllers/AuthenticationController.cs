namespace PersentationLayer.AI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
    {
       
        [HttpPost("Register")]
        public async Task<ActionResult<UserResultDto>> Register(UserRegisterDto userRegisterDto)
        {
            var Result = await authenticationService.RegisterAsync(userRegisterDto);
            return Ok(Result);

        }
       
        [HttpPost("Login")]
        public async Task<ActionResult<UserResultDto>> Login(LoginDto loginDto)
        {
            var Result = await authenticationService.LoginAsync(loginDto);
            return Ok(Result);
        }

       
    }
}
