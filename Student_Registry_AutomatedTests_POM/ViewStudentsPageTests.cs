using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Student_Registry_AutomatedTests_POM.PageObjects;

namespace Student_Registry_AutomatedTests_POM.Tests
{
    public class ViewStudentsPageTests : BaseTest
    {

        [Test]
        public void TestViewStudentsPage()
        {
            // � ctr+. ������� ������ � ViewStudentsPage Class
            var page = new ViewStudentsPage(driver);
            page.Open();

            Assert.AreEqual("Students", page.GetPageTitle());
            Assert.AreEqual("Registered Students", page.GetPageHeadingText());
            var students = page.GetRegisteredStudents();
            foreach (string st in students)
            {
                // �������� ���� ����� "(" �� ������� �������� �� 0-1 ������ � ������ �� ��������
                Assert.IsTrue(st.IndexOf("(") > 0);
                //�������� ���� ����� ")" �� ��������� ������ � ������ �� ��������
                Assert.IsTrue(st.LastIndexOf(")") == st.Length - 1);
            }

        }
      

    }
}