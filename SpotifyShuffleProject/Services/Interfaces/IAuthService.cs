using SpotifyShuffleProject.Models;

namespace SpotifyShuffleProject.Services.Interfaces
{
   public interface IAuthService
   {
      Task<Uri> Login();
      Task<object> GetAccessToken(string code);
   }
}