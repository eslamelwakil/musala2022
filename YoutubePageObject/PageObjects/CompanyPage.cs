using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace YoutubePageObject.PageObjects
{
    public class CompanyPage
    {
         IWebDriver driver;

        public CompanyPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.PartialLinkText, Using = "Contact us")]
        public IWebElement Contact_us_Button { get; set; }

        [FindsBy(How = How.LinkText, Using = "Company")]
        public IWebElement? Company_Link{ get; set; }

        [FindsBy(How = How.XPath, Using = "//section[@class='company-members']")]
        public IWebElement? LeaderShip { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@class = 'musala musala-icon-facebook']")]
        public IWebElement? FaceBook_Link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='pzggbiyp']")]
        public IWebElement? Profile_Image { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[contains(@alt,'May be an image of text that says \"MusalaSoft\"')]")]
        public IWebElement? Image_scr { get; set; }


        public void Scroll_ToEnd()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");
        }
        public void Choose_windows_tab(int tab_index)
        {
            driver.SwitchTo().Window(driver.WindowHandles[tab_index]);
        }
    }
}
