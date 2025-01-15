using System.Security.Cryptography;
using SpotifyShuffleProject.Services.Interfaces;
using SpotifyAPI.Web;

namespace SpotifyShuffleProject.Services
{
   public class AuthService : IAuthService
   {
		public Task<Uri> Login()
      {
         return Task.FromResult(GenerateLoginUri());
      }

      public Task<object> GetAccessToken(string code)
      {
         throw new NotImplementedException();
      }

      private static string GenerateRandomString(int length)
      {
         const string possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

         var randomBytes = new byte[length];
         RandomNumberGenerator.Fill(randomBytes);

         var chars = randomBytes.Select(b => possible[b % possible.Length]);
         return new string(chars.ToArray());
      }

      private static Uri GenerateLoginUri()
      {
         var (verifier, challenge) =
            PKCEUtil.GenerateCodes(GenerateRandomString(64));

         var clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
         if (string.IsNullOrEmpty(clientId))
         {
            throw new InvalidOperationException("CLIENT_ID environment variable is not set.");
         }

         var loginRequest = new LoginRequest(
            new Uri("https://localhost:7188/"),
            clientId,
            LoginRequest.ResponseType.Code
         )
         {
            CodeChallengeMethod = "S256",
            CodeChallenge = challenge,
            Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative }
         };
         return loginRequest.ToUri();
      }
   }
}