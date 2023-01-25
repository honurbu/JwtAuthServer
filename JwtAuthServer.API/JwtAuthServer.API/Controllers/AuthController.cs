using JwtAuthServer.Core.DTOs;
using JwtAuthServer.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthServer.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenAsync(LoginDto loginDto)
        {
            var results = await _authenticationService.CreateTokenAsync(loginDto);
            return ActionResultInstance(results);
        }


        [HttpPost]
        public IActionResult CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            var results = _authenticationService.CreateTokenByClient(clientLoginDto);
            return ActionResultInstance(results);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshToken)
        {
            var results = await _authenticationService.CreateTokenByRefreshToken(refreshToken.Token);
            return ActionResultInstance(results);
        }


        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshToken)
        {
            var results = await _authenticationService.RevokeRefreshToken(refreshToken.Token);
            return ActionResultInstance(results);
        }

    }
}
