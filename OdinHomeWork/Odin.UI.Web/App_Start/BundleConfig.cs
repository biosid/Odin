using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace Odin.UI.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.css",
                 "~/Content/Site.css"));

            RegisterBaseAngularBundles(bundles);
            RegisterAngularExternalPluginsBundles(bundles);
            RegisterAngularApplicationBundles(bundles);
        }
        private static void RegisterBaseAngularBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/angular.min.js")
                .Include("~/Scripts/angular-touch.min.js")
                .Include("~/Scripts/angular-sanitize.min.js")
                .Include("~/Scripts/angular-route.min.js")
                .Include("~/Scripts/angular-resource.min.js")
                .Include("~/Scripts/angular-parse-ext.min.js")
                .Include("~/Scripts/angular-messages.min.js")
                .Include("~/Scripts/angular-message-format.min.js")
                .Include("~/Scripts/angular-loader.min.js")
                .Include("~/Scripts/angular-cookies.min.js")
                .Include("~/Scripts/angular-aria.min.js")
                .Include("~/Scripts/angular-animate.min.js"));
        }

        private static void RegisterAngularExternalPluginsBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular-plugins")
                .Include("~/Scripts/angular-plugins/angucomplete-alt.min.js")
                .Include("~/Scripts/angular-plugins/angular-base64.js")
                .Include("~/Scripts/angular-plugins/angular-file-upload.js")
                .Include("~/Scripts/angular-plugins/hotkeys.min.js")
                .Include("~/Scripts/angular-plugins/ngDialog.min.js")
                .Include("~/Scripts/angular-plugins/angular-validator.js")
                .Include("~/Scripts/angular-plugins/toastr.js")
                .Include("~/Scripts/angular-plugins/loading-bar.js"));
        }

        private static void RegisterAngularApplicationBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/app")
                //Application
                .Include("~/Scripts/app/app.js")
                //Modules
                .Include("~/Scripts/app/modules/common.core.js")
                .Include("~/Scripts/app/modules/common.ui.js")
                //Services
                .Include("~/Scripts/app/services/apiService.js")
                .Include("~/Scripts/app/services/fileService.js")
                .Include("~/Scripts/app/services/directoryService.js")
                .Include("~/Scripts/app/services/notificationService.js")
                //Controllers
                .Include("~/Scripts/app/home/homeCtrl.js"));
        }

    }
}
