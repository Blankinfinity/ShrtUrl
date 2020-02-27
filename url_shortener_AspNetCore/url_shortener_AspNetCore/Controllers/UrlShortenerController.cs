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
    [Produces("application/json")]
    public class UrlShortenerController : Controller
    {
        private readonly IShortenUrlService _service;

        public UrlShortenerController(IShortenUrlService service)
        {
            _service = service;
        }

        [Route("api/[controller]")]
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] string originalUrl)
        {
            if (UrlValidation.IsValidUrl(originalUrl))
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

                var returnedUrl = ShortUrlHelper.Encode(shortUrl.Id);
                return Ok("http://shrturl.keith-pearce.co.uk/url/" + returnedUrl); 
            }
            else
            {
                return BadRequest("Please enter a valid URL");
            }
        }

        [HttpGet]
        [Route("url/{path}")]
        public IActionResult RedirectTo([FromRoute] string path)
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
