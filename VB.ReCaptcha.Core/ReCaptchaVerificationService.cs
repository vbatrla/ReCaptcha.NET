namespace VB.ReCaptcha.Core
{
    #region

    using System;
    using System.Net.Http;
    using Core.Interfaces;
    using Newtonsoft.Json;

    #endregion

    public class ReCaptchaVerificationService : IReCaptchaVerificationService, IDisposable
    {
        #region Public Methods and Operators

        public void Dispose()
        {
        }

        public ReCaptchaVerificationResult Verify(string response)
        {
            return this.TryVerify(this.VerificationUrl(response, string.Empty));
        }

        public ReCaptchaVerificationResult Verify(string response, string remoteIp)
        {
            return this.TryVerify(this.VerificationUrl(response, remoteIp));
        }

        #endregion

        #region Methods

        private string AddRemoteIpQueryStringParameter(string url, string remoteIp)
        {
            if (!string.IsNullOrEmpty(remoteIp))
            {
                url = string.Format("{0}&remoteip={1}", url, remoteIp);
            }

            return url;
        }

        private string AddSecretQueryStringParameter(string url)
        {
            if (!string.IsNullOrEmpty(ReCaptchaConfiguration.Instance.SecretKey))
            {
                url = string.Format("{0}&secret={1}", url, ReCaptchaConfiguration.Instance.SecretKey);
            }

            return url;
        }

        private ReCaptchaVerificationResult GetVerificationResult(string url)
        {
            using (var client = new HttpClient())
            using (var response = client.GetAsync(url).Result)
            using (var content = response.Content)
            {
                var result = content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<ReCaptchaVerificationResult>(result);
            }
        }

        private void Log(Exception exception)
        {
            var logger = ReCaptchaConfiguration.Instance.Logger;
            if (logger != null)
            {
                logger.Log(exception);
            }
        }

        private ReCaptchaVerificationResult TryVerify(string url)
        {
            try
            {
                return this.GetVerificationResult(url);
            }
            catch (Exception exception)
            {
                this.Log(exception);
            }

            return null;
        }

        private string VerificationUrl(string response, string remoteIp)
        {
            var url = string.Format(
                "{0}/siteverify?&response={1}", 
                ReCaptchaConfiguration.Instance.ApiUrl, 
                response);

            url = this.AddSecretQueryStringParameter(url);
            url = this.AddRemoteIpQueryStringParameter(url, remoteIp);

            return url;
        }

        #endregion
    }
}
