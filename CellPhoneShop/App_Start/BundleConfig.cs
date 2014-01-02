using System.Web;
using System.Web.Optimization;

namespace CellPhoneShop
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-mobilemenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-1.10.3.js",
                        "~/Scripts/jquery.ui.datepicker-vi.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/myscript").Include(
                        "~/Scripts/amazingslider.js",
                        "~/Scripts/initslider-1.js",
                        "~/Scripts/mustache.js",
                        "~/Scripts/custom.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminscript").Include(
                        "~/Scripts/admin/jquery-1.7.2.js",
                        "~/Scripts/admin/jquery-ui-1.8.21.custom.js",
                        "~/Scripts/admin/bootstrap-transition.js",
                        "~/Scripts/admin/bootstrap-alert.js",
                        "~/Scripts/admin/bootstrap-modal.js",
                        "~/Scripts/admin/bootstrap-dropdown.js",
                        "~/Scripts/admin/bootstrap-scrollspy.js",
                        "~/Scripts/admin/bootstrap-tab.js",
                        "~/Scripts/admin/bootstrap-tooltip.js",
                        "~/Scripts/admin/bootstrap-popover.js",
                        "~/Scripts/admin/bootstrap-button.js",
                        "~/Scripts/admin/bootstrap-collapse.js",
                        "~/Scripts/admin/bootstrap-carousel.js",
                        "~/Scripts/admin/bootstrap-typeahead.js",
                        "~/Scripts/admin/bootstrap-tour.js",
                        "~/Scripts/admin/jquery.cookie.js",
                        "~/Scripts/admin/fullcalendar.js",
                        "~/Scripts/admin/jquery.dataTables.js",
                        "~/Scripts/admin/excanvas.js",
                        "~/Scripts/admin/jquery.flot.js",
                        "~/Scripts/admin/jquery.flot.pie.js",
                        "~/Scripts/admin/jquery.flot.stack.js",
                        "~/Scripts/admin/jquery.flot.resize.js",
                        "~/Scripts/admin/jquery.chosen.js",
                        "~/Scripts/admin/jquery.uniform.js",
                        "~/Scripts/admin/jquery.colorbox.js",
                        "~/Scripts/admin/jquery.cleditor.js",
                        "~/Scripts/admin/jquery.noty.js",
                        "~/Scripts/admin/jquery.elfinder.js",
                        "~/Scripts/admin/jquery.raty.js",
                        "~/Scripts/admin/jquery.iphone.toggle.js",
                        "~/Scripts/admin/jquery.autogrow-textarea.js",
                        "~/Scripts/admin/jquery.uploadify-3.1.js",
                        "~/Scripts/admin/jquery.history.js",
                        "~/Scripts/admin/charisma.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/themes/MyTheme/main.css",
                "~/Content/themes/MyTheme/mediaqueries.css",
                "~/Content/themes/MyTheme/skin.css",
                "~/Content/themes/MyTheme/mystype.css",
                "~/Content/zocial.css"));

            bundles.Add(new StyleBundle("~/JqueryUi/css").Include(
                "~/Content/themes/base/jquery.ui.all.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css"));

            bundles.Add(new StyleBundle("~/Content/admin/css/").Include(
                "~/Content/themes/MyTheme/admin/bootstrap-cerulean.css",
                "~/Content/themes/MyTheme/admin/bootstrap-responsive.css",
                "~/Content/themes/MyTheme/admin/charisma-app.css",
                "~/Content/themes/MyTheme/admin/jquery-ui-1.8.21.custom.css",
                "~/Content/themes/MyTheme/admin/fullcalendar.css",
                "~/Content/themes/MyTheme/admin/fullcalendar.print.css",
                "~/Content/themes/MyTheme/admin/chosen.css",
                "~/Content/themes/MyTheme/admin/uniform.default.css",
                "~/Content/themes/MyTheme/admin/colorbox.css",
                "~/Content/themes/MyTheme/admin/jquery.cleditor.css",
                "~/Content/themes/MyTheme/admin/jquery.noty.css",
                "~/Content/themes/MyTheme/admin/noty_theme_default.css",
                "~/Content/themes/MyTheme/admin/elfinder.css",
                "~/Content/themes/MyTheme/admin/elfinder.theme.css",
                "~/Content/themes/MyTheme/admin/jquery.iphone.toggle.css",
                "~/Content/themes/MyTheme/admin/opa-icons.css",
                "~/Content/themes/MyTheme/admin/uploadify.css",
                "~/Content/themes/MyTheme/admin/validation-styles.css",
                "~/Content/themes/MyTheme/admin/adminstyle.css"));
        }
    }
}