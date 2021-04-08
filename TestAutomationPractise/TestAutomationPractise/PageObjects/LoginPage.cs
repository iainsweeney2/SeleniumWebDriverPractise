using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationPractise.PageObjects;

namespace TestAutomationPractise.PageObjects
{
    public class LoginPage : PageBase
    {
        private InventoryPage inventoryPage;

        public LoginPage(IWebDriver driver) : base(driver) { }

        private IWebElement usernameTextBox => Driver.FindElementWithWait(By.Id("user-name"));

        private IWebElement passwordTextBox => Driver.FindElementWithWait(By.Id("password"));

        private IWebElement loginButton => Driver.FindElementWithWait(By.Id("login-button"));

        private IWebElement errorButton => Driver.FindElementWithWait(By.ClassName("error-button"));

        private IWebElement errorTextElement => Driver.FindElementWithWait(By.XPath("//*[@data-test ='error']"));

        public InventoryPage InventoryPage => inventoryPage = inventoryPage ?? new InventoryPage(Driver);

        public LoginPage EnterUsername(string username)
        {
            usernameTextBox.SendKeys(username, true);
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            passwordTextBox.SendKeys(password, true);
            return this;
        }

        public LoginPage ClickLogin()
        {
            SeleniumExtensions.Click(Driver, loginButton);
            return this;
        }

        public LoginPage GetErrorButtonVisibility(out bool errorButtonVisible)
        {
            errorButtonVisible = errorButton.Displayed;
            return this;
        }

        public LoginPage GetErrorText(out string errorText)
        {
            errorText = errorTextElement.Text.ToString();
            return this;
        }
    }
}
