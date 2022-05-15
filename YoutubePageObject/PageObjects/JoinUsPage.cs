using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace YoutubePageObject.PageObjects
{
    public class JoinUsPage
    {
        IWebDriver driver;
        public JoinUsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }




        [FindsBy(How = How.Id, Using = "get_location")]
        public IWebElement? Select_location_dropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//select/option[@value='Anywhere']")]
        public IWebElement? Anywhere_selection { get; set; }

        [FindsBy(How = How.XPath, Using = "//select/option[@value='Sofia']")]
        public IWebElement? Sofia_selection { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@data-alt='Automation QA Engineer']")]
        public IWebElement Automation_open_position { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value ='Apply']")]
        public IWebElement Apply_button { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class ='joinus-content']")]
        public IWebElement entrycontent { get; set; }


        [FindsBy(How = How.Id, Using = "3230d3c7-3a5f-48ac-a3e1-feb5c26eb4a8")]
        public IWebElement GeneralDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='requirements pull-left']/div/h2")]
        public IWebElement Requirements { get; set; }


        public void Scroll_ToPosition200()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,200);");
        }
        public void Scroll_ToPosition400()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,400);");
        }


        public void Filter_By_Location(string locatioName)
        {
            IWebElement LocationList = driver.FindElement(By.Id("get_location"));
            SelectElement location = new SelectElement(LocationList);
            location.SelectByValue(locatioName);

            if (locatioName.Equals("Sofia"))
            {
                
                Console.WriteLine("City:" + " " + "Sofia");

                IList<IWebElement> listofopenposition = driver.FindElements(By.XPath("//p[.='Sofia']//parent::div//parent::h2"));

                int q = 0;
                String[] allposition = new String[listofopenposition.Count];

                foreach (var positon in listofopenposition)
                {
                    allposition[q++] = positon.Text;
                }
                IList<IWebElement> listofline = driver.FindElements(By.XPath("//p[.='Sofia']//parent::div//parent::h2//parent::div//parent::div//parent::a"));

                    String[] alllink = new String[listofline.Count];
                    int l = 0;
                    foreach (IWebElement link in listofline)
                    {
                        alllink[l++] = link.GetAttribute("href");
                        Console.WriteLine("Position:" + "  " + allposition[q - 1] + "\n" + "MoreInfo:"+ "  " + alllink[l-1]);
                    }

            }
            else if (locatioName.Equals("Skopje"))

            {
                Console.WriteLine("City:" + " " + "Skopje");
                try
                {
                    IList<IWebElement> listofopenposition = driver.FindElements(By.XPath("//p[.='Skopje']//parent::div//parent::h2"));

                    int q = 0;
                    String[] allposition = new String[listofopenposition.Count];
                    if (listofopenposition.Count > 0)
                    {
                        foreach (var positon in listofopenposition)
                        {
                            allposition[q++] = positon.Text;

                        }
                        IList<IWebElement> listofline = driver.FindElements(By.XPath("//p[.='Sofia']//parent::div//parent::h2//parent::div//parent::div//parent::a"));

                        String[] alllink = new String[listofline.Count];
                        int l = 0;
                        foreach (IWebElement link in listofline)
                        {
                            alllink[l++] = link.GetAttribute("href");
                            Console.WriteLine("Position:" + "  " + allposition[q - 1] + "\n" + "MoreInfo:" + "  " + alllink[l - 1]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("positon in Skopje Not Available ");
                    }
                   
                }
                catch
                {
                    Console.WriteLine("there is onther problem");

                }

            }
        }

    }
}


