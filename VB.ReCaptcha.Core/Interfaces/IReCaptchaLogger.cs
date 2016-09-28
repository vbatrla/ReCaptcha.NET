namespace VB.ReCaptcha.Core.Interfaces
{
    using System;

    public interface IReCaptchaLogger
    {
        void Log(Exception exception);
    }
}