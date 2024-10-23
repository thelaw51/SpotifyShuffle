using Microsoft.AspNetCore.Mvc;
using SpotifyShuffleProject.Models;
using SpotifyShuffleProject.Services;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBlazorServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private AuthService _authService;

        public AuthController(IHttpClientFactory httpClientFactory,AuthService authService)
        {
            _httpClientFactory = httpClientFactory;
            _authService = authService;
        }

        [HttpPost("exchange")]
        public async Task<IActionResult> ExchangeCode([FromBody] ExchangeCodeRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            
            var tokenResponse = await _authService.ExchangeAuthorizationCodeForToken(client, request.responseType, request.codeChallenge);

            if (tokenResponse.IsSuccessStatusCode)
            {
                var token = await tokenResponse.Content.ReadAsStringAsync();
                return Ok(token);
            }

            return BadRequest("Error exchanging code");
        }

        
    }

    
}