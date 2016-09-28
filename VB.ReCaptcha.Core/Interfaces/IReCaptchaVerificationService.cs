namespace VB.ReCaptcha.Core.Interfaces
{
    public interface IReCaptchaVerificationService
    {
        ReCaptchaVerificationResult Verify(string response);

        ReCaptchaVerificationResult Verify(string response, string remoteIp);
    }
}