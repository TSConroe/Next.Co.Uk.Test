using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Next.Co.Uk.Test
{
    [TestClass]
    public class Boys1516yJeansTest
    {
        // Arrange

        IWebDriver driver;
        string expectTitle = "Google";

        [TestMethod]
        public void BrouserInitialize()
        {
             driver = new ChromeDriver();
            
            driver.Url = "http://google.com";

            //Act

            String actualTitle = driver.Title;

            //Assert

            Assert.AreEqual(expectTitle, actualTitle);

            driver.Close();
        }



      
     

        

    }
}
