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
            bundles.Add(new ScriptBundle("~/adminLayoutScripts")
                .Include(
                "~/Scripts/Plugins/Jquery/jquery.js",
                "~/Scripts/Plugins/Jquery/bootstrap.min.js",
                "~/Scripts/Plugins/metisMenu/metisMenu.min.js",
                "~/Scripts/Plugins/Theme/sb-admin.js"
                )
                );

            bundles.Add(new StyleBundle("~/adminLayoutStyles")
                .Include(
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/plugins/metisMenu.min.css",
                "~/Content/css/sb-admin.css",
                "~/Content/font-awesome-4.1.0/css/font-awesome.min.css"
                
                )

                );
            BundleTable.EnableOptimizations = true;
        }
    }
}