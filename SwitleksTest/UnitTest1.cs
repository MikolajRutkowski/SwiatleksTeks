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
        public String loto()
        {
            string abc = "abc";
            return abc;
        }
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


        
        [Test]
        public void TestBuing()
        {
            Uri sklepUrl = new Uri("https://presta.bielinski.dev/pl/");
            driver1.Navigate().GoToUrl(sklepUrl);
            IWebElement search = driver1.FindElement(By.Name("s"));
            search.SendKeys(loto());
            search.Submit();

            IWebElement product = driver1.FindElement(By.CssSelector("[data-id-product-attribute='0']"));
            product.Click();

            IWebElement button = driver1.FindElement(By.ClassName("add"));
            button.Click();

            IWebElement next = driver1.FindElement(By.ClassName("cart-content-btn"));
            next.Click();
           
            search = driver1.FindElement(By.Name("s"));
            search.SendKeys("lampa");
            search.Submit();
           

             product = driver1.FindElement(By.CssSelector("[data-id-product-attribute='0']"));
            product.Click();

           button = driver1.FindElement(By.ClassName("add"));
            button.Click();

             next = driver1.FindElement(By.ClassName("cart-content-btn"));
            next.Click();
           
        }



          [Test]
        public void TestMessageToSupport()
        {
            Uri sklepUrl = new Uri("https://presta.bielinski.dev/pl/");
            driver1.Navigate().GoToUrl(sklepUrl);

            IWebElement LogIn = driver1.FindElement(By.LinkText("Kontakt z nami"));

           LogIn.Click();

            IWebElement YourEmail = driver1.FindElement(By.Id("email"));
            YourEmail.SendKeys("mikolaj99x@gmail.com");
            IWebElement text = driver1.FindElement(By.Name("message"));
            text.SendKeys(loto());

            IWebElement button = driver1.FindElement(By.Name("submitMessage"));
            button.Click();
            //szukanie po tekscie
            IWebElement correct = driver1.FindElement(By.XPath("//*[contains(text(), 'Twoja wiadomoœæ zosta³a pomyœlnie wys³ana do obs³ugi.')]")); 
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
          //  driver1.Quit();
        }
    }
}