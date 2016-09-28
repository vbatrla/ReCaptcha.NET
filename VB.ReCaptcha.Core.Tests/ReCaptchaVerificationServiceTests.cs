namespace VB.ReCaptcha.Core.Tests
{
    using Core;
    using Core.Interfaces;
    using NUnit.Framework;

    [TestFixture]
    public class ReCaptchaVerificationServiceTests
    {
        public IReCaptchaVerificationService Service { get; set; }

        [SetUp]
        public void SetupEach()
        {
            ReCaptchaConfiguration.Init("YOUR SECRET", "YOUR SITE KEY");

            this.Service = new ReCaptchaVerificationService();
        }

        [Test]
        public void VerifyEmptySecret_ShouldReturnMissingInputSecret()
        {
            ReCaptchaConfiguration.Init(string.Empty, string.Empty);
            var result = this.Service.Verify(string.Empty);

            CollectionAssert.Contains(result.ErrorCodes, "missing-input-secret");
        }

        [Test]
        public void VerifyInvalidSecret_ShouldReturnInvalidInputSecret()
        {
            ReCaptchaConfiguration.Init("invalidSecret", string.Empty);
            var result = this.Service.Verify(string.Empty);

            CollectionAssert.Contains(result.ErrorCodes, "invalid-input-secret");
        }

        [Test]
        public void VerifyEmptyResponse_ShouldReturnMissingInputResponse()
        {
            var result = this.Service.Verify(string.Empty);

            CollectionAssert.Contains(result.ErrorCodes, "missing-input-response");
        }

        [Test]
        public void VerifyInvalidResponse_ShouldReturnInvalidInputResponse()
        {
            var result = this.Service.Verify("invalidResponse");

            CollectionAssert.Contains(result.ErrorCodes, "invalid-input-response");
        }
    }
}
