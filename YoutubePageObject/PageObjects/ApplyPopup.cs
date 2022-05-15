using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace YoutubePageObject.PageObjects
{
    public class ApplyPopup
    {
         IWebDriver driver;

        public ApplyPopup(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


       

        [FindsBy(How = How.Id, Using = "cf-2")]
        public IWebElement? Email_Input { get; set; }

        [FindsBy(How = How.Id, Using = "uploadtextfield")]
        public IWebElement? Upload_CV_Button { get; set; }

        [FindsBy(How = How.Id, Using = "recaptcha-anchor")]
        public IWebElement Recaptcha_Checkbox { get; set; }

        [FindsBy(How = How.Id, Using = "adConsentChx")]
        public IWebElement Terms_Checkbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@type='submit']")]
        public IWebElement Send_button { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='wpcf7-response-output']")]
        public IWebElement Error_Messages_popup  { get; set; }
    }
}
