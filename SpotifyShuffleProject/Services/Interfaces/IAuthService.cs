namespace SpotifyShuffleProject.Services.Interfaces
{
   public interface IAuthService
   {
      Task<HttpResponseMessage> ExchangeAuthorizationCodeForToken(HttpClient client, string code, string codeVerifier);
   }
}
