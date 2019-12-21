using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject.PageObjects
{
    class HotelsPage
    {
        private IWebDriver driver;

        public HotelsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@type = 'submit']")]
        IWebElement SearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'form-error-cont']")] //"//h2[@id = 'widget-overlay-title-1']"
        IWebElement ErrorMessage { get; set; }

        [FindsBy(How = How.Name, Using = "q-destination")]
        IWebElement CityDestinationField { get; set; }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://hotels.ebooking.com/");
        }

        public string FindHotelsByDestination(string WrongDestination)
        {
            CityDestinationField.SendKeys(WrongDestination);
            SearchButton.Click();
            return ErrorMessage.Text;
        }
    }
}
