using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

        public static IWebElement FindElementWithWait(this IWebDriver driver, By by, int waitTime = 5000)
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

        public static void Click(this IWebDriver driver, IWebElement element, int retryCount = 5)
        {
            Retry(() =>
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
                wait.Until(e => element.Displayed && element.Enabled);
                new Actions(driver).MoveToElement(element).Build().Perform();
            });
            Retry(() => element.Click(), retryCount);
        }

        public static void SendKeys(this IWebElement element, string input, bool clearField)
        {
            element.Click();
            if(clearField)
            {
                element.Clear();
            }
            element.SendKeys(input);

        }
    }
}
