namespace SpotifyShuffleProject.Client.Models
{
   public class ExchangeCodeRequest
   {
      public string? clientID { get; set; }

      public string? responseType { get; set; } = "code";

      public string? redirectURI { get; set; }

      public string? state { get; set; }

      public string? scope { get; set; }

      public string? codeChallengeMethod { get; set; } = "S256";

      public string? codeChallenge { get; set; }
   }
}