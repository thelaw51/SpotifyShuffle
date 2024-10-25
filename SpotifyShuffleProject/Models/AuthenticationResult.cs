﻿namespace SpotifyShuffleProject.Models
{
   public class AuthenticationResult
   {
      public string AccessToken { get; set; }
      public string RefreshToken { get; set; }
      public int ExpiresIn { get; set; }
   }
}
