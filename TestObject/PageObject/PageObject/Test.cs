using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageObject.PageObjects;

namespace PageObject
{
    public class Test
    {
        private IWebDriver driver;

        const string EmptyField = "";

        const string WrongDestination = "";

        const string ErrorToFindSearchWrongDestination = "Dinos qué destino, hotel o punto de referencia estás buscando";

        const string ErrorToFindSearchEmptyDestination = "Пожалуйста, введите место назначения для начала поиска.";

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void SearchWithWrongDestination()
        {
            HotelsPage hotels = new HotelsPage(driver);
            hotels.GoToPage();
            Assert.AreEqual(hotels.FindHotelsByDestination(WrongDestination), ErrorToFindSearchWrongDestination);
        }

        [Test]
        public void SearchEmptyDestination()
        {
            HomePage homeTest = new HomePage(driver);
            homeTest.GoToPage();
            Assert.AreEqual(homeTest.FindHotelsByDestination(EmptyField), ErrorToFindSearchEmptyDestination);
        }

        [TearDown] 
        public void TearDown()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
