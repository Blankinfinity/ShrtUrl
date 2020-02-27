using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace url_shortener_WebForms.App_Start
{
    public class AjaxResponseData
    {
        public bool Success { get; set; }
        public string Data { get; set; }
    }
}