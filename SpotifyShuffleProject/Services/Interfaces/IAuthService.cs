using SpotifyShuffleProject.Models;

namespace SpotifyShuffleProject.Services.Interfaces
{
   public interface IAuthService
   {
      Task<Uri> Login();
   }
}