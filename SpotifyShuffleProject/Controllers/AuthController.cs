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
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpGet]
		[Route("GetSpotifyAuthURL")]
		public async Task<IActionResult> ExchangeCode()
		{
			var loginUri = await _authService.Login();
			return Ok(new { uri = loginUri.ToString() });
		}
	}
}