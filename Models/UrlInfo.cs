using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace UrlShortner.Models
{
    [Index(nameof(ShortenedUrlId), IsUnique = true)]
    public class UrlInfo
    {
        [Key]
        public int Id { get; set; }
        public string? OriginalUrl { get; set; }

        [StringLength(4)]      
        public string? ShortenedUrlId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
