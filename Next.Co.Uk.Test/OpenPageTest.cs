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
        
        public IWebDriver driver;
        string expectTitle = "Buy boys jeans in 1516years from the Next UK online shop";
        
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
        public  void OpenMainJeansPage()
        {
            //
            //arrange
            //
            driver.Url = "http://www.next.co.uk/";

            //Find Boys jeans page
            By Serchbox = By.Id("sli_search_1");
            By JeansIMG = By.XPath("//*[@id='fade']");
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

          //  Assert.AreEqual(expectTitle, actualTitle);


           ArrayList Titleslist = new ArrayList();
           ArrayList Linklist = new ArrayList();
            //frst one



            // Titleslist.Add(driver.FindElement(By.XPath("//*[@id='i1']/section/div[2]/a/@href[1]")).Text);
            Titleslist.Add(driver.FindElement(By.XPath("//*[@id='i1']/section/div[1]/div[1]/a")).Text);
            Linklist.Add("http://www.next.co.uk/xo51014s3#187325?i=1516years");
            //second one
            // Titleslist.Add(driver.FindElement(By.XPath("//*[@id='i2']/section/div[1]/h2/a/@href")).Text);
            Titleslist.Add(driver.FindElement(By.XPath("//*[@id='i2']/section/div[1]/div[1]/a")).Text);
            Linklist.Add("http://www.next.co.uk/g76438s1#165797?i=1516years");

            //third one
            // Titleslist.Add(driver.FindElement(By.XPath("//*[@id='i3']/section/div[1]/h2/a/@href")).Text);
            Titleslist.Add(driver.FindElement(By.XPath("//*[@id='i3']/section/div[1]/div[1]/a")).Text);
            Linklist.Add("http://www.next.co.uk/g892290s2#185536?i=1516years");


            foreach (object o in Linklist)
            {
                System.Console.Write(o);
            }


            driver.Close();

            //
            //act
            //
            driver = new ChromeDriver();
            string  driverurl = (string)Linklist[0];
            driver.Url = driverurl;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            if (driver.FindElement(JeansIMG).Displayed)
                driver.FindElement((JeansIMG)).Click();
            ArrayList RefreshTitleslist = new ArrayList();
            RefreshTitleslist.Add(driver.FindElement(By.XPath("//*[@id='Style122122']/section[2]/div[1]/div/span")).Text);
            driver.Close();


            driver = new ChromeDriver();
            driverurl = (string)Linklist[1];
            driver.Url = driverurl;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            if (driver.FindElement(JeansIMG).Displayed)
             driver.FindElement((JeansIMG)).Click();
            RefreshTitleslist.Add(driver.FindElement(By.XPath("//*[@id='Style83513']/section[2]/div[1]/div/span")).Text);
            driver.Close();


            driver = new ChromeDriver();
            driverurl = (string)Linklist[2];
            driver.Url = driverurl;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            if (driver.FindElement(JeansIMG).Displayed)
                driver.FindElement((JeansIMG)).Click();
            RefreshTitleslist.Add(driver.FindElement(By.XPath("//*[@id='Style113745']/section[2]/div[1]/div/span")).Text);
            driver.Close();


            CollectionAssert.AreEqual(RefreshTitleslist, Titleslist);
            foreach (object o in RefreshTitleslist)
            {
                System.Console.Write(o);
            }
        }
       




        [TestCleanup]

        public void BrouserClose()
        {
                   
            
           // driver.Close();

        }
        

    }
}
