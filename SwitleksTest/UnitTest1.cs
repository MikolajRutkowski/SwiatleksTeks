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

            var rand = new Random();

            int x = rand.Next(1000, 100000);
            abc = abc + x.ToString();
            abc = abc + "@gmail.com";
            

            return abc;
        }
       public void addProduct(int x , IWebDriver driver)
        {
            IWebElement button = driver.FindElement(By.ClassName("add"));
           
            IWebElement more = driver1.FindElement(By.ClassName("bootstrap-touchspin-up"));
            for (int i = 1; i < x; i++)
            {
                more.Click();
            }
             button.Click();
            Thread.Sleep(1000);
            driver1.Navigate().Back();
        }
        IWebDriver driver1;
          [SetUp]
        public void Setup()
        {
            driver1 = new ChromeDriver();
            driver1.Manage().Window.Position = new System.Drawing.Point(8, 30);
            driver1.Manage().Window.Size = new System.Drawing.Size(1500, 1000);

            driver1.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(25);
            driver1.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(25);
        }
        [Test]
        public void MainTest()
        {
            Uri sklepUrl = new Uri("https://presta.bielinski.dev/pl/");
            driver1.Navigate().GoToUrl(sklepUrl);
            string expectedUrl = "https://presta.bielinski.dev/pl/";    // oczekiwany adres strony
            Assert.AreEqual(expectedUrl, driver1.Url, "No to nie nasz sklep mordo");

            // kategoria pierwsza 
            {
                IWebElement lampy1 = driver1.FindElement(By.LinkText("LAMPY"));
                lampy1.Click();

                IWebElement product = driver1.FindElement(By.CssSelector("[data-id-product='102']"));
                product.Click();

                addProduct(1, driver1);


                product = driver1.FindElement(By.CssSelector("[data-id-product='103']"));
                product.Click();

                addProduct(2, driver1);
            

                product = driver1.FindElement(By.CssSelector("[data-id-product='101']"));
                product.Click();

                addProduct(3, driver1);

                product = driver1.FindElement(By.CssSelector("[data-id-product='111']"));
                product.Click();

                addProduct(5, driver1);

                product = driver1.FindElement(By.CssSelector("[data-id-product='107']"));
                product.Click();

                addProduct(20, driver1);
            }
            // kategoria druga
            {
                IWebElement zarowki = driver1.FindElement(By.LinkText("¯ARÓWKI LED"));
                zarowki.Click();

                IWebElement product = driver1.FindElement(By.CssSelector("[data-id-product='29']"));
                product.Click();

                addProduct(10, driver1);

                product = driver1.FindElement(By.CssSelector("[data-id-product='31']"));
                product.Click();

                addProduct(2, driver1);

                product = driver1.FindElement(By.CssSelector("[data-id-product='28']"));
                product.Click();

                addProduct(2, driver1);

                product = driver1.FindElement(By.CssSelector("[data-id-product='34']"));
                product.Click();

                addProduct(5, driver1);

                product = driver1.FindElement(By.CssSelector("[data-id-product='37']"));
                product.Click();

                addProduct(20, driver1); 
                           
            }
           

            IWebElement bascet = driver1.FindElement(By.ClassName("shopping-cart"));
            bascet.Click();

            IWebElement delete = driver1.FindElement(By.ClassName("remove-from-cart"));
            delete.Click();

            IWebElement next = driver1.FindElement(By.ClassName("cart-detailed-actions"));
            next.Click();

            IWebElement sex = driver1.FindElement(By.Id("field-id_gender-1"));
            sex.Click();

            IWebElement name = driver1.FindElement(By.Id("field-firstname"));
            name.SendKeys("Jarek");

            IWebElement sername = driver1.FindElement(By.Id("field-lastname"));
            sername.SendKeys("Pieczarek");

            IWebElement email = driver1.FindElement(By.Id("field-email"));
            email.SendKeys(loto()) ;

            IWebElement pasword = driver1.FindElement(By.Id("field-password"));
            pasword.SendKeys("Test1234");

            IWebElement date = driver1.FindElement(By.Id("field-birthday"));
            date.SendKeys("1999-02-11");

            IWebElement one = driver1.FindElement(By.Name("optin"));
            one.Click();

            IWebElement two = driver1.FindElement(By.Name("customer_privacy"));
            two.Click();

            IWebElement three = driver1.FindElement(By.Name("newsletter"));
            three.Click();

            IWebElement four = driver1.FindElement(By.Name("psgdpr"));
            four.Click();

            Thread.Sleep(300);

            IWebElement continuee = driver1.FindElement(By.Name("continue"));
            continuee.Click();

            IWebElement adres = driver1.FindElement(By.Id("field-address1"));
            adres.SendKeys("kapelanów 44");

            IWebElement code = driver1.FindElement(By.Id("field-postcode"));
            code.SendKeys("21-370");

            IWebElement city = driver1.FindElement(By.Id("field-city"));
            city.SendKeys("Borki-Kosiorki");

            IWebElement phone = driver1.FindElement(By.Id("field-phone"));
            phone.SendKeys("147258369");

            IWebElement continue2 = driver1.FindElement(By.Name("confirm-addresses"));
            continue2.Click();
            IWebElement continue3 = driver1.FindElement(By.Name("confirmDeliveryOption"));
            continue3.Click();
            IWebElement pay = driver1.FindElement(By.Id("payment-option-2"));
            pay.Click();
            IWebElement ok = driver1.FindElement(By.Id("conditions_to_approve[terms-and-conditions]"));
            ok.Click();
            IWebElement pay2 = driver1.FindElement(By.Id("payment-option-1"));
            pay2.Click();
            pay.Click();


            //btn btn-primary center-block
            IWebElement confirm = driver1.FindElement(By.XPath("/html/body/main/section/div/div/section/div/div[1]/section[4]/div/div[3]/div[1]/button"));
           confirm.Click();






        }

        
       // [Test]
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



        //  [Test]
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