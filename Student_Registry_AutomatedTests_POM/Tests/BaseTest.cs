using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Registry_AutomatedTests_POM.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
