using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using url_shortener_WebForms.Models;

namespace url_shortener_WebForms.Data
{
    public class UrlShortenerContext : DbContext
    {
        public UrlShortenerContext() : base("UrlShortenerContext")
        {

        }

        public DbSet<ShortenedUrl> ShortUrls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortenedUrl>().ToTable("OrignalUrl").Property(url => url.DateCreated).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
        }
    }
}