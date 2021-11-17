using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

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
            driver1.Manage().Window.Size = new System.Drawing.Size(1500, 1000);

            driver1.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(5);
            driver1.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(5);
        }
       // [Test]
        public void Test1()
        {
            Uri sklepUrl = new Uri("https://presta.bielinski.dev/pl/");
            driver1.Navigate().GoToUrl(sklepUrl);
            string expectedUrl = "https://presta.bielinski.dev/pl/";    // oczekiwany adres strony
            Assert.AreEqual(expectedUrl, driver1.Url, "No to nie nasz sklep mordo");

            // czego szukamy
            IWebElement lampy1 = driver1.FindElement(By.LinkText("LAMPY"));

            lampy1.Click();

            Uri sklepLampy = new Uri("https://presta.bielinski.dev/pl/6-lampy");
            Assert.AreEqual(sklepLampy, driver1.Url, "TO NIE LAMPY");


        }
       // [Test]
        public void Test2()
        {
            Uri sklepUrl = new Uri("https://presta.bielinski.dev/pl/");
            driver1.Navigate().GoToUrl(sklepUrl);

            IWebElement LogIn = driver1.FindElement(By.LinkText("Kontakt z nami"));

            LogIn.Click();

        }




        /* [Test]
         public void Test1()
         {
             Uri sklepUrl = new Uri("https://presta.bielinski.dev/pl/");
             driver1.Navigate().GoToUrl(sklepUrl);
             string  expectedUrl = "https://presta.bielinski.dev/pl/";    // oczekiwany adres strony
             Assert.AreEqual(expectedUrl, driver1.Url, "No to nie nasz sklep mordo");

         }
         [Test]
         public void TestBack()
         {
             Uri sklepUrl = new Uri("https://presta.bielinski.dev/pl/");
             driver1.Navigate().GoToUrl(sklepUrl);
             driver1.Navigate().GoToUrl("https://www.google.pl/");
             driver1.Navigate().Back();
             string expectedUrl = "https://presta.bielinski.dev/pl/";    // oczekiwany adres strony
             Assert.AreEqual(expectedUrl, driver1.Url, "No to nie nasz sklep mordo");


         }
         [Test]
         public void Testrefresh()
         {
             Uri sklepUrl = new Uri("https://presta.bielinski.dev/pl/");
             driver1.Navigate().GoToUrl(sklepUrl);
             driver1.Navigate().Refresh();
             Thread.Sleep(5000);
             driver1.Navigate().Refresh();

         }
        */
        [TearDown]
        public void QuitDriver()
        {
            Thread.Sleep(1000);
            driver1.Quit();
        }
    }
}