using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ETicaret.Ui.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;
            bundles.Add(new ScriptBundle("~/adminLayoutScripts")
                .Include(
                "~/Scripts/Plugins/Jquery/jquery-2.1.3.min.js",
                "~/Scripts/Plugins/Jquery/bootstrap.min.js",
                "~/Scripts/Plugins/metisMenu/metisMenu.min.js",
                "~/Scripts/Theme/sb-admin-2.js"
                ));

            bundles.Add(new ScriptBundle("~/formScripts").Include(
                "~/Scripts/Plugins/Jquery/jquery.validate.min.js",
                "~/Scripts/Plugins/Jquery/jquery.validate.unobtrusive.min.js",
                "~/Scripts/Plugins/Jquery/jquery.form.min.js"
                , "~/Scripts/Custom/FormIslemleri.js"
                ));

            bundles.Add(new StyleBundle("~/adminLayoutStyles").Include(
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/plugins/metisMenu.min.css",
                "~/Content/css/sb-admin-2.css",
                "~/Content/font-awesome-4.1.0/css/font-awesome.min.css"
                ));

            bundles.Add(new ScriptBundle("~/kategoriSiralaScripts")
                .Include("~/Scripts/Custom/YonetimKategori/SiralamaIslemleri.js")
                );       
        }
    }
}