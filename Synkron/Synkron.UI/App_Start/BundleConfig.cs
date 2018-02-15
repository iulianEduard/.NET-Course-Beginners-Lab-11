using System.Web;
using System.Web.Optimization;

namespace Synkron.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/velocity").Include(
                        "~/Scripts/velocity.js"));

            bundles.Add(new ScriptBundle("~/bundles/hammer").Include(
                        "~/Scripts/hammer.js"));

            bundles.Add(new ScriptBundle("~/bundles/muri").Include(
                        "~/Scripts/muri.js"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                        "~/Scripts/common.js"));

            bundles.Add(new ScriptBundle("~/bundles/taskManageEdit").Include(
                        "~/Scripts/TaskManage/taskManageEdit.js"));

            bundles.Add(new ScriptBundle("~/bundles/taskManage").Include(
                        "~/Scripts/TaskManage/taskManage.js"));

            bundles.Add(new ScriptBundle("~/bundles/task").Include(
                        "~/Scripts/Task/taskEdit.js"));

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
