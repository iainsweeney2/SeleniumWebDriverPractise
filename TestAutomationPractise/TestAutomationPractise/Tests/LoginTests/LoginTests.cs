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
                .GetErrorButtonVisibility(out bool buttonVisible);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(buttonVisible);
            });
        }
    }
}
