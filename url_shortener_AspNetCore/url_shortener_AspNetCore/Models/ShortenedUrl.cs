using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace url_shortener_AspNetCore.Models
{
    public class ShortenedUrl
    {
        public int Id { get; set; }

        [Required]
        public string OriginalUrl { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
