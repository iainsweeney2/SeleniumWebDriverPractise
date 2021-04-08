using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestAutomationPractise.PageObjects;

namespace TestAutomationPractise.Tests.LoginTests
{
    [TestFixture]
    public class LoginTests : TestSetup
    {
        string url = ConfigurationManager.AppSettings["BaseURL"];

        [Test]
        public void LoginPageTitle()
        {
            var page = NavigateToPage<LoginPage>(url);

            string pageTitle = page.PageTitle;

            Assert.IsTrue(pageTitle == "Swag Labs");

        }

        [Test]
        public void LoginWithIncorrectPassword()
        {
            var page = NavigateToPage<LoginPage>(url);
            page
                .EnterUsername("standard_user")
                .EnterPassword("secret_sauce_wrong")
                .ClickLogin()
                .GetErrorButtonVisibility(out bool buttonVisible)
                .GetErrorText(out string errorText);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(buttonVisible);
                Assert.IsTrue(errorText == "Epic sadface: Username and password do not match any user in this service");
            });
        }

        [Test]
        public void LoginWithIncorrectLogin()
        {
            var page = NavigateToPage<LoginPage>(url);
            page
                .EnterUsername("standard_user_wrong")
                .EnterPassword("secret_sauce")
                .ClickLogin()
                .GetErrorButtonVisibility(out bool buttonVisible)
                .GetErrorText(out string errorText);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(buttonVisible);
                Assert.IsTrue(errorText == "Epic sadface: Username and password do not match any user in this service");
            });
        }

        [Test]
        public void LoginWithLockedOutUser()
        {
            var page = NavigateToPage<LoginPage>(url);
            page
                .EnterUsername("locked_out_user")
                .EnterPassword("secret_sauce")
                .ClickLogin()
                .GetErrorButtonVisibility(out bool errorButtonVisible)
                .GetErrorText(out string errorText);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(errorButtonVisible);
                Assert.IsTrue(errorText == "Epic sadface: Sorry, this user has been locked out.");
            });
        }

        [Test]
        public void LoginWithStandardUser()
        {
            var page = NavigateToPage<LoginPage>(url);
            page
                .EnterUsername("standard_user")
                .EnterPassword("secret_sauce")
                .ClickLogin()
                .InventoryPage
                .GetInventoryContainerVisibility(out bool inventoryContainerVisible);


            Assert.Multiple(() =>
            {
                Assert.IsTrue(inventoryContainerVisible);
                ////Assert.IsTrue(errorText == "Epic sadface: Sorry, this user has been locked out.");
            });
        }
    }
}
