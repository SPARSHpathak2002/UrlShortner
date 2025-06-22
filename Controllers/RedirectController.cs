using Microsoft.AspNetCore.Mvc;
using UrlShortner.Data;

namespace UrlShortner.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)] // Hide from Swagger/OpenAPI
    [Route("{id}")]
    public class RedirectController : ControllerBase
    {
        private readonly UrlShortnerContext _context;

        public RedirectController(UrlShortnerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult RedirectToOriginal(string id)
        {
            var urlInfo = _context.UrlInfos.FirstOrDefault(u => u.ShortenedUrlId == id);
            if (urlInfo == null || string.IsNullOrEmpty(urlInfo.OriginalUrl))
            {
                return NotFound("Shortened URL not found.");
            }

            // Increment click count
            var urlStat = _context.UrlStats.FirstOrDefault(s => s.UrlId == urlInfo.Id);
            if (urlStat != null)
            {
                urlStat.CountsClicked += 1;
                _context.SaveChanges();
            }

            return Redirect(urlInfo.OriginalUrl);
        }
    }
}