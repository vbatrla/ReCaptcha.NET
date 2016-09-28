namespace VB.ReCaptcha.Core
{
    #region

    using Interfaces;

    #endregion

    public class ReCaptchaConfiguration : IReCaptchaConfiguration
    {
        #region Constants

        private const string GoogleApiUrl = "https://www.google.com/recaptcha/api";

        #endregion

        #region Static Fields

        private static IReCaptchaConfiguration instance = new ReCaptchaConfiguration();

        #endregion

        #region Public Properties

        public static IReCaptchaConfiguration Instance
        {
            get
            {
                return instance;
            }

            internal set
            {
                instance = value;
            }
        }

        public string ApiUrl { get; set; } 

        public string SecretKey { get; set; }

        public string SiteKey { get; set; }

        public IReCaptchaLogger Logger { get; set; }

        #endregion

        #region Public Methods and Operators

        public static void Init()
        {
            Instance.ApiUrl = GoogleApiUrl;
        }

        public static void Init(string secretKey, string siteKey)
        {
            Instance.ApiUrl = GoogleApiUrl;
            Instance.SecretKey = secretKey;
            Instance.SiteKey = siteKey;
        }

        public static void Init(string secretKey, string siteKey, string apirUrl = "")
        {
            Instance.SecretKey = secretKey;
            Instance.SiteKey = siteKey;
            Instance.ApiUrl = !string.IsNullOrEmpty(apirUrl) ? apirUrl : GoogleApiUrl;
        }

        #endregion
    }
}