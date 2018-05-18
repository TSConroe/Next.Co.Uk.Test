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
    public class MainPage
    {
        
        private readonly IWebDriver driver;
        private readonly string url = @"http://www.next.co.uk/";
        


        public MainPage(IWebDriver browser)
        {
            this.driver = browser;
            this.driver.Manage().Window.Maximize();
            PageFactory.InitElements(browser, this);
            

        }

        [FindsBy(How = How.Id, Using = "sli_search_1")]
        public IWebElement SearchBox { get; set; }

        public void SearchSubmit()
        {
            SearchBox.Submit();
        }


        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        public void Navigate(string url)
        {
            this.driver.Navigate().GoToUrl(url);
        }

        public void Search(string textToType)
        {
            this.SearchBox.Clear();
            this.SearchBox.SendKeys(textToType);

        }

        [FindsBy(How = How.XPath, Using = "//*[@id='size']/div[1]/p")]
        public IWebElement SizeFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='size']/a")]
        public IWebElement SizeVievMoreLink { get; set; }



        public void ChangeSizeButton()
        {

            SizeFilter.Click();

        }

        public void SizeVievMoreLinkMenu()
        {

            SizeVievMoreLink.Click();

        }


        
        [FindsBy(How = How.XPath, Using = "//*[@id='size']/div[2]/ul/li[21]/div/label")]
        public IWebElement Size1516Y { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='FilterModalOuter']/div/div[1]/input")]
        public IWebElement SizeSerchbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='FilterModalOuter']/div/div[5]/a")]
        public IWebElement ConfirmSizeButton { get; set; }

        public void SizeVievMenu()
        {

            if (!(Size1516Y).Displayed)
            {

                SizeSerchbox.Clear();
                SizeSerchbox.SendKeys("15 - 16 Years");
                SizeSerchbox.SendKeys(Keys.Enter);
                ConfirmSizeButton.Click();
            }

            else
            {
               

                Size1516Y.Click();
            }

        }

        [FindsBy(How = How.XPath, Using = "//*[@id='dk_container_iSort']")]
        public IWebElement priceSortByButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='dk_container_iSort']/div/ul/li[4]")]
        public IWebElement priceLoverSelector { get; set; }


        public void PriceSortMenu()
        {

            priceSortByButton.Click();
            priceLoverSelector.Click();


        }

        [FindsBy(How = How.XPath, Using = "//*[@id='i1']/section/div[1]/div[1]/a")]
        public IWebElement firstPrise { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='i2']/section/div[1]/div[1]/a")]
        public IWebElement secondPrise { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='i3']/section/div[1]/div[1]/a")]
        public IWebElement thirdPrise { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='i1']/section/div[2]/a[position() = 1 and @href]")]
        public IWebElement firstLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='i2']/section/div[2]/a[position() = 1 and @href]")]
        public IWebElement secondLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='i3']/section/div[2]/a[position() = 1 and @href]")]
        public IWebElement thirdLink { get; set; }

      
        

        public ArrayList GetPrice(ArrayList lst)
        {

            lst.Add(firstPrise.Text);
            lst.Add(secondPrise.Text);
            lst.Add(thirdPrise.Text);

            return lst;
            
        }
        public ArrayList GetLink(ArrayList lst)
        {

            lst.Add(firstLink.GetAttribute("href"));
            lst.Add(secondLink.GetAttribute("href"));
            lst.Add(thirdLink.GetAttribute("href"));

            return lst;

        }



         
    }
}
