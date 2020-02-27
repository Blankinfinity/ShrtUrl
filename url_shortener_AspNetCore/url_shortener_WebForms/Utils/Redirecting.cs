using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using url_shortener_WebForms.Data;
using UrlShortenerLib;

namespace url_shortener_WebForms.Utils
{
    public class Redirecting : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            context.BeginRequest += new EventHandler(OnBeginRequest);
        }

        #endregion

        public void OnBeginRequest(Object source, EventArgs e)
        {

            var context = (HttpApplication)source;
            if (context.Request.Url.AbsolutePath.Contains("/url/"))
            {
                var path = context.Request.Url.AbsolutePath.Remove(0, 1);
                var id = ShortUrlHelper.Decode(path);
                using (var DBcontext = new UrlShortenerContext())
                {
                    var query = from item in DBcontext.ShortUrls
                                where item.Id == id
                                select item.OriginalUrl;

                    var redirectPath = query.FirstOrDefault();
                    if (redirectPath != null) context.Response.Redirect(redirectPath);
                }
            }
        }

    }
}