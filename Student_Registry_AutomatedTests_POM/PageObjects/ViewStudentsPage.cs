using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Registry_AutomatedTests_POM.PageObjects
{
    public class ViewStudentsPage : BasePage  
    {
        // Копираме всичко от HomePage.cs и сменяме PageUrl и името с ViewStudentsPage
        public ViewStudentsPage(IWebDriver driver) : base(driver)
        {
        }
        public override string PageUrl
        { get => "https://mvc-app-node-express.nakov.repl.co/students"; }

        //field за имената и мейлите на студентите. To e List of items, затова е FindElemetS
        public ReadOnlyCollection<IWebElement> ListStudentInfo =>
            driver.FindElements(By.CssSelector("body > ul > li"));

        public string[] GetRegisteredStudents() 
        {
            var elementsStudents = this.ListStudentInfo.Select(s => s.Text).ToArray();
            return elementsStudents;
        }
    }
}
