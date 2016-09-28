namespace VB.ReCaptcha.Core.MVC
{
    using System.IO;
    using System.Text.Encodings.Web;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class ReCaptchaOutputBuilder
    {
        public static string BuildWidget()
        {
            using (var stringWriter = new StringWriter())
            {
                var widget = new TagBuilder("div");
                widget.MergeAttribute("class", "g-recaptcha");
                widget.MergeAttribute("data-sitekey", ReCaptchaConfiguration.Instance.SiteKey);
                widget.TagRenderMode = TagRenderMode.Normal;
                widget.WriteTo(stringWriter, HtmlEncoder.Default);
                return stringWriter.ToString();
            }
        }

        public static string BuildScript(string language)
        {
            using (var stringWriter = new StringWriter())
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
                script.TagRenderMode = TagRenderMode.Normal;
                script.WriteTo(stringWriter, HtmlEncoder.Default);

                return stringWriter.ToString();
            }
        }
    }
}