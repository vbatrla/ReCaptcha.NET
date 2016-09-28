namespace VB.ReCaptcha.Core.MVC
{
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    public static class ReCaptchaHtmlHelper
    {
        public static HtmlString ReCaptcha(this HtmlHelper htmlHelper)
        {
            return ReCaptcha(htmlHelper, string.Empty);
        }

        public static HtmlString ReCaptcha(this HtmlHelper htmlHelper, string language)
        {
            var script = ReCaptchaOutputBuilder.BuildScript(language);

            var widget = ReCaptchaOutputBuilder.BuildWidget();

            return new HtmlString(widget + script);
        }
    }
}