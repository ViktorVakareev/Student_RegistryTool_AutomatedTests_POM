using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Student_Registry_AutomatedTests_POM.PageObjects;

namespace Student_Registry_AutomatedTests_POM.Tests
{
    public class HomePageTests:BaseTest
    {
       

        [Test]
        public void TestHomePage()
        {
            // с ctr+. създава връзка с HomePage Class
            var page = new HomePage(driver);
            page.Open();
            Assert.AreEqual("MVC Example", page.GetPageTitle());
            Assert.AreEqual("Students Registry", page.GetPageHeadingText());
            page.GetStudentsCount();  // Ако GetStudentsCount() не е int, ще fail-не!
            Assert.Pass();
             
        }
        [Test]
        public void TestHomePage_Links()
        {
            // с ctr+. създава връзка с HomePage Class
            var homePage = new HomePage(driver);
            var addStudenPage = new AddStudentPage(driver);
            var viewStudensPage = new ViewStudentsPage(driver);

            homePage.Open();
            homePage.LinkHomePage.Click();
            Assert.IsTrue(homePage.IsOpen());

            homePage.Open();
            homePage.LinkViewStudents.Click();
            Assert.IsTrue(viewStudensPage.IsOpen());

            // Проверяваме дали като кликнем на LinkAddStudent се отваря правилния Url!
            // викаме метода IsOpen(), който взима PageUrl от AddStudentPage.cs
            homePage.Open();
            homePage.LinkAddStudent.Click();            
            
            Assert.IsTrue(addStudenPage.IsOpen());
        }
        
    }
}