using LabcorpProject.Drivers;
using OpenQA.Selenium;


namespace LabcorpProject.Page_Objects
{
    internal class HomePageObjects
    {
        public IWebElement linkCareers => SeleniumDriver.driver.FindElement(By.LinkText("Careers"));
    }
}
