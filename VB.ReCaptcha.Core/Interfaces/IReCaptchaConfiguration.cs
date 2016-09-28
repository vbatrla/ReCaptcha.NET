namespace VB.ReCaptcha.Core.Interfaces
{
    public interface IReCaptchaConfiguration
    {
        #region Public Properties

        string ApiUrl { get; set; }

        IReCaptchaLogger Logger { get; set; }

        string SecretKey { get; set; }

        string SiteKey { get; set; }

        #endregion
    }
}