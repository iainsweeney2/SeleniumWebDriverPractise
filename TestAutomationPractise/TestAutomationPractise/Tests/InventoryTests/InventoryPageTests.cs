using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationPractise.Models;
using TestAutomationPractise.PageObjects;

namespace TestAutomationPractise.Tests.InventoryTests
{
    [TestFixture]
    public class InventoryPageTests : TestSetup
    {
        string url = ConfigurationManager.AppSettings["BaseURL"];

        [Test]
        public void InventoryFilterNameDescTest()
        {
            var page = NavigateToPage<LoginPage>(url);

            page
                .EnterUsername("standard_user")
                .EnterPassword("secret_sauce")
                .ClickLogin()
                .InventoryPage
                .GetInventoryListData(data: out var productListItemsUnsorted)
                .SelectFilterOption("Name (Z to A)")
                .GetInventoryListData(data: out var productListItems);

            List<ProductListItemModel> sortedList = productListItemsUnsorted.OrderByDescending(x => x.GetProductListItemTitle()).ToList();

            for (int i = 0; i < sortedList.Count; i++)
            {
                Assert.IsTrue(sortedList[i].GetProductListItemTitle() == productListItems[i].GetProductListItemTitle());
            }
        }
    }
}
