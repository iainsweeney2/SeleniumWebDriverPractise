using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationPractise.PageObjects;

namespace TestAutomationPractise.Tests
{
    public class TestBase
    {
        private IWebDriver Driver { get; set; }

        public IWebDriver Launch()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            Driver = new ChromeDriver(options);

            return Driver;
        }

        private void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        protected T NavigateToPage<T>(string url)
            where T : PageBase
        {
            var page = new PageBase(Driver);
            Navigate(url);
            return page.GetPageObject<T>() as T;
        }
    }
}
