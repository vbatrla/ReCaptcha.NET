namespace VB.ReCaptcha.Interfaces
{
    public interface IReCaptchaVerificationService
    {
        ReCaptchaVerificationResult Verify(string response);

        ReCaptchaVerificationResult Verify(string response, string remoteIp);
    }
}