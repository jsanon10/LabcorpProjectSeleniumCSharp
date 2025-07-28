using LabcorpAutomation.Page_Objects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabcorpAutomation.Step_Methods
{
    public class ApplicationPageMethods
    {
        private readonly ApplicationPageObjects _applicationPageObjects;
        private readonly IWebDriver _driver;
        public ApplicationPageMethods(ApplicationPageObjects applicationPageObjects, IWebDriver driver) 
        {
            _applicationPageObjects = applicationPageObjects;
            _driver = driver;
        }

        public void handleCookieConsent()
        {
            try
            {
                // Check if the cookie consent button is present and click it
                var cookieConsentBanner = _applicationPageObjects.bnrCookieConsent;
                if (cookieConsentBanner.Displayed)
                {
                    _applicationPageObjects.btnCookieAccept.Click();
                }
            }
            catch (NoSuchElementException)
            {
                // Cookie consent button not found, do nothing
            }
        }
        public string GetJobTitle()
        {
            handleCookieConsent();
            return _applicationPageObjects.txtJobTitle.Text;
        }

        public void NavigateToCareerHome()
        {
            //handleCookieConsent();

            var iframes = _applicationPageObjects.theHeader;
            _driver.SwitchTo().Frame(iframes); // or use iframe id/name


            _applicationPageObjects.lnkCareerHome.Click();
        }
    }
}
