using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace YoutubePageObject.PageObjects
{
    public class ContactUsPopup
    {
        IWebDriver driver;
        public ContactUsPopup(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "cf-1")]
        public IWebElement Name_Input { get; set; }

        [FindsBy(How = How.Id, Using = "cf-2")]
        public IWebElement? Email_Input { get; set; }

        [FindsBy(How = How.Id, Using = "cf-3")]
        public IWebElement? Mobile_Input { get; set; }

        [FindsBy(How = How.Id, Using = "cf-4")]
        public IWebElement? Subject_Input { get; set; }

        [FindsBy(How = How.Id, Using = "cf-5")]
        public IWebElement? Message_Input { get; set; }

    

        [FindsBy(How = How.XPath, Using = "//*[@type='submit']")]
        public IWebElement? Send_Button { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='wpcf7-not-valid-tip']")]
        public IWebElement? Error_message { get; set; }

        

    }
}
