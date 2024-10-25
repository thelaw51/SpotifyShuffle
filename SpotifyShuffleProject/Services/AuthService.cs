using System.Security.Cryptography;
using SpotifyShuffleProject.Services.Interfaces;
using SpotifyShuffleProject.Models;
using SpotifyAPI.Web;

namespace SpotifyShuffleProject.Services
{
   public class AuthService : IAuthService
   {
      public async Task<Uri> Login()
      {
         return GenerateLoginUri();
      }

      private static string GenerateRandomString(int length)
      {
         const string possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

         using var rng = new RNGCryptoServiceProvider();
         var randomBytes = new byte[length];
         rng.GetBytes(randomBytes);

         var chars = randomBytes.Select(b => possible[b % possible.Length]);
         return new string(chars.ToArray());
      }

      private static Uri GenerateLoginUri()
      {
         var (verifier, challenge) =
            PKCEUtil.GenerateCodes(GenerateRandomString(64));

         var loginRequest = new LoginRequest(
            new Uri("https://localhost:7188/"),
            Environment.GetEnvironmentVariable("CLIENT_ID"),
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