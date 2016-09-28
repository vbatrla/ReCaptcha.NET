namespace VB.ReCaptcha.Interfaces
{
    using System;

    public interface IReCaptchaLogger
    {
        void Log(Exception exception);
    }
}