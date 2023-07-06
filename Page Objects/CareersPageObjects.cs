using LabcorpProject.Drivers;
using OpenQA.Selenium;


namespace LabcorpProject.Page_Objects
{
    internal class CareersPageObjects
    { 
        public IWebElement inputJobSearchMain => SeleniumDriver.driver.FindElement(By.XPath("//*[@class = 'ph-page']//input[@type='text']"));
        public IWebElement btnJobSearchMain => SeleniumDriver.driver.FindElement(By.XPath("//*[@class = 'ph-page']//button[@type='submit']"));
        public IList<IWebElement> txtListedJobs => SeleniumDriver.driver.FindElements(By.XPath("//div[@class = 'job-title']/span/text()"));
        public IWebElement positionName (string post) => SeleniumDriver.driver.FindElement(By.XPath("//div[@class = 'job-title']/span[text()='" + post+" ']"));
        public IWebElement positionID (string post) => SeleniumDriver.driver.FindElement(By.XPath("//div[@class = 'job-title']/span[text()='"+post+" ']//ancestor::div[@class = 'information']//span[@class = 'au-target jobId']/span[2]"));
        public IWebElement positionLocationByID (string id) => SeleniumDriver.driver.FindElement(By.XPath("//span[@class = 'au-target jobId']/span[text()='"+id+"']//ancestor::p/span/span[@class='job-location']"));

        public IWebElement locationCountByID(string id) => (IWebElement)SeleniumDriver.driver.FindElements(By.XPath("//span[@class = 'au-target jobId']/span[text()='" + id + "']//ancestor::p/span/span[@class='job-location']"));
        public IWebElement firstpositionLocationByID(string id) => SeleniumDriver.driver.FindElement(By.XPath("//span[@class = 'au-target jobId']/span[text()='"+id+"']//ancestor::div/div/div[@class='job-multi-locations']/ul/li[1]"));   
        public IWebElement summaryFirstSentenceByID (string id) => SeleniumDriver.driver.FindElement(By.XPath("//span[@class = 'au-target jobId']/span[text()='"+id+ "']//ancestor::div[@class='information']/div/p"));
        public IWebElement locationsDropdown => SeleniumDriver.driver.FindElement(By.XPath("//div[@class='job-multi-locations']/button/span"));
    }

}
