namespace VB.ReCaptcha.Core.MVC.Tests
{
    using System.Text.RegularExpressions;
    using NUnit.Framework;

    [TestFixture]
    public class ReCaptchaOutputBuilderTests
    {
        [Test]
        public void BuildingReCaptcha_ShouldHaveDivBlock()
        {
            var result = ReCaptchaOutputBuilder.BuildWidget();

            Assert.IsTrue(result.Contains("<div"));
            Assert.IsTrue(result.Contains("</div>"));
        }

        [Test]
        public void BuildingReCaptcha_ShouldHaveScriptBlock()
        {
            var result = ReCaptchaOutputBuilder.BuildScript(string.Empty);

            var isMatch = Regex.Match(result, "<script [a-zA-Z=\\\\\" :\\/\\.]*>");
            Assert.IsTrue(isMatch.Success);
            Assert.IsTrue(result.Contains("</script>"));
        }

        [Test]
        public void BuildingReCaptcha_ShouldHaveClassAndUrl()
        {
            var result = ReCaptchaOutputBuilder.BuildWidget() + ReCaptchaOutputBuilder.BuildScript(string.Empty);

            var isMatch = Regex.Match(result, "class=\"g-recaptcha\"");
            Assert.IsTrue(isMatch.Success);
            Assert.IsTrue(result.Contains("https://www.google.com/recaptcha/api.js"));
        }
    }
}
