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
      private readonly IAuthService _authService;

      public AuthController(IHttpClientFactory httpClientFactory, IAuthService authService)
      {
         _httpClientFactory = httpClientFactory;
         _authService = authService;
      }

      [HttpPost]
      [Route("authSpotify")]
      public async Task<IActionResult> ExchangeCode()
      {
         var loginUri =
            await _authService.Login();
         return Redirect(loginUri.ToString());
      }
   }
}