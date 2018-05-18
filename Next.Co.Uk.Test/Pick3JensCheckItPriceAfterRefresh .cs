using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Next.Co.Uk.Test.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using log4net;

namespace Next.Co.Uk.Test
{
    [TestClass]
    public class UnitTest1
    {
         ArrayList Linklist = new ArrayList();
         ArrayList Pricelist = new ArrayList();
         ArrayList RefreshPricelist = new ArrayList();
        static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IWebDriver Driver { get; set; }
        public IWebDriver SecondDriver { get; set; }
        public WebDriverWait Wait { get; set; }

        [TestInitialize]
        public void SetupTest()
        {
            this.Driver = new ChromeDriver();
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(20));
        }

        [TestCleanup]
        public void TeardownTest()
        {
         this.Driver.Quit();
        }

        [TestMethod]
        public void SearchJeans()
            
        {
            
            log.Info("Test was running");
            MainPage searchJeansPage = new MainPage(this.Driver);
            searchJeansPage.Navigate();
            searchJeansPage.Search("BOYS JEANS");
            searchJeansPage.SearchSubmit();

            //Show sizes list
            searchJeansPage.ChangeSizeButton();

            //Scroll down page
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollBy(0,500)", "");

            //Show all sizes
            searchJeansPage.SizeVievMoreLinkMenu();

            //Pick necessary size	
           
            searchJeansPage.SizeVievMenu();

            //Pick three cheaper product
            searchJeansPage.PriceSortMenu();

            //Copy price and url
            searchJeansPage.GetLink(Linklist);
            searchJeansPage.GetPrice(Pricelist);

            //Restart brouser 
            this.Driver.Close();
            

            foreach (object o in Linklist)
            {
                log.Info("Browser was opened");
                this.Driver = new ChromeDriver();
                ProductPage JeansPage = new ProductPage(this.Driver);
                JeansPage.Navigate((string)o);
                JeansPage.PopupCheck();
                //Copy new prices
                JeansPage.GetRefreshLink(RefreshPricelist);
                this.Driver.Close();
            }

            //assert old and new prices
            CollectionAssert.AreEqual(RefreshPricelist, Pricelist);
           
        }

        



    }

        
    }



      
    
