using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Next.Co.Uk.Test
{
    [TestClass]
    public class OpenPageTest
    {
        
        private IWebDriver driver;
        string expectTitle = "Buy boys jeans in 1516years from the Next UK online shop";
        By Jeanstextlink = By.LinkText("Boys");

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [TestMethod]
        public void BrouserInitialize()
        {
                         
            driver.Url = "http://www.next.co.uk/";

            //Act

            String actualTitle = driver.Title;

            //Assert

            Assert.AreEqual(expectTitle, actualTitle);
                       
            
        }
        [TestMethod]
        public void SelectCountry()
        {
            driver.Url = "http://www.next.co.uk/";
            By CounteySelectorClose = By.ClassName("flagContainer");
            IWebElement EnglishButton = driver.FindElement(By.ClassName("languageButton"));
            EnglishButton.Click();
            //!!!
            //Need to add country selector checher
            //
            

            //Act
            driver.FindElement(CounteySelectorClose);
            IWebElement selectElem = driver.FindElement(By.TagName("select"));
           
            String actualTitle = driver.Title;

            //Assert

            Assert.AreEqual(expectTitle, actualTitle);


        }


        [TestMethod]
        public void OpenJeansPage()
        {

            driver.Url = "http://www.next.co.uk/";

            //Find Boys jeans page
            By Serchbox = By.Id("sli_search_1");
            driver.FindElement((Serchbox)).SendKeys("BOYS JEANS");
            driver.FindElement((Serchbox)).Submit();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            //Show sizes list
            By SizeFiltr = By.XPath("//*[@id='size']/div[1]/p");
            driver.FindElement(SizeFiltr).Click();

            //Show all sizes
            By SizeVievMoreLink = By.XPath("//*[@id='size']/a");
            driver.FindElement(SizeVievMoreLink).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            //Scroll down
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,500)", "");
            
            //chose 15-16y size
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            By Size1516Y = By.XPath("//*[@id='size']/div[2]/ul/li[21]/div/label");
            driver.FindElement(Size1516Y).Click();

            //check title
            String actualTitle = driver.Title;

            Assert.AreEqual(expectTitle, actualTitle);


            ArrayList Titleslist = new ArrayList();
            //frst one
            
           // object olink = (driver.FindElement(By.CssSelector("#i1>section:nth-child(1)>div:nth-child(1)>h2:nth-child(1)>a*")).GetAttribute("href"));

            //Titleslist.Add(driver.FindElement(By.XPath("//*[@id='i1']/section/div[1]/h2/a/@href")));
            Titleslist.Add(driver.FindElement(By.XPath("//*[@id='i1']/section/div[1]/div[1]/a")).Text);

            //second one
           // Titleslist.Add(driver.FindElement(By.XPath("//*[@id='i2']/section/div[1]/h2/a/@href")).Text);
            Titleslist.Add(driver.FindElement(By.XPath("//*[@id='i2']/section/div[1]/div[1]/a")).Text);

            //third one
           // Titleslist.Add(driver.FindElement(By.XPath("//*[@id='i3']/section/div[1]/h2/a/@href")).Text);
            Titleslist.Add(driver.FindElement(By.XPath("//*[@id='i3']/section/div[1]/div[1]/a")).Text);

          //  System.Console.Write(olink);
            foreach (object o in Titleslist)
            {
                System.Console.Write(o);
            }
           /// jeans1516y.Add()


        }


        [TestCleanup]

        public void BrouserClose()
        {
                   
            
           // driver.Close();

        }
        

    }
}
