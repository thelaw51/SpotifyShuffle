using SpotifyShuffleProject.Models;

namespace SpotifyShuffleProject.Services.Interfaces
{
   public interface IAuthService
   {
      Task<HttpResponseMessage>
         ExchangeAuthorizationCodeForToken(HttpClient client, ExchangeCodeRequest requestDetails);
   }
}