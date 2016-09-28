namespace VB.ReCaptcha.Core.MVC
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("ReCaptcha")]
    public class ReCaptchaTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            var script = ReCaptchaOutputBuilder.BuildScript(output.Content.GetContent());

            var widget = ReCaptchaOutputBuilder.BuildWidget();

            output.Content.SetHtmlContent(widget + script);
        }
    }
}