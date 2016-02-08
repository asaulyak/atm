using System.Web;
using System.Web.Optimization;

namespace ATM_App
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                       "~/Public/app/bower_components/angular/angular.min.js",
                       "~/Public/app/bower_components/angular-route/angular-route.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                       "~/Public/app/bower_components/html5-boilerplate/dist/js/vendor/modernizr-2.8.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include(
                 "~/Public/app/js/app.js",
                 "~/Public/app/js/filters/cardNumber.js",
                 "~/Public/app/js/directives/cardNumberFormat.js",
                 "~/Public/app/js/directives/currencyFormat.js",
                 "~/Public/app/js/services/formatter.js",
                 "~/Public/app/js/services/cardsService.js",
                 "~/Public/app/js/services/keyboard.js",
                 "~/Public/app/js/services/operationsService.js",
                 "~/Public/app/js/services/errorService.js",
                 "~/Public/app/js/controllers/homeController.js",
                 "~/Public/app/js/controllers/creditCardController.js",
                 "~/Public/app/js/controllers/pinController.js",
                 "~/Public/app/js/controllers/keyboardController.js",
                 "~/Public/app/js/controllers/operationsController.js",
                 "~/Public/app/js/controllers/balanceController.js",
                 "~/Public/app/js/controllers/withdrawController.js",
                 "~/Public/app/js/controllers/withdrawReportController.js",
                 "~/Public/app/js/controllers/errorController.js",
                 "~/Public/app/js/controllers/sessionController.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                     "~/Public/app/bower_components/html5-boilerplate/dist/css/normalize.css",
                     "~/Public/app/bower_components/html5-boilerplate/dist/css/main.css",
                     "~/Public/app/bower_components/semantic/dist/semantic.min.css",
                     "~/Public/app/css/styles.css"
                     ));



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
                      "~/Content/site.css"));
        }
    }
}
