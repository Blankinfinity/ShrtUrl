using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using url_shortener_AspNetCore.Data;
using url_shortener_AspNetCore.Models;
using UrlShortenerLib;

namespace url_shortener_AspNetCore.Services
{
    public class ShortenUrlService : IShortenUrlService
    {
        private readonly UrlShortenerContext _context;

        public ShortenUrlService(UrlShortenerContext context)
        {
            _context = context;
        }

        public ShortenedUrl GetById(int id)
        {
            return _context.ShortUrls.Find(id);
        }

        public ShortenedUrl GetByPath(string path)
        {
            return _context.ShortUrls.Find(ShortUrlHelper.Decode((path)));
        }

        public ShortenedUrl GetByOriginalUrl(string originalUrl)
        {
            foreach (var shortUrl in _context.ShortUrls)
            {
                if (shortUrl.OriginalUrl == originalUrl)
                {
                    return shortUrl;
                }
            }

            return null;
        }

        public int Save(ShortenedUrl shortUrl)
        {
            _context.ShortUrls.Add(shortUrl);
            _context.SaveChanges();

            return shortUrl.Id;
        }
    }
}
