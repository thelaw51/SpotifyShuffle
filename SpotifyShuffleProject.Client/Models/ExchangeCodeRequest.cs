namespace SpotifyShuffleProject.Models
{
   public class ExchangeCodeRequest
   {
      public string responseType { get; set; }

      public string clientID { get; set; }

      public string scope { get; set; }

      public string codeChallengeMethod { get; set; }

      public string codeChallenge { get; set; }

      public string redirectURI { get; set; }
   }
}
