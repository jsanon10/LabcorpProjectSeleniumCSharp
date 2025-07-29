using LabcorpAutomation.Drivers;
using OpenQA.Selenium;


namespace LabcorpAutomation.Page_Objects
{
    public class SeniorJavaEngineerPageObjects
    {
        private readonly IWebDriver _driver;
        public SeniorJavaEngineerPageObjects(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement txtJobName => _driver.FindElement(By.CssSelector("h1.job-title"));
        public IWebElement txtJobId => _driver.FindElement(By.CssSelector("span.au-target.jobId"));
        public IWebElement txtLocation => _driver.FindElement(By.CssSelector("span.au-target.job-location"));
        public IWebElement txtFirstSentence => _driver.FindElement(By.CssSelector("div.job-description > div.jd-info.au-target > p:nth-child(1)>span"));
        public IWebElement btnSeeAll => _driver.FindElement(By.XPath("//button[@class='see-multiple-loc-btn ph-a11y-multi-location au-target']"));
        public IWebElement txtFirstLocation => _driver.FindElement(By.XPath("//ul[@class='location-list au-target']/li[1]/span[2]"));
        public IWebElement closeLocationModal => _driver.FindElement(By.XPath("//button[@class='close ph-a11y-close-multi-location au-target']"));
        public IWebElement txtFirstSentenceSecondParagraph => _driver.FindElement(By.XPath("//div[@class='job-description']/div/p[3]"));
        public IWebElement txtAutomationTools => _driver.FindElement(By.XPath("//li/p[contains(., 'Automation tools')]"));
        public IWebElement fullJobDescription => _driver.FindElement(By.XPath("//div[@class='jd-info au-target']"));
        public IWebElement btnApplyNow => _driver.FindElement(By.XPath("//div[@class='job-bottom-action']/a"));
    }
}
