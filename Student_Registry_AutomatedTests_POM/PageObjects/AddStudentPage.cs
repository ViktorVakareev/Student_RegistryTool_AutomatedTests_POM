using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Registry_AutomatedTests_POM.PageObjects
{
    public class AddStudentPage : BasePage   //HomePage inherits BasePage
    {
        // Копираме всичко от ViewStudentsPage.cs и сменяме PageUrl и името с AddStudentsPage
        public AddStudentPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl
        { get => "https://mvc-app-node-express.nakov.repl.co/add-student"; }

        public IWebElement NameField =>
            driver.FindElement(By.CssSelector("input#name"));
        public IWebElement EmailField =>
            driver.FindElement(By.CssSelector("input#email"));
        public IWebElement AddButton =>
           driver.FindElement(By.XPath("/html/body/form/button"));
        public IWebElement InvalidMessage =>
          driver.FindElement(By.XPath("//div[contains(.,'Cannot add student. Name and email fields are required!')]"));

        // Method() за добавяне на нов студент без валидация
        public void AddStudent(string name, string email)
        {
            this.NameField.SendKeys(name);
            this.EmailField.SendKeys(email);
            this.AddButton.Click();
        }
    }
}
