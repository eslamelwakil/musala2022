using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Firefox;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace YoutubePageObject.BaseClass;

public class BaseClass1
{
    public IWebDriver? driver;
    public static ExtentReports extent;
    public static ExtentTest ExtentTest;

    [SetUp]
    public void Setup()
    {
        extent = new ExtentReports();
        var htmlreporter = new ExtentHtmlReporter(@"C:\Users\Elwakil\Desktop\musala\YoutubePageObject\Reports\Reports.html");
        htmlreporter.Config.DocumentTitle = "Musala Report";
        htmlreporter.Config.Theme = Theme.Standard;
        extent.AttachReporter(htmlreporter);
    }
    public void Setup(string browsername)
    {


        if (browsername.Equals("chrome"))
        {
            driver = new ChromeDriver();

        }
        else if (browsername.Equals("Firefox"))
        {
            driver = new FirefoxDriver();
        }
        else
        {
            Console.WriteLine("musalla project just sypport chrom or firefox browsers"); ;
        }
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
        driver.Url = "http://www.musala.com/";



    }
    [TearDown]
    public void End()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var errormessage = TestContext.CurrentContext.Result.Message;
        if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            ExtentTest.Log(Status.Fail, status + errormessage);
        }
        else
        {
            ExtentTest.Log(Status.Pass, status + errormessage);
        }
        extent.Flush();
        driver.Quit();


    }


}
