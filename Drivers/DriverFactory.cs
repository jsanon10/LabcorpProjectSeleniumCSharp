using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabcorpAutomation.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver(string browser = "chrome")
        {
            IWebDriver driver;

            switch (browser.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                // Add others as needed
                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }

            driver.Manage().Window.FullScreen();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
    }

}
