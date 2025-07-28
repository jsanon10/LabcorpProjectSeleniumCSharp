using LabcorpAutomation.Drivers;
using OpenQA.Selenium;


namespace LabcorpAutomation.Page_Objects
{
    public class HomePageObjects
    {
        private readonly IWebDriver _driver;

        public HomePageObjects(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement linkCareers => _driver.FindElement(By.LinkText("Careers"));
    }
}
