using LabcorpProject.Drivers;
using OpenQA.Selenium;


namespace LabcorpProject.Page_Objects
{
    internal class QAAnalystPageObjects
    {
        public IWebElement txtJobName => SeleniumDriver.driver.FindElement(By.CssSelector("h1.job-title"));
        public IWebElement txtJobId => SeleniumDriver.driver.FindElement(By.CssSelector("span.au-target.jobId"));
        public IWebElement txtLocation => SeleniumDriver.driver.FindElement(By.CssSelector("span.au-target.job-location"));
        public IWebElement txtFirstSentence => SeleniumDriver.driver.FindElement(By.CssSelector("div.job-description > div.jd-info.au-target > p:nth-child(1)>span"));
        public IWebElement btnSeeAll => SeleniumDriver.driver.FindElement(By.XPath("//button[@class='see-multiple-loc-btn ph-a11y-multi-location au-target']"));
        public IWebElement txtFirstLocation => SeleniumDriver.driver.FindElement(By.XPath("//ul[@class='location-list au-target']/li[1]/span[2]"));
        public IWebElement closeLocationModal => SeleniumDriver.driver.FindElement(By.XPath("//button[@class='close ph-a11y-close-multi-location au-target']"));
        public IWebElement txtFirstSentenceSecondParagraph => SeleniumDriver.driver.FindElement(By.XPath("//div[@class='job-description']/div/p[3]"));
        public IWebElement txtAutomationTools => SeleniumDriver.driver.FindElement(By.XPath("//li/p[contains(., 'Automation tools')]"));
    }
}
