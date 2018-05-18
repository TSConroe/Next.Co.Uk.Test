using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using System.Collections;

namespace Next.Co.Uk.Test.PageObjects
{
    public class ProductPage
    {
        private readonly IWebDriver driver;
       



        public ProductPage(IWebDriver browser)
        {
            this.driver = browser;
            this.driver.Manage().Window.Maximize();
            PageFactory.InitElements(browser, this);
        }

        
       


        public void Navigate(string url)
        {
            this.driver.Navigate().GoToUrl(url);
        }

        public void Search(string textToType)
        {
            //   this.SearchBox.Clear();
            //  this.SearchBox.SendKeys(textToType);

        }
        [FindsBy(How = How.XPath, Using = "//*[@id='fade']")]
        public IWebElement JeansIMG { get; set; }

        public void PopupCheck()
        {

            if (JeansIMG.Displayed)
            {
                JeansIMG.Click();
            }



        }
        [FindsBy(How = How.XPath, Using = "//section[2]/div[1]/div/span")]
        public IWebElement refreshLink { get; set; }

        public ArrayList GetRefreshLink(ArrayList lst)
        {

            lst.Add(refreshLink.Text);


            return lst;

        }

    }
}
