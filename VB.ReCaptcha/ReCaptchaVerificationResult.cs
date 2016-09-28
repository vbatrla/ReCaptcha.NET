namespace VB.ReCaptcha
{
    #region

    using System.Collections.Generic;

    using Newtonsoft.Json;

    #endregion

    public class ReCaptchaVerificationResult
    {
        #region Public Properties

        [JsonProperty("error-codes")]
        public IList<string> ErrorCodes { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        #endregion
    }
}