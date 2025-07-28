using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabcorpAutomation.Page_Objects
{
    public class ApplicationPageObjects
    {
        private readonly IWebDriver _driver;
        public ApplicationPageObjects(IWebDriver driver) 
        {
            _driver = driver;
        }

        public IWebElement txtJobTitle => _driver.FindElement(By.XPath("//div/*[@class='css-18mbozw']"));
        public IWebElement lnkCareerHome => _driver.FindElement(By.Id("navigationItem-Careers Home"));
        public IWebElement bnrCookieConsent => _driver.FindElement(By.Id("legalNotice"));
        public IWebElement btnCookieAccept => _driver.FindElement(By.Id("legalNoticeAcceptButton"));
        public IWebElement btnCookieDecline => _driver.FindElement(By.Id("legalNoticeDeclineButton"));
        public IWebElement theHeader => _driver.FindElement(By.Id("header"));

    }
}
