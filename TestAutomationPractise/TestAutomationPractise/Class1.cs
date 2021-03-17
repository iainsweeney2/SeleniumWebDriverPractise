﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationPractise
{
    [TestFixture]
    public class Class1
    {
        private IWebDriver driver;

        [Test]
        public void Login_is_on_home_page()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.SauceLabs.com");
        }
    }
}