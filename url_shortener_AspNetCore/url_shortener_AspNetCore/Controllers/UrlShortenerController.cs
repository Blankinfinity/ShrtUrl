using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using url_shortener_AspNetCore.Models;
using url_shortener_AspNetCore.Services;
using UrlShortenerLib;

namespace url_shortener_AspNetCore.Controllers
{
    [Route("api/[controller]")]
    public class UrlShortenerController : Controller
    {
        private readonly IShortenUrlService _service;

        public UrlShortenerController(IShortenUrlService service)
        {
            _service = service;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] string originalUrl)
        {
            var shortUrl = new ShortenedUrl
            {
                OriginalUrl = originalUrl
            };

            TryValidateModel(shortUrl);
            if (ModelState.IsValid)
            {
                _service.Save(shortUrl);
            }

            return Ok(ShortUrlHelper.Encode(shortUrl.Id));
        }

        [HttpGet("/ShortUrls/RedirectTo/{path:required}", Name = "ShortUrls_RedirectTo")]
        public IActionResult RedirectTo(string path)
        {
            if (path == null)
            {
                return NotFound();
            }

            var shortUrl = _service.GetByPath(path);
            if (shortUrl == null)
            {
                return NotFound();
            }

            return Redirect(shortUrl.OriginalUrl);
        }
    }
}
