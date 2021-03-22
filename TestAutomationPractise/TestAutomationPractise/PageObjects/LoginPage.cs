using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationPractise.PageObjects
{
    public class LoginPage : PageBase
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private IWebElement usernameTextBox => Driver.FindElement(By.Id("user-name"));

        private IWebElement passwordTextBox => Driver.FindElement(By.Id("password"));
    }
}
