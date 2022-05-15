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
    public class HomePagePage : BaseClass.BaseClass1
    {



        public HomePagePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(50)));
        }


        [FindsBy(How = How.XPath, Using = "/html/body/main/section[2]/div/div/div/a[1]/button")]
        public IWebElement Contact_us_Button { get; set; }


        [FindsBy(How = How.Id, Using = "menu-main-nav-1")]
        public IWebElement? Nav { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.musala.com/company/']")]
        public IWebElement? Company_Link { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='menu-main-nav-1']//child::li[5]//a")]
        public IWebElement? Careers_Link { get; set; }

        [FindsBy(How = How.Id, Using = "wt-cli-accept-all-btn")]
        public IWebElement? Accept_Cookie { get; set; }




        public void Scroll_Down_to_Contact_Button()
        {
            var ContactUs = driver.FindElement((By)Contact_us_Button);
            Actions actions = new Actions(driver);
            actions.MoveToElement(ContactUs);
            actions.Build().Perform();


        }


        public void Scroll_ToContact()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,950);");
        }

        public void Choose_Form_nav(int navindex)
        {

            IList<IWebElement> navelement = driver.FindElements(By.XPath("//ul[@id='menu-main-nav-1']/li"));

            IWebElement[] allText = new IWebElement[navelement.Count];
            int i = 0;
            foreach (IWebElement element in navelement)
            {
                allText[i++] = element;
            }

            allText[navindex].Click();
        }
    }
}
