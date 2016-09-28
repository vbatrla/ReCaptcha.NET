namespace VB.ReCaptcha.MVC
{
    using System.Web.Mvc;

    public static class ReCaptchaHtmlHelper
    {
        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper)
        {
            return ReCaptcha(htmlHelper, string.Empty);
        }

        public static MvcHtmlString ReCaptcha(this HtmlHelper htmlHelper, string language)
        {
            var script = BuildScript(language);

            var widget = BuildWidget();

            return new MvcHtmlString(widget + script);
        }

        private static string BuildWidget()
        {
            var widget = new TagBuilder("div");
            widget.MergeAttribute("class", "g-recaptcha");
            widget.MergeAttribute("data-sitekey", ReCaptchaConfiguration.Instance.SiteKey);
            return widget.ToString(TagRenderMode.Normal);
        }

        private static string BuildScript(string language)
        {
            var script = new TagBuilder("script");

            if (string.IsNullOrEmpty(language))
            {
                script.MergeAttribute("src", "https://www.google.com/recaptcha/api.js");
            }
            else
            {
                script.MergeAttribute("src", "https://www.google.com/recaptcha/api.js?hl=" + language);
            }

            script.MergeAttribute("async", string.Empty);
            script.MergeAttribute("defer", string.Empty);

            return script.ToString(TagRenderMode.Normal);
        }
    }
}