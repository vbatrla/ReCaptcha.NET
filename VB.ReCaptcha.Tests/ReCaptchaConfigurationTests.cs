namespace VB.ReCaptcha.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ReCaptchaConfigurationTests
    {
        private string secretKey = "SECRET_KEY";
        private string siteKey = "SITE_KEY";
        
        [Test]
        public void NewlyCreatedconfigurationInstance_ShoudBeCreated()
        {
            Assert.That(ReCaptchaConfiguration.Instance, Is.TypeOf<ReCaptchaConfiguration>());
        }

        [Test]
        public void InitWithDefaultApiUrl_IsMatching()
        {
            ReCaptchaConfiguration.Init();

            Assert.AreSame("https://www.google.com/recaptcha/api", ReCaptchaConfiguration.Instance.ApiUrl);
        }

        [Test]
        public void InitWithSecretAndSiteKey_IsMatching()
        {
            ReCaptchaConfiguration.Init(secretKey, siteKey);

            AssertsSecretAndSiteKey();
        }

        [Test]
        public void InitWithApiKeyAndSiteKeyAndApiUrl_IsMatching()
        {
            var apiUrl = "API_URL";
            ReCaptchaConfiguration.Init(secretKey, siteKey, apiUrl);

            AssertsSecretAndSiteKey();
            Assert.AreSame(apiUrl, ReCaptchaConfiguration.Instance.ApiUrl);
        }

        private void AssertsSecretAndSiteKey()
        {
            Assert.AreSame(secretKey, ReCaptchaConfiguration.Instance.SecretKey);
            Assert.AreSame(siteKey, ReCaptchaConfiguration.Instance.SiteKey);
        }
    }
}