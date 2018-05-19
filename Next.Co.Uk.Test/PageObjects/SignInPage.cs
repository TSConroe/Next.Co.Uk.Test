using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections;
using System.Configuration;

namespace Next.Co.Uk.Test.PageObjects
{
    class SignInPage
    {
        private readonly IWebDriver driver;
        
        public SignInPage(IWebDriver browser)
        {
            this.driver = browser;
            this.driver.Manage().Window.Maximize();
            PageFactory.InitElements(browser, this);
        }


        public void Navigate(string url)
        {
            this.driver.Navigate().GoToUrl(url);
        }

        public void LogIn(string username, string password)
        {
            this.emailInput.Clear();
            this.emailInput.SendKeys(username);

        }

        [FindsBy(How = How.XPath, Using = "//*[@id='EmailOrAccountNumber']")]
        public IWebElement emailInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Password']")]
        public IWebElement passwordInput { get; set; }
    }
}
