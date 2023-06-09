using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using Telerik.JustMock;

namespace UIAutomation
{
    [Binding]
    public class UIAutomationOfSaveTheChildrenInternationalSiteSteps
    {


        IWebDriver driver = new ChromeDriver();

        [Given(@"User is at Home Page")]
        public void GivenUserIsAtHomePage()
        {

            
            driver.Navigate().GoToUrl("https://www.savethechildren.net/");
        }

        [Given(@"Go To The UK Site Button Should Be Visible")]
        public void GivenGoToTheUKSiteButtonShouldBeVisible()
        {
           
            IWebElement Login = driver.FindElement(By.XPath("//a[@id='stc-popup-continue'][contains(text(),'Go to the UK site')]"));

        }

        [When(@"I Click on Go To UK Site Button")]
        public void WhenIClickOnGoToUKSiteButton()
        {
            IWebElement Login = driver.FindElement(By.XPath("//a[@id='stc-popup-continue'][contains(text(),'Go to the UK site')]"));
            Login.Click();
            IWebElement cookies = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
            cookies.Click();
        }

        [Then(@"User should be on Search Page")]

        public void ThenUsershouldbeonSearchPage()
        {
            IWebElement searchbtn = driver.FindElement(By.CssSelector("a[class='search-btn']"));
            searchbtn.getText();
        }

        [When(@"I click on Search Button")]
        public void WhenIClickOnSearchButton()

        {
            var wait = new WebDriverWait(driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[class='search-btn']"))).Click();

        }

        [Then(@"Searchtexbox should be enabled and User is able to write search text and Submit")]
        public void ThenSearchtexboxShouldBeEnabledAndUserIsAbleToWriteSearchTextAndSubmit()
        {
            IWebElement Searchbox = driver.FindElement(By.ClassName("search-box"));
            Searchbox.SendKeys("How to Donate");
        }

        [Then(@"Search Button Should be Visible")]
        public void ThenSearchButtonShouldBeVisible()
        {
            Actions act = new Actions(driver);
            act.KeyDown(Keys.LeftControl);
            act.SendKeys("e");
            act.KeyUp(Keys.LeftControl);
            act.Build();
            act.Perform();
        }
        [Given(@"User gets Search results")]

        public void GivenUsergetsSearchresults()
        {
         IWebElement Searchheader = driver.FindElement(By.XPath("//span[@class ='body-text-heading')]"));
            Searchheader.getText();
        }


        [When(@"click on the first link of search results")]
        public void WhenClickOnTheFirstLinkOfSearchResults()
        {
            IWebElement Donationlink = driver.FindElement(By.XPath("//*[contains(@span,'Donate to Charity Online')]"));
            Donationlink.Click();
        }

        [Then(@"User lands on Payment page and verfies it")]
        public void ThenUserLandsOnPaymentPageAndVerfiesIt()
        {
            IWebElement expected = driver.FindElement(By.XPath("//*[contains(text(),'single-payment tab')]"));
            IWebElement actual = driver.FindElement(By.ClassName("single-tab active"));
            Assert.AreEqual(expected, actual);

        }
    }
}

