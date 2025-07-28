using OpenQA.Selenium;
using LabcorpAutomation.Page_Objects;
using OpenQA.Selenium.Support.UI;

namespace LabcorpAutomation.Step_Methods
{
    public class HomePageMethods
    {
        private readonly IWebDriver _driver;
        private readonly HomePageObjects _homePageObjects;

        public HomePageMethods(IWebDriver driver)
        {
            _driver = driver;
            _homePageObjects = new HomePageObjects(driver);
        }

        public void ClickOnTheCareersLink()
        {
            //        new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
            //.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_homePageObjects.linkCareers))
            //.Click();
            _homePageObjects.linkCareers.Click();
        }

        public void NavigateToHomePage()
        {
            _driver.Navigate().GoToUrl("https://www.labcorp.com/");
            _driver.Manage().Window.Maximize();
        }
    }
}
