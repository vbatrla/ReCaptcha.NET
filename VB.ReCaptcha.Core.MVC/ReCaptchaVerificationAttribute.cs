namespace VB.ReCaptcha.Core.MVC
{
    #region

    using Core;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    #endregion

    public class ReCaptchaVerificationAttribute : ActionFilterAttribute
    {
        #region Constants

        private const string ModelStateErrorKey = "ReCaptcha";

        private const string TempDataErrorKey = "ReCaptchaErrors";

        #endregion

        #region Public Properties

        public bool WithRemoteIp { get; set; }

        #endregion

        #region Public Methods and Operators

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var result = this.GetVerificationResult(filterContext);

            if (!result.Success)
            {
                this.SetModelStateToInvalid(filterContext);

                this.AddErrorsToTempData(filterContext, result);
            }

            base.OnActionExecuting(filterContext);
        }

        #endregion

        #region Methods

        private void AddErrorsToTempData(ActionExecutingContext filterContext, ReCaptchaVerificationResult result)
        {
            var tempData = ((Controller)filterContext.Controller).TempData;
            if (tempData.ContainsKey(TempDataErrorKey))
            {
                tempData[TempDataErrorKey] = result.ErrorCodes;
            }
            else
            {
                tempData.Add(TempDataErrorKey, result.ErrorCodes);
            }
        }

        private ReCaptchaVerificationResult GetVerificationResult(ActionExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Request.Form["g-recaptcha-response"];
            var remoteIp = filterContext.HttpContext.Request.Host.Host;

            using (var service = new ReCaptchaVerificationService())
            {
                if (this.WithRemoteIp)
                {
                    return service.Verify(response, remoteIp);
                }

                return service.Verify(response);
            }
        }

        private void SetModelStateToInvalid(ActionExecutingContext filterContext)
        {
            var modelState = ((Controller)filterContext.Controller).ViewData.ModelState;

            if (!modelState.ContainsKey(ModelStateErrorKey))
            {
                modelState.AddModelError(ModelStateErrorKey, "Verification failed");
            }
        }

        #endregion
    }
}
