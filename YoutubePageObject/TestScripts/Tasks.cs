using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Engineering;
using System.Threading;
using YoutubePageObject.BaseClass;
using YoutubePageObject.PageObjects;
using OpenQA.Selenium.Interactions;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Configuration;
using System.Configuration;

namespace YoutubePageObject.TestScripts
{

    [TestFixture]
    public class Tasks : BaseClass1
    {
        [Test,Order(3)]
        [Parallelizable]

        [TestCase("test@test")]
        [TestCase("test2@test")]
        [TestCase("test3@test")]
        [TestCase("test4@test")]
        [TestCase("test5@test")]
        public void TestCase1(string email)
        {



            Setup("chrome");
            HomePagePage home = new(driver);
            ContactUsPopup contactpopup = new(driver);
            ExtentTest = extent.CreateTest("TestCase1");
            ExtentTest.Log(Status.Info, "Testcase1 is started");


            home.Scroll_ToContact();
            home.Contact_us_Button.Click();
            contactpopup.Name_Input.SendKeys("Eslam Elwakil");
            contactpopup.Email_Input.SendKeys(email);
            contactpopup.Subject_Input.SendKeys("testsubjct");
            contactpopup.Message_Input.SendKeys("testmessage");
            contactpopup.Send_Button.Click();

            var expectedmessage = "The e-mail address entered is invalid.";
            var errormessage = contactpopup.Error_message.Text;
            try
            {
                Assert.AreEqual(expectedmessage, errormessage);
                ExtentTest.Log(Status.Pass, " the error message ‘The e-mail address entered is invalid.’ appeared");
            }
            catch 
            {
                ExtentTest.Log(Status.Fail, "the error message ‘The e-mail address entered is invalid.’ NOT appeared");
            }
        }

        [Test, Order(2)]
        [Parallelizable]
        public void TestCase2()
        {
             Setup("chrome");

             HomePagePage home = new(driver);
             CompanyPage company = new(driver);
             ExtentTest = extent.CreateTest("TestCase2");
             ExtentTest.Log(Status.Info, "Testcase2 is started");

            
            home.Choose_Form_nav(0);

            if (driver.Url == "https://www.musala.com/company/")
            {
                Thread.Sleep(5000);

            }
            else
            {
                driver.Url = "https://www.musala.com/company/";
            }

            Thread.Sleep(5000);

            string Actual_Url = driver.Url;

            string Expected_URl = "https://www.musala.com/company/";
            try
            {
                Assert.AreEqual(Actual_Url, Expected_URl);
                Console.WriteLine("The Company URl is right");
                ExtentTest.Log(Status.Pass, "The Company URl is right");

            }
            catch
            {
                Console.WriteLine("The Company URl is wrong");
                ExtentTest.Log(Status.Fail, "The Company URl is wrong");

            }
            try
            {
                bool leaderisdisplayed = company.LeaderShip.Displayed;
                ExtentTest.Log(Status.Pass, "the LeaderShip selection is displayed");

            }
            catch
            {
                Console.WriteLine();
                ExtentTest.Log(Status.Fail, "the LeaderShip selection didn't displayed");

            }
            Thread.Sleep(2000);
            company.Scroll_ToEnd();
            Thread.Sleep(2000);
            home.Accept_Cookie.Click();
            company.FaceBook_Link.Click();
            company.Choose_windows_tab(1);
            string Actual_facebook_Url = driver.Url;
            string Expected_facebook_URl = "https://www.facebook.com/MusalaSoft?fref=ts";
            try
            {   
                Assert.AreEqual(Actual_facebook_Url, Expected_facebook_URl);
                Console.WriteLine("The facebook URl is right");
                ExtentTest.Log(Status.Pass, "The facebook URl is right");

            }
            catch
            {
                Console.WriteLine("The facebook URl is wrong");
                ExtentTest.Log(Status.Fail, "The facebook URl is wrong");

            }
            company.Profile_Image.Click();

            try
            {
                Assert.IsTrue(company.Image_scr.Displayed);
                // imagesource = true;
                Console.WriteLine("right image loaded");
                ExtentTest.Log(Status.Pass, "right image loaded");
            }
            catch
            {

                ExtentTest.Log(Status.Fail, "wrong image loaded");
            }

        }

        [Test,Order(4)]

