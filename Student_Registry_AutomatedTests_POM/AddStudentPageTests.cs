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
            // � ctr+. ������� ������ � ViewStudentsPage Class
            var page = new AddStudentPage(driver);
            page.Open();

            Assert.AreEqual("Add Student", page.GetPageTitle());
            Assert.AreEqual("Register New Student", page.GetPageHeadingText());

            // �������� ���� �������� �� name � email �� ������
            Assert.IsEmpty(page.NameField.Text);
            Assert.IsEmpty(page.EmailField.Text);
            Assert.AreEqual("Add", page.AddButton.Text);
        }
        [Test]
        public void TestAddStudentPage_AddValidStudent()
        {
            var page = new AddStudentPage(driver);
            page.Open();
            // �������� name � email, ����� �� �� ��������� ����� ��� �� ������� �����(������� �� �� ����. ����� ������� ����)
            string name = "George" + DateTime.Now.Ticks;
            string email = "george" + DateTime.Now.Ticks + "@gmail.com";

            page.AddStudent(name, email);

            // ����������� ���� ���� ���� �������� � ������� ��� ���������� ��� ViewStudentsPage
            var viewStudentsPage = new ViewStudentsPage(driver);
            Assert.IsTrue(viewStudentsPage.IsOpen());

            // ������� ��������� ������� ������� �� GetRegisteredSudents()-����� ���� ��� �������� � ��
            // ���������� �� name � email ���� �� ��� � �������
            var students = viewStudentsPage.GetRegisteredStudents();
            var lastStudent = students.Last();
            // ���������� �������� � ��� ������ "Marry (marry@gmail.com)"
            string newStudent = name + " " + "(" + email + ")";
            Assert.Contains(newStudent, students);   
        }
        [Test]
        public void TestAddStudentPage_AddInValidStudent()
        {
            var addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();
            // �������� name � email, ����� �� �� ��������� ����� ��� �� ������� �����(������� �� �� ����. ����� ������� ����)
            string name = "";
            string email = "george" + DateTime.Now.Ticks + "@gmail.com";

            addStudentPage.AddStudent(name, email);

            // ����������� ���� �������� �� AddStudentPage, ��� ���� �� �������� �������� � ���� InvalidMessage           
            Assert.IsTrue(addStudentPage.IsOpen());

            // ����������� ���� �� ������� ����������� InvalidMessage � ���� �� ������� "Cannot add student. Name and email fields are required!"
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