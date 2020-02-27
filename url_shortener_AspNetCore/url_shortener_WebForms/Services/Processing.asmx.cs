﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using url_shortener_WebForms.App_Start;
using url_shortener_WebForms.Data;
using url_shortener_WebForms.Models;

namespace url_shortener_WebForms.Services
{
    /// <summary>
    /// Summary description for Processing
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Processing : System.Web.Services.WebService
    {

        [WebMethod]
        public AjaxResponseData AddNew(string text)
        {
            var response = new AjaxResponseData();
            if (IsValidUrl(text))
            {
                Uri requestUrl = HttpContext.Current.Request.Url;
                string requesthost = string.Format("{0}{1}{2}{3}",
                    requestUrl.Scheme,
                    Uri.SchemeDelimiter,
                    requestUrl.Authority,
                    "/");
                var entities = new UrlShortenerContext();
                var data = new ShortenedUrl();
                data.OriginalUrl = text;
                entities.ShortUrls.Add(data);
                entities.SaveChanges();
                response.Success = true;
                response.Data = requesthost + data.Id;

            }
            else
            {
                response.Success = false;
                response.Data = "Please enter valid URL";
            }
            return response;
        }
        private bool IsValidUrl(string url)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult);
            return result;
        }
    }
}
