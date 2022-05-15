using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace YoutubePageObject.PageObjects
{
    public class CareersPage
    {
         IWebDriver driver;

        public CareersPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//button[@class='contact-label contact-label-code btn btn-1b']")]
        public IWebElement? Check_our_open_positions_Button { get; set; }

       
    }
}
