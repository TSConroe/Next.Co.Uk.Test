using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections;

namespace Next.Co.Uk.Test.PageObjects
{
    public class ProductPage
    {
        private readonly IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//section[2]/div[1]/div/span")]
        public IWebElement refreshLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='fade']")]
        public IWebElement JeansIMG { get; set; }


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


        public void PopupCheck()
        {

            if (JeansIMG.Displayed)
            {
                JeansIMG.Click();
            }
            
        }

        public ArrayList GetRefreshLink(ArrayList lst)
        {

            lst.Add(refreshLink.Text);

            return lst;

        }

     

    }
}
