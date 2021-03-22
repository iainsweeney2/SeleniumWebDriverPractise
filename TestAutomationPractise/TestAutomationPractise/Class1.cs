using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationPractise
{
    public class Class1
    {
        private IWebDriver driver;
        string url = "www.google.com";

        [Test]
        public void Login_is_on_home_page()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
        }
    }
}
