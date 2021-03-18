using NUnit.Framework;
using System;
using System.Collections.Generic;
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
        [Test]
        public void LoginPageTitle()
        {
            NavigateToPage<LoginPage>("https://www.saucedemo.com");

            Thread.Sleep(5000);

        }
    }
}
