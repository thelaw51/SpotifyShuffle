namespace SpotifyShuffleProject.Client.Models
{
   public class ExchangeCodeRequest
   {
      public string? clientID { get; set; }

      public string? responseType { get; set; } = "code";

      public string? RedirectUri { get; set; } = "https://localhost:7188";

      public string? state { get; set; }

      public string? scope { get; set; } = "user-read-private user-read-email";

      public string? codeChallengeMethod { get; set; } = "S256";

      public string? codeChallenge { get; set; }
   }
}