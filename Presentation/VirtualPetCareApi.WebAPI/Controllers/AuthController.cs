using VirtualPetCareApi.Application.Features.Commands.Auth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VirtualPetCareApi.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommand loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommand refreshTokenLoginCommandRequest)
        {
            RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenLoginCommandRequest);
            return Ok(response);
        }

        //[HttpPost("google-login")]
        //public async Task<IActionResult> GoogleLogin(GoogleLoginCommand googleLoginCommandRequest)
        //{
        //    GoogleLoginCommandResponse response = await _mediator.Send(googleLoginCommandRequest);
        //    return Ok(response);
        //}

        //[HttpPost("facebook-login")]
        //public async Task<IActionResult> FacebookLogin(FacebookLoginCommand facebookLoginCommandRequest)
        //{
        //    FacebookLoginCommandResponse response = await _mediator.Send(facebookLoginCommandRequest);
        //    return Ok(response);
        //}

        //[HttpPost("password-reset")]
        //public async Task<IActionResult> PasswordReset([FromBody] PasswordResetCommand passwordResetCommandRequest)
        //{
        //    PasswordResetCommandResponse response = await _mediator.Send(passwordResetCommandRequest);
        //    return Ok(response);
        //}

        //[HttpPost("verify-reset-token")]
        //public async Task<IActionResult> VerifyResetToken([FromBody] VerifyResetTokenCommand verifyResetTokenCommandRequest)
        //{
        //    VerifyResetTokenCommandResponse response = await _mediator.Send(verifyResetTokenCommandRequest);
        //    return Ok(response);
        //}

    }
}