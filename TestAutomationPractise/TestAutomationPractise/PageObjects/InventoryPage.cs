using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationPractise.Models;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationPractise.PageObjects
{
    public class InventoryPage : PageBase
    {
        public InventoryPage(IWebDriver driver) : base(driver) { }

        private IWebElement inventoryContainer => Driver.FindElementWithWait(By.Id("inventory_container"));

        private IList<IWebElement> inventoryList => Driver.FindElements(By.ClassName("inventory_item"));

        private IWebElement filterDropdown => Driver.FindElementWithWait(By.ClassName("product_sort_container"));

        public InventoryPage GetInventoryContainerVisibility(out bool visible)
        {
            visible = inventoryContainer.Displayed;
            return this;
        }

        public InventoryPage GetInventoryListData(out List<ProductListItemModel> data)
        {
            data = new List<ProductListItemModel>();
            foreach (var item in inventoryList)
            {
                var dataItem = new ProductListItemModel();
                string title = item.FindElement(By.ClassName("inventory_item_name")).Text == " " ? null : item.FindElement(By.ClassName("inventory_item_name")).Text;
                string description = item.FindElement(By.ClassName("inventory_item_desc")).Text == " " ? null : item.FindElement(By.ClassName("inventory_item_desc")).Text;
                string price = item.FindElement(By.ClassName("inventory_item_price")).Text == " " ? null : item.FindElement(By.ClassName("inventory_item_price")).Text;
                IWebElement addButton = item.FindElement(By.ClassName("inventory_item_name")) == null ? null : item.FindElement(By.ClassName("inventory_item_name"));
                dataItem.SetProduceListItemTitle(title);
                dataItem.SetProduceListItemDescription(description);
                dataItem.SetProductListItemPrice(price);
                dataItem.SetProductListItemAddButton(addButton);
                data.Add(dataItem);
            }

            return this;
        }

        public InventoryPage SelectFilterOption(string filterOption)
        {
            SelectElement select = new SelectElement(filterDropdown);

            WaitForElementToBeClickable(filterDropdown);
            select.SelectByText(filterOption);
            return this;
        }
    }
}
