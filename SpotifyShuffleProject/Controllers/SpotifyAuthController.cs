// Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBlazorServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost("exchange")]
        public async Task<IActionResult> ExchangeCode([FromBody] ExchangeCodeRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var tokenResponse = await ExchangeAuthorizationCodeForToken(client, request.Code, request.CodeVerifier);
            
            if (tokenResponse.IsSuccessStatusCode)
            {
                var token = await tokenResponse.Content.ReadAsStringAsync();
                return Ok(token);
            }

            return BadRequest("Error exchanging code");
        }

        private async Task<HttpResponseMessage> ExchangeAuthorizationCodeForToken(HttpClient client, string code, string codeVerifier)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("client_id", "YOUR_CLIENT_ID"),
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("redirect_uri", "YOUR_REDIRECT_URI"),
                new KeyValuePair<string, string>("code_verifier", codeVerifier),
                new KeyValuePair<string, string>("client_secret", "YOUR_CLIENT_SECRET")
            });
            request.Content = content;

            return await client.SendAsync(request);
        }
    }

    public class ExchangeCodeRequest
    {
        public string Code { get; set; }
        public string CodeVerifier { get; set; }
    }
}