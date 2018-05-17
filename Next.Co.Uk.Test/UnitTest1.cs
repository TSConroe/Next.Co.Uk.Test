using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Next.Co.Uk.Test
{
    [TestClass]
    public class UnitTest1
    {
        public IWebDriver driver;
        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
