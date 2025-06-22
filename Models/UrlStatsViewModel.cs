namespace UrlShortner.Models
{
    public class UrlStatsViewModel
    {
        public string? MainUrl { get; set; }
        public string? ShortenedUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CountsClicked { get; set; }
    }
}