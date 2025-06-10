﻿namespace UrlShortner.Models
{
    public class Link
    {
       public int Id {get; set; }
       public string? OriginalUrl { get; set; }
       public string? ShortenedUrl { get; set; }
       public DateTime CreatedAt { get; set; }
       
    }
}