       [Parallelizable]
        public void TestCase3()
        {

            Setup("chrome");
            CareersPage careers = new(driver);
            JoinUsPage joinUs = new(driver);
            ApplyPopup applyPopup = new ApplyPopup(driver);
            HomePagePage home = new HomePagePage(driver);
            CompanyPage company = new CompanyPage(driver);
            ExtentTest = extent.CreateTest("TestCase3");
            ExtentTest.Log(Status.Info, "Testcase3 is started");



            
            home.Choose_Form_nav(4);


            Thread.Sleep(4000);

            careers.Check_our_open_positions_Button.Click();
            Thread.Sleep(2000);
            string Actual_Url = driver.Url;
            string Expected_URl = "https://www.musala.com/careers/join-us/";
            try
            {
                Assert.AreEqual(Actual_Url, Expected_URl);
                Console.WriteLine("The URl is right");
                ExtentTest.Log(Status.Pass, "The URl is right");
            }
            catch
            {
                Console.WriteLine("The URl is wrong");
                ExtentTest.Log(Status.Fail, "The URl is wrong");
            }
            joinUs.Scroll_ToPosition200();
            joinUs.Select_location_dropdown.Click();
            joinUs.Anywhere_selection.Click();
            joinUs.Scroll_ToPosition400();
            Thread.Sleep(6000);
            joinUs.Automation_open_position.Click();
            Thread.Sleep(6000);
          
            
            int SelectionCount = driver.FindElements(By.XPath("//*[@class='content-title']")).Count();
            
            int ExpectedSectionNum = 4;
            try
            {
                Assert.AreEqual(SelectionCount, ExpectedSectionNum);
                Console.WriteLine("The number of section is right");
                ExtentTest.Log(Status.Pass, "The number of section is right");

            }
            catch
            {
                Console.WriteLine("The number of section is wrong");
                ExtentTest.Log(Status.Fail, "The number of section is wrong");

            }

            IList<IWebElement> sectiontitle = driver.FindElements(By.XPath("//*[@class='content-title']/child::h2"));
            string[] SelectionCountw = new string[driver.FindElements(By.XPath("//*[@class='content-title']/child::h2")).Count()];

            string[] ExpectedSectionTitle = { "General description", "Requirements", "Responsibilities", "What we offer" };
            int i = 0;
            int g = 0;
            foreach (var section in sectiontitle)
            {
                SelectionCountw[g++] = section.Text;
                string[] listofsection = { section.Text };
                try
                {
                    Assert.AreEqual(listofsection[i], ExpectedSectionTitle[g - 1]);
                    Console.WriteLine(listofsection[i]);
                    ExtentTest.Log(Status.Pass,  "right title"+ listofsection[i]);
                }
                catch
                {
                    Console.WriteLine("wrong title");
                    ExtentTest.Log(Status.Fail, "wrong title");

                }
              

            }
            IWebElement apply = driver.FindElement(By.XPath("//*[@value='Apply']"));
            int x = apply.Location.X;
            int y = apply.Location.Y;
            int expected_X = 1082;
            int expected_Y = 1580;
            try
            {
                Assert.AreEqual(x, expected_X);
                Assert.AreEqual(y, expected_Y);
                Console.WriteLine("apply button in page bottom");
                ExtentTest.Log(Status.Pass, "apply button in page bottom");

            }
            catch
            {
                Console.WriteLine("apply button not in page bottom");
                ExtentTest.Log(Status.Fail, "apply button not in page bottom");

            }
            home.Accept_Cookie.Click();
            company.Scroll_ToEnd();
            joinUs.Apply_button.Click();
            applyPopup.Email_Input.SendKeys("test@test");
            applyPopup.Upload_CV_Button.Click();
            applyPopup.Upload_CV_Button.SendKeys(@"C:\fakepath\test.doc");
            applyPopup.Terms_Checkbox.Click();
            applyPopup.Send_button.Click();
            Thread.Sleep(4000);
            string errormessage = driver.FindElement(By.XPath("//*[@class='wpcf7-response-output']")).Text;
            string actualerrormessage = "One or more fields have an error. Please check and try again.";
            Thread.Sleep(4000);

            try
            {
                Assert.AreEqual(errormessage, actualerrormessage);
                Console.WriteLine("right error message is appeared");
                ExtentTest.Log(Status.Pass, "right error message is appeared");

            }
            catch
            {
                Console.WriteLine("not the same message");
                ExtentTest.Log(Status.Fail, "not the same message");

            }

        }

        [Test,Order(1)]
       [Parallelizable]
        public void TestCase4()
        {
            Setup("chrome");
            HomePagePage home = new(driver);
            CareersPage careers = new(driver);
            JoinUsPage joinUs = new(driver);
            ExtentTest = extent.CreateTest("TestCase4");
            ExtentTest.Log(Status.Info, "Testcase4 is started");
            
            
            home.Choose_Form_nav(4);
            Thread.Sleep(2000);
            careers.Check_our_open_positions_Button.Click();
            joinUs.Scroll_ToPosition200();
            joinUs.Select_location_dropdown.Click();

            joinUs.Filter_By_Location("Sofia");
            joinUs.Filter_By_Location("Skopje");


        }
    }
}
