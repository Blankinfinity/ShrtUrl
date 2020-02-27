using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace url_shortener_WebForms
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            Bundle bootstrap = new StyleBundle("~/bundle/Bootstrap")
                                 .Include("~/Content/bootstrap-theme.min.css",
                                          "~/Content/bootstrap.min.css");


            bundles.Add(bootstrap);
        }
    }
}