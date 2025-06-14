using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using UrlShortner.Data;
using UrlShortner.Models;

namespace UrlShortner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly UrlShortnerContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardController(UrlShortnerContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            var domain = request != null
                ? $"{request.Scheme}://{request.Host}"
                : "https://localhost"; // fallback

            var urls = _context.UrlInfos
                .Select(u => new
                {
                    mainUrl = u.OriginalUrl,
                    shortenedUrl = $"{domain}/{u.ShortenedUrlId}"
                })
                .ToList();

            return Ok(urls);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return BadRequest("URL cannot be empty.");
            }
            var urlInfo = new UrlInfo { OriginalUrl = url, ShortenedUrlId = GenerateShortenedUrl(), CreatedAt = DateTime.UtcNow };
            _context.UrlInfos.Add(urlInfo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private string GenerateShortenedUrl()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789";
            var random = new Random();
            return new string(Enumerable.Range(0, 4)
                .Select(_ => chars[random.Next(chars.Length)]).ToArray());
        }
    }
}