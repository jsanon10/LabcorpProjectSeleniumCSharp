using OpenQA.Selenium;
using LabcorpAutomation.Page_Objects;

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
            _homePageObjects.linkCareers.Click();
        }

        public void NavigateToHomePage()
        {
            _driver.Navigate().GoToUrl("https://www.labcorp.com/");
            _driver.Manage().Window.Maximize();
        }
    }
}
