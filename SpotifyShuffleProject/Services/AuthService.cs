using SpotifyShuffleProject.Services.Interfaces;
using SpotifyShuffleProject.Models;

namespace SpotifyShuffleProject.Services
{
   public class AuthService : IAuthService
   {
      public async Task<HttpResponseMessage> ExchangeAuthorizationCodeForToken(HttpClient client,
         ExchangeCodeRequest requestDetails)
      {
         var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/authorize");
         var content = new FormUrlEncodedContent(new[]
         {
            new KeyValuePair<string, string>("client_id", Environment.GetEnvironmentVariable("CLIENT_ID")),
            new KeyValuePair<string, string>("response_type", requestDetails.responseType),
            new KeyValuePair<string, string>("redirect_uri", requestDetails.RedirectUri),
            new KeyValuePair<string, string>("code_challenge_method", requestDetails.codeChallengeMethod),
            new KeyValuePair<string, string>("code_challenge", requestDetails.codeChallenge)
         });
         request.Content = content;

         return await client.SendAsync(request);
      }

      public Task<HttpResponseMessage> ExchangeAuthorization(HttpClient client, string code, string codeVerifier)
      {
         throw new NotImplementedException();
      }
   }
}