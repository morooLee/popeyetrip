using System.Web.Optimization;

namespace PopEyeTrip
{
    public class BundleConfig
    {
        // 번들 작성에 대한 자세한 내용은 http://go.microsoft.com/fwlink/?LinkId=301862 링크를 참조하십시오.
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery-2.1.4.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.bootstrap.js",
                        "~/Scripts/jquery.placeholder.js",
                        "~/Scripts/validator.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            // Modernizr의 개발 버전을 사용하여 개발하고 배우십시오. 그런 다음
            // 프로덕션할 준비가 되면 http://modernizr.com 링크의 빌드 도구를 사용하여 필요한 테스트만 선택하십시오.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/popeyetrip.js"));

            bundles.Add(new ScriptBundle("~/bundles/poploading").Include(
                       "~/Scripts/jquery.poploading.js"));

            bundles.Add(new ScriptBundle("~/bundles/imagesloaded").Include(
                       "~/Scripts/imagesloaded.pkgd.js"));

            bundles.Add(new ScriptBundle("~/bundles/lightslider").Include(
                       "~/Scripts/lightslider.js"));

            bundles.Add(new StyleBundle("~/Content/lightslider").Include(
                      "~/Content/lightslider.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                       "~/Scripts/jquery-ui.js"));

            bundles.Add(new StyleBundle("~/Content/jquery-ui").Include(
                      "~/Content/jquery-ui.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/popeyetrip.css",
                      "~/Content/bootstrap-social.css",
                      "~/Content/font-awesome.css"));

            bundles.Add(new ScriptBundle("~/bundles/summernote").Include(
                      "~/Scripts/summernote.js",
                      "~/Scripts/SummerNoteLang/summernote-ko-KR.js",
                      "~/Scripts/SummerNoteLang/summernote-zh-CN.js",
                      "~/Scripts/SummerNoteLang/summernote-ja-JP.js"));

            bundles.Add(new StyleBundle("~/Content/summernote").Include(
                      "~/Content/summernote.css"));

            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                      "~/Scripts/select2.full.js",
                      "~/Scripts/Select2Lang/ko.js",
                      "~/Scripts/Select2Lang/en.js",
                      "~/Scripts/Select2Lang/zh-CN.js",
                      "~/Scripts/Select2Lang/ja.js"));

            bundles.Add(new StyleBundle("~/Content/select2").Include(
                      "~/Content/select2.css"));

            bundles.Add(new ScriptBundle("~/bundles/lightgallery").Include(
                      "~/Scripts/lightgallery.js",
                      "~/Scripts/lg-fullscreen.js",
                      "~/Scripts/lg-thumbnail.js"));

            bundles.Add(new StyleBundle("~/Content/lightgallery").Include(
                      "~/Content/lightgallery.css"));
        }
    }
}