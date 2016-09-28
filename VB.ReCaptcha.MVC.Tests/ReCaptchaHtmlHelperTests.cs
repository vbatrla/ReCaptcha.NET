namespace VB.ReCaptcha.MVC.Tests
{
    using System.IO;
    using System.Web.Mvc;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class ReCaptchaHtmlHelperTests
    {
        [Test]
        public void BuildingReCaptcha_ShouldHaveDivBlock()
        {
            var helper = HtmlHelper();

            var result = ReCaptchaHtmlHelper.ReCaptcha(helper);

            result.ToString()
                .Should().StartWith("<div").And.Contain("</div>");
        }

        [Test]
        public void BuildingReCaptcha_ShouldHaveScriptBlock()
        {
            var helper = HtmlHelper();

            var result = ReCaptchaHtmlHelper.ReCaptcha(helper);

            result.ToString()
                .Should().MatchRegex("<script [a-zA-Z=\\\\\" :\\/\\.]*>").And.Contain("</script>");
        }

        [Test]
        public void BuildingReCaptcha_ShouldHaveClassAndUrl()
        {
            var helper = HtmlHelper();

            var result = ReCaptchaHtmlHelper.ReCaptcha(helper);

            result.ToString()
                .Should().MatchRegex("class=\"g-recaptcha\"").And.Contain("https://www.google.com/recaptcha/api.js");
        }

        private HtmlHelper HtmlHelper()
        {
            var writer = new StringWriter();
            var cc = new ControllerContext();
            return
                new HtmlHelper(
                    new ViewContext(cc, new WebFormView(cc, "PATH"), new ViewDataDictionary(), new TempDataDictionary(), writer),
                    new ViewPage());
        }
    }
}
