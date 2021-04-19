using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Student_Registry_AutomatedTests_POM.PageObjects;
using System;
using System.Linq;

namespace Student_Registry_AutomatedTests_POM.Tests
{
    public class AddStudentPageTests : BaseTest
    {

        [Test]
        public void TestAddStudentPage()
        {
            // с ctr+. създава връзка с ViewStudentsPage Class
            var page = new AddStudentPage(driver);
            page.Open();

            Assert.AreEqual("Add Student", page.GetPageTitle());
            Assert.AreEqual("Register New Student", page.GetPageHeadingText());

            // Тестваме дали полетата за name и email са празни
            Assert.IsEmpty(page.NameField.Text);
            Assert.IsEmpty(page.EmailField.Text);
            Assert.AreEqual("Add", page.AddButton.Text);
        }
        [Test]
        public void TestAddStudentPage_AddValidStudent()
        {
            var page = new AddStudentPage(driver);
            page.Open();
            // задаваме name и email, които ще са разалични всеки път по следния начин(цифрите ще са разл. всеки следващ Тест)
            string name = "George" + DateTime.Now.Ticks;
            string email = "george" + DateTime.Now.Ticks + "@gmail.com";

            page.AddStudent(name, email);

            // Проверяваме дали след като студента е добавен сме препратени към ViewStudentsPage
            var viewStudentsPage = new ViewStudentsPage(driver);
            Assert.IsTrue(viewStudentsPage.IsOpen());

            // взимаме последния добавен студент от GetRegisteredSudents()-който сега сме добавили и го
            // сравняваме по name и email дали го има в списъка
            var students = viewStudentsPage.GetRegisteredStudents();
            var lastStudent = students.Last();
            // Очакваният резултат е във формат "Marry (marry@gmail.com)"
            string newStudent = name + " " + "(" + email + ")";
            Assert.Contains(newStudent, students);   
        }
        [Test]
        public void TestAddStudentPage_AddInValidStudent()
        {
            var addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();
            // задаваме name и email, които ще са разалични всеки път по следния начин(цифрите ще са разл. всеки следващ Тест)
            string name = "";
            string email = "george" + DateTime.Now.Ticks + "@gmail.com";

            addStudentPage.AddStudent(name, email);

            // Проверяваме дали оставаме на AddStudentPage, тъй като не добавяме студента и дава InvalidMessage           
            Assert.IsTrue(addStudentPage.IsOpen());

            // Проверяваме дали се появява съобщението InvalidMessage и дали то съдържа "Cannot add student. Name and email fields are required!"
            string errorMessage = addStudentPage.InvalidMessage.Text;
            Assert.IsTrue(errorMessage.Contains
                ("Cannot add student. Name and email fields are required!"));

            name = "George" + DateTime.Now.Ticks;
            email = "";
            Assert.IsTrue(errorMessage.Contains
                ("Cannot add student. Name and email fields are required!"));

            name = "";
            email = "";
            Assert.IsTrue(errorMessage.Contains
                ("Cannot add student. Name and email fields are required!"));
        }

    }
}