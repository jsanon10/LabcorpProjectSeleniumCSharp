using LabcorpAutomation.Page_Objects;
using OpenQA.Selenium;

namespace LabcorpAutomation.Step_Methods
{
    public class SeniorJavaEngineerPageMethods
    {
        private readonly SeniorJavaEngineerPageObjects _qaAnalystPageObjects;
        private readonly IWebDriver _driver;

        public SeniorJavaEngineerPageMethods(IWebDriver driver)
        {
            _qaAnalystPageObjects = new SeniorJavaEngineerPageObjects(driver);
            _driver = driver;
        }
        public string GetTheJobTitle() 
        {
           return _qaAnalystPageObjects.txtJobName.Text;
        }

        public string GetTheJobID()
        {
           return _qaAnalystPageObjects.txtJobId.Text.Substring(9);   
        }

        public string GetTheJobLocation()
        {
            string firstLocation;
            try
            {
                return _qaAnalystPageObjects.txtLocation.Text.Substring(19);
            }
            catch
            {
                    _qaAnalystPageObjects.btnSeeAll.Click();
                    firstLocation = _qaAnalystPageObjects.txtFirstLocation.Text;
                    _qaAnalystPageObjects.closeLocationModal.Click();

                    return firstLocation; 
            }
        }

        public string GetFirstSentenceOfTheSecondParagraph()
        {
           
            string fullText = _qaAnalystPageObjects.fullJobDescription.Text;
       
            string[] allParagraphs = fullText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            string thirdParagraph = allParagraphs[1];

            string[] thirdParagraphSentences = thirdParagraph.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            return thirdParagraphSentences[0].Trim() + ".";

        }

        public string GetSecondBulletPoint(string header)
        {
            string fullText = _qaAnalystPageObjects.fullJobDescription.Text;

            // Split into lines
            var lines = fullText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            int startIndex = Array.FindIndex(lines, line => line.Trim().Equals(header, StringComparison.OrdinalIgnoreCase));
            if (startIndex == -1)
                return "Header not found.";

            List<string> sectionLines = new List<string>();

            // Start collecting lines after the header
            for (int i = startIndex + 1; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (string.IsNullOrWhiteSpace(line))
                    break; // Stop at first blank line

                sectionLines.Add(line);
            }

            return sectionLines.Count >= 2 ? sectionLines[1] : "Second line not found.";

        }

        public string GetTheFirstBenefit()
        {
            string fullText = _qaAnalystPageObjects.fullJobDescription.Text;

            if (string.IsNullOrWhiteSpace(fullText))
                return "Text is empty.";

            // Look for the benefits introduction phrase
            string keyword = "Employees regularly scheduled to work 20 or more hours per week are eligible for comprehensive benefits including:";
            int startIndex = fullText.IndexOf(keyword, StringComparison.OrdinalIgnoreCase);

            if (startIndex == -1)
                return "Benefits phrase not found.";

            // Get the portion of the text after the keyword
            string remainingText = fullText.Substring(startIndex + keyword.Length).Trim();

            if (string.IsNullOrWhiteSpace(remainingText))
                return "No benefits listed after keyword.";

            // Split by comma to get the list of benefits
            string[] benefits = remainingText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            // Return the first benefit
            return benefits.Length > 0 ? benefits[0].Trim() : "No individual benefits found.";
        }

        public void StartApplying()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", _qaAnalystPageObjects.btnApplyNow);

            Thread.Sleep(500);

            var originalTab = _driver.CurrentWindowHandle;

            _qaAnalystPageObjects.btnApplyNow.Click();

            // Wait for new tab to open
            Thread.Sleep(2000); // Replace with proper wait if needed

            // Get all open window handles
            var windowHandles = _driver.WindowHandles;
            _driver.Close();

            // Switch to the newest tab (last handle)
            _driver.SwitchTo().Window(windowHandles.Last());
        }
    }
}
