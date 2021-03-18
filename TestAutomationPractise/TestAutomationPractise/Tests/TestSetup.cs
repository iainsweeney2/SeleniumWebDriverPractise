using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationPractise.Tests
{
    [SetUpFixture]
    public class TestSetup : TestBase
    {
        private IWebDriver Driver { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Driver = Launch();
        }

        [OneTimeTearDown]
        public void Quit()
        {
            try
            {
                Driver.Close();
                Driver.Quit();
            }
            catch(Exception e)
            {
                Console.WriteLine("Issues encountered closing the driver");
                Console.WriteLine(e);
            }

            TestContext.Progress.Write($"--- Closing browsers for '{TestContext.CurrentContext.Test.ClassName}' ----");
        }
    }
}
