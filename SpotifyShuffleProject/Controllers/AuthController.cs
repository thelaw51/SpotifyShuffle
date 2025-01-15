using System.Web;
using Microsoft.AspNetCore.Mvc;
using SpotifyShuffleProject.Services.Interfaces;

namespace MyBlazorServer.Controllers
{
	[ApiController]
	[IgnoreAntiforgeryToken]
	[Route("api/[controller]")]
	public class AuthController(IAuthService authService) : ControllerBase
	{
		[HttpGet]
		[Route("GetSpotifyAuthURL")]
		public async Task<IActionResult> GetSpotifyAuthURL()
		{
			var loginUri = await authService.Login();
			return Ok(new { uri = loginUri.ToString() });
		}
		
		[HttpGet]
		[Route("SpotifyAuthRedirect{code}")]
		public async Task<IActionResult> SpotifyAuthRedirect(string code)
		{
			var accessToken = await authService.GetAccessToken(code);
		}
	}
}