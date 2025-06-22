using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShortner.Models
{
    public class UrlStats
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UrlInfo")]
        public int UrlId { get; set; }
        public int CountsClicked { get; set; }

        public UrlInfo? UrlInfo { get; set; }
    }
}