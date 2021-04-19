using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Registry_AutomatedTests_POM.PageObjects
{
    public class HomePage : BasePage   //HomePage inherits BasePage
    {
        // правим Constructor, който сочи към BasePage(като го кликнем оива към нея)
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        // Задаваме си override ot ctr+. на HomePage клас-а и си задаваме за homepage стрницата на проложението
        public override string PageUrl 
        { get => "https://mvc-app-node-express.nakov.repl.co/"; }

        // полето, което показва Registered Students
        public IWebElement RegisteredStudents =>
           driver.FindElement(By.CssSelector("body > p > b"));

        // Метод, който връща броя на регистр. студенти като число
        public int GetStudentsCount()
        {
            string studentsCountText = this.RegisteredStudents.Text;
            return int.Parse(studentsCountText);
        }

        
    }
}
