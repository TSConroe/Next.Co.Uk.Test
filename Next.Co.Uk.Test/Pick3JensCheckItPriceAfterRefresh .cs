using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Next.Co.Uk.Test.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Next.Co.Uk.Test
{
    [TestClass]
    public class UnitTest1
    {
         ArrayList Linklist = new ArrayList();
         ArrayList Pricelist = new ArrayList();
         ArrayList RefreshPricelist = new ArrayList();

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
            MainPage searchJeansPage = new MainPage(this.Driver);
            searchJeansPage.Navigate();
            searchJeansPage.Search("BOYS JEANS");
            searchJeansPage.SearchSubmit();

            //Show sizes list
            searchJeansPage.ChangeSizeButton();

            //Scroll down
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollBy(0,500)", "");

            //Show all sizes
            searchJeansPage.SizeVievMoreLinkMenu();

            searchJeansPage.SizeVievMenu();

            searchJeansPage.PriceSortMenu();
            searchJeansPage.GetLink(Linklist);
            searchJeansPage.GetPrice(Pricelist);

            this.Driver.Close();
            foreach (object o in Linklist)
            {
                 this.Driver = new ChromeDriver();
                ProductPage JeansPage = new ProductPage(this.Driver);
                JeansPage.Navigate((string)o);
                JeansPage.PopupCheck();
                JeansPage.GetRefreshLink(RefreshPricelist);
                this.Driver.Close();
            }

            //assert
            CollectionAssert.AreEqual(RefreshPricelist, Pricelist);
           
        }





    }

        
    }



      
    
