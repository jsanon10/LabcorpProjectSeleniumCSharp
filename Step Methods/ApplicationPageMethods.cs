using LabcorpAutomation.Page_Objects;
using OpenQA.Selenium;


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
            _driver.SwitchTo().Frame(iframes); 
            _applicationPageObjects.lnkCareerHome.Click();
        }
    }
}
