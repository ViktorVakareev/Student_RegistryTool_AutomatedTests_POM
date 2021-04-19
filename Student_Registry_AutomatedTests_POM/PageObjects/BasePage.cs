using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Registry_AutomatedTests_POM.PageObjects
{
   public class BasePage
    {
        // readonly, защото не искаме да го променяме, a e protected, зада го виждат child pages
        protected readonly IWebDriver driver;   
        public virtual string PageUrl { get; }

        public BasePage(IWebDriver driver)    // constructor
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        // => e за ламбда-функция
        // Дефинираме всички полета от страниците Home/ViewStudent/AddStudent
        public IWebElement LinkHomePage =>
            driver.FindElement(By.XPath("//a[contains(.,'Home')]"));
        public IWebElement LinkViewStudents =>
            driver.FindElement(By.XPath("//a[contains(.,'View Students')]"));
        public IWebElement LinkAddStudent =>
            driver.FindElement(By.XPath("//a[contains(.,'Add Student')]"));
        public IWebElement PageHeading =>
            driver.FindElement(By.CssSelector("body > h1"));

        public void Open() 
        {
            driver.Navigate().GoToUrl(this.PageUrl);        
         //Method(), който отваря PageUrl,  която е https://mvc-app-node-express.nakov.repl.co/
        }
        public bool IsOpen() 
        {
            return driver.Url == this.PageUrl; 
            // Метод, който проверява дали е отворена началната страница-> true или друга-> false
        }
        public string GetPageTitle()
        {
            return driver.Title;
        }
        public string GetPageHeadingText()
        {
            return PageHeading.Text;
        }
    }


}
