using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using videoPortal.Requests;
using videoPortal.Responses;
using videoPortal.Services;

namespace videoPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService identityService;
        public IdentityController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            var authResponse = await identityService.RegisterAsync(request.Email, request.Password);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors

                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
            });


        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var authResponse = await identityService.LoginAsync(request.Email, request.Password);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors

                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token

            });

        }
    }
}
