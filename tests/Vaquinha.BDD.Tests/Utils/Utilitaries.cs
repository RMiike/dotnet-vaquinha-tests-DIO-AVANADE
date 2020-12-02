using OpenQA.Selenium;
using System;

namespace Vaquinha.BDD.Tests.Utils
{
    public class Utilitaries
    {
        public void ScreenShot(IWebDriver webDriver)
        {
            ITakesScreenshot camera = webDriver as ITakesScreenshot;
            Screenshot screenshot = camera.GetScreenshot();
            screenshot.SaveAsFile($"{Guid.NewGuid()}.png");

        }
    }
}
