using LabcorpAutomation.Drivers;
using OpenQA.Selenium;


namespace LabcorpAutomation.Page_Objects
{
    public class CareersPageObjects
    {
        private readonly IWebDriver _driver;
        public CareersPageObjects(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement inputJobSearchMain => _driver.FindElement(By.XPath("//*[@class = 'global-search-area']//input[@type='text']"));
        public IWebElement btnJobSearchMain => _driver.FindElement(By.XPath("//*[@class = 'global-search-area']//button[@type='button']"));
        public IList<IWebElement> txtListedJobs => _driver.FindElements(By.XPath("//div[@class = 'job-title']/span/text()"));
        public IWebElement positionName (string post) => _driver.FindElement(By.XPath("//div[@class = 'job-title']/span[text()='" + post+" ']"));
        public IWebElement positionID (string post) => _driver.FindElement(By.XPath("//div[@class = 'job-title']/span[text()='"+post+" ']//ancestor::div[@class = 'information']//span[@class = 'au-target jobId']/span[2]"));
        public IWebElement positionLocationByID (string id) => _driver.FindElement(By.XPath("//span[@class = 'au-target jobId']/span[text()='"+id+"']//ancestor::p/span/span[@class='job-location']"));

        public IWebElement locationCountByID(string id) => (IWebElement)_driver.FindElements(By.XPath("//span[@class = 'au-target jobId']/span[text()='" + id + "']//ancestor::p/span/span[@class='job-location']"));
        public IWebElement firstpositionLocationByID(string id) => _driver.FindElement(By.XPath("//span[@class = 'au-target jobId']/span[text()='"+id+"']//ancestor::div/div/div[@class='job-multi-locations']/ul/li[1]"));   
        public IWebElement summaryFirstSentenceByID (string id) => _driver.FindElement(By.XPath("//span[@class = 'au-target jobId']/span[text()='"+id+ "']//ancestor::div[@class='information']/div/p"));
        public IWebElement locationsDropdown => _driver.FindElement(By.XPath("//div[@class='job-multi-locations']/button/span"));
    }

}
