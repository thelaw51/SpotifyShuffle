using SpotifyShuffleProject.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace SpotifyShuffleProject.Services
{
   public class AuthService : IAuthService
   {
      public async Task<HttpResponseMessage> ExchangeAuthorizationCodeForToken(HttpClient client, string code, string codeVerifier)
      {
         var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/authorize");
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
}
