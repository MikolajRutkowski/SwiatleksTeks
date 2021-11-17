using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SwitleksTest
{
    public class Tests
    {
        IWebDriver driver1;
          [SetUp]
        public void Setup()
        {
             driver1 = new ChromeDriver();
            driver1.Manage().Window.Position = new System.Drawing.Point(8, 30);
            driver1.Manage().Window.Size = new System.Drawing.Size(1290, 730);

            driver1.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(5);
            driver1.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(5);
        }

        [Test]
        public void Test1()
        {
            driver1.Navigate().GoToUrl("https://presta.bielinski.dev/pl/");
            string  expectedUrl = "https://presta.bielinski.dev/pl/";    // oczekiwany adres strony
            Assert.AreEqual(expectedUrl, driver1.Url, "No to nie nasz sklep mordo");

        }
        [TearDown]
        public void QuitDriver()
        {
            
           // driver1.Quit();
        }
    }
}