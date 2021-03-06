﻿using System.Web;
using System.Web.Optimization;

namespace _360Accounting.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            ////bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            ////            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/js/jquery.js",
                        "~/Scripts/js/jquery-ui.js",
                        "~/Scripts/jquery.smartmenus.min.js",
                        "~/Scripts/jquery.smartmenus.bootstrap.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-multiselect.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-multiselect.css",
                      "~/Content/style.css",
                      "~/Content/jquery-ui.css",
                      "~/font-awesome/css/font-awesome.min.css",
                      "~/awesome-bootstrap-checkbox.css",
                      "~/Content/jquery.smartmenus.bootstrap.css",
                      "~/Content/sm-core-css.css",
                      "~/Content/sm-simple.css"
                      ));
        }
    }
}
