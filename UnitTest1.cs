
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;



namespace UIAutomation
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public static void Main(string[] args)

        {
            IWebDriver driver = new ChromeDriver();
           driver.Navigate().GoToUrl("https://www.savethechildren.net/");

            var Login = driver.FindElement(By.XPath("//a[@id='stc-popup-continue'][contains(text(),'Go to the UK site')]"));
            Login.Click();
            var cookies = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
            cookies.Click();
            
            
            
               WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement Searchbtn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("a[class='search-btn']")));
                Searchbtn.Click();


                var Searchbox = driver.FindElement(By.ClassName("search-box"));
                Searchbox.SendKeys("How to Donate");
                
                //SendKeys.SendWait("{ENTER}");
           
            var Donationlink = driver.FindElement(By.XPath("//*[contains(@span,'Donate to Charity Online')]"));
            Donationlink.Click();


            var expected = driver.FindElement(By.XPath("//*[contains(text(),'single-payment tab')]"));
            var actual = driver.FindElement(By.ClassName("single-tab active"));
            Assert.AreEqual(expected, actual);

        }
    }
}
