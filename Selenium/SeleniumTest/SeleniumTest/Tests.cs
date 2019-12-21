using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace SeleniumTest
{
    [TestFixture]
    public class Tests : Browser
    {
        [Test]
        public void SearchWithEmptyDestination()
        {
            const string searchEmptyField = "";

            var searhInputLine = GetWebElementByName("q-destination");
            searhInputLine.SendKeys(searchEmptyField + OpenQA.Selenium.Keys.Enter);
            var errorMessage = GetWebElementByClass("icons icon--alert");
            string errorSearch = errorMessage.Text;

            NUnit.Framework.Assert.AreEqual(" Пожалуйста, введите место назначения для начала поиска. ", errorSearch);
        }
    }
}
