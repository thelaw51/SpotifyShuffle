using Microsoft.AspNetCore.Mvc;
using SpotifyShuffleProject.Models;
using SpotifyShuffleProject.Services.Interfaces;

namespace MyBlazorServer.Controllers
{
   [ApiController]
   [IgnoreAntiforgeryToken]
   [Route("api/[controller]")]
   public class AuthController : ControllerBase
   {
      private readonly IHttpClientFactory _httpClientFactory;
      private IAuthService _authService;

      public AuthController(IHttpClientFactory httpClientFactory, IAuthService authService)
      {
         _httpClientFactory = httpClientFactory;
         _authService = authService;
      }

      [HttpPost]
      [Route("exchange")]
      public async Task<IActionResult> ExchangeCode([FromBody] ExchangeCodeRequest request)
      {
         var client = _httpClientFactory.CreateClient();

         var tokenResponse =
            await _authService.ExchangeAuthorizationCodeForToken(client, request);

         if (tokenResponse.IsSuccessStatusCode)
         {
            var token = await tokenResponse.Content.ReadAsStringAsync();
            return Ok(token);
         }

         return BadRequest("Error exchanging code");
      }
   }
}