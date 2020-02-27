using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace url_shortener_WebForms.Models
{
    public class ShortenedUrl
    {
        public int Id { get; set; }

        [Required]
        public string OriginalUrl { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
