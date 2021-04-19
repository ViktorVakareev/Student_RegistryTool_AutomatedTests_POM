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
            // � ctr+. ������� ������ � HomePage Class
            var page = new HomePage(driver);
            page.Open();
            Assert.AreEqual("MVC Example", page.GetPageTitle());
            Assert.AreEqual("Students Registry", page.GetPageHeadingText());
            page.GetStudentsCount();  // ��� GetStudentsCount() �� � int, �� fail-��!
            Assert.Pass();
             
        }
        [Test]
        public void TestHomePage_Links()
        {
            // � ctr+. ������� ������ � HomePage Class
            var homePage = new HomePage(driver);
            var addStudenPage = new AddStudentPage(driver);
            var viewStudensPage = new ViewStudentsPage(driver);

            homePage.Open();
            homePage.LinkHomePage.Click();
            Assert.IsTrue(homePage.IsOpen());

            homePage.Open();
            homePage.LinkViewStudents.Click();
            Assert.IsTrue(viewStudensPage.IsOpen());

            // ����������� ���� ���� ������� �� LinkAddStudent �� ������ ��������� Url!
            // ������ ������ IsOpen(), ����� ����� PageUrl �� AddStudentPage.cs
            homePage.Open();
            homePage.LinkAddStudent.Click();            
            
            Assert.IsTrue(addStudenPage.IsOpen());
        }
        
    }
}