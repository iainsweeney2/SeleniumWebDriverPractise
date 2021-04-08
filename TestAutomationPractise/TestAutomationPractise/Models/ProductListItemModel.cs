using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationPractise.Models
{
    public class ProductListItemModel
    {
        private String ProductListItemTitle;
        private String ProductListItemDescription;
        private String ProductListItemPrice;
        private IWebElement ProductListItemAddButton;

        public String GetProductListItemTitle() => ProductListItemTitle;

        public String GetProduceListItemDescrition() => ProductListItemDescription;

        public String GetProductListItemPrice() => ProductListItemPrice;

        public IWebElement GetProductListItemAddButton => ProductListItemAddButton;

        public void SetProduceListItemTitle(String title) => this.ProductListItemTitle = title;

        public void SetProduceListItemDescription(String description) => this.ProductListItemDescription = description;

        public void SetProductListItemPrice(string price) => this.ProductListItemPrice = price;

        public void SetProductListItemAddButton(IWebElement button) => this.ProductListItemAddButton = button;

    }
}
