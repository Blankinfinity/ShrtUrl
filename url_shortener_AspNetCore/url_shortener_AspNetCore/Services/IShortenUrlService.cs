using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using url_shortener_AspNetCore.Models;

namespace url_shortener_AspNetCore.Services
{
    public interface IShortenUrlService
    {
        ShortenedUrl GetById(int id);

        ShortenedUrl GetByPath(string path);

        ShortenedUrl GetByOriginalUrl(string originalUrl);

        int Save(ShortenedUrl shortUrl);
    }
}
