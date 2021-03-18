using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationPractise.PageObjects
{
    public class PageBase
    {
        public IWebDriver Driver { get; set; }

        private LoginPage loginPage;

        public LoginPage LoginPage => loginPage = loginPage ?? new LoginPage(Driver);

        public PageBase(IWebDriver driver)
        {
            Driver = driver;
        }

        public WebDriverWait Wait(int timeout = 60000) => new WebDriverWait(Driver, TimeSpan.FromMilliseconds(timeout));

        public void WaitForElementToBeClickable(IWebElement element)
        {
            try
            {
                Wait().Until(x => element.Displayed && element.Enabled);
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
        }

        public T GetPageObject<T>()
            where T : PageBase
        {
            return Activator.CreateInstance(typeof(T), new object[] { Driver }) as T;
        }
    }
}
