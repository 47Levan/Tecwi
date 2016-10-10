using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
namespace BookShop.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundleCollection)
        {
            bundleCollection.Add(new ScriptBundle("~/bundles/BasicScripts")
            .Include("~/Scripts/jquery-3.1.1.min.js"
                , "~/Scripts/jquery.unobtrusive-ajax.min.js", "~/Scripts/bootstrap.min"
                , "~/Scripts/jquery-ui-1.12.1.min.js"));
            bundleCollection.Add(new StyleBundle("~/bundles/BasicStyles")
           .Include("~/Content/Site.css"
               , "~/Content/bootstrap.css", "~/Content/PagedList.css", "~/Content/themes/base/jquery-ui.min.css"));
        }
    }
}