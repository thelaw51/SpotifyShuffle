namespace SpotifyShuffleProject.Client.Models
{
    public class Song
    {
        public required string Name { get; set; }
        public required string Artist { get; set; }
        public required string Album { get; set; }
        public  string? Image { get; set; }
        public  string? Preview { get; set; }
    }
}
