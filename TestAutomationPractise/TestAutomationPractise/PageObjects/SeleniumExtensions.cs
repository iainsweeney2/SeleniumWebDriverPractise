using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationPractise.PageObjects
{
    public static class SeleniumExtensions
    {
        public static void Retry(Action actions, int retryCount = 5)
        {
            for (int counter =1; counter <= retryCount; counter++)
            {
                try
                {
                    actions();
                    break;
                }
                catch (Exception ex)
                {
                    if (counter == retryCount)
                        throw;

                    TestContext.Progress.WriteLine(ex.Message + " : Going to retry the same action");
                }
            }
        }

        public static IWebElement FindElementWithRetry(this IWebDriver driver, By by, int waitTime = 5000)
        {
            try
            {
                return new WebDriverWait(driver, TimeSpan.FromMilliseconds(waitTime)).Until(e => e.FindElement(by));
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return null;
        }
    }
}
