using LabcorpAutomation.Page_Objects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LabcorpAutomation.Step_Methods
{
    public class QAAnalystPageMethods
    {
        private readonly QAAnalystPageObjects _qaAnalystPageObjects;
        private readonly IWebDriver _driver;

        public QAAnalystPageMethods(IWebDriver driver)
        {
            _qaAnalystPageObjects = new QAAnalystPageObjects(driver);
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
                //bool isLocationVisible = _careersPageObjects.positionLocationByID(positionId).Displayed;
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

        public string GetTheFirstSentence() 
        {
            char defaultLimit = '.';

            foreach (char ch in _qaAnalystPageObjects.txtFirstSentence.Text)
            {
                if (ch == '.' || ch == '!' || ch == '?')
                {
                    defaultLimit = ch;
                    break;
                }
            }
            var fSentence = _qaAnalystPageObjects.txtFirstSentence.Text.Split(defaultLimit);

            return fSentence[0];
        }

        public string GetFirstSentenceOfTheSecondParagraph()
        {
            char defaultLimit = '.';
            char[] exceptionString = { 'J', 'r' };
            char[] temp = new char[2];
            string firstSentence = string.Empty;

            foreach (char ch in _qaAnalystPageObjects.txtFirstSentenceSecondParagraph.Text)
            {

                if (ch == exceptionString[0])
                {
                    temp[0] = exceptionString[0];
                }
                else if (ch == exceptionString[1])
                {
                    temp[1] = exceptionString[1];
                }
                else if (ch != '.' || temp[0] !='J' || temp[1] != 'r')
                {
                    
                    temp[0] = ' ';

                    temp[1] = ' ';
                }


                if (ch == '.' || ch == '!' || ch == '?')
                {
                    if (temp[0] != 'J' && temp[1] != 'r')
                    {
                        defaultLimit = ch;
                        break;
                    }
                }

                firstSentence+= ch;
            }
            return firstSentence ;
        }

        public string GetTheFirstAutomationTool()
        {
      
           var fullString = _qaAnalystPageObjects.txtAutomationTools.Text.Split(":");
           string requiredTools = fullString[1].Trim();
           List<string> list = requiredTools.Split(",").ToList();

           string firstRequirment = list.FirstOrDefault();

           return firstRequirment;
              
        }

        public string GetFirstSentenceOfTheThirdParagraph()
        {
           
            string fullText = _qaAnalystPageObjects.fullJobDescription.Text;
       
            string[] allParagraphs = fullText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            string thirdParagraph = allParagraphs[2];

            string[] thirdParagraphSentences = thirdParagraph.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            return thirdParagraphSentences[0].Trim() + ".";

        }

        public string GetSecondBulletPoint(string header)
        {
            string fullText = _qaAnalystPageObjects.fullJobDescription.Text;
            string[] lines = fullText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            int startIndex = Array.FindIndex(lines, line => line.Trim().StartsWith(header));

            if (startIndex == -1)
                return "Header not found.";

            // Extract bullet points (lines that start with "-") after the header
            var bulletPoints = lines
                .Skip(startIndex + 1)
                .TakeWhile(line => line.Trim().StartsWith("-"))
                .Select(line => line.Trim())
                .ToList();

            if (bulletPoints.Count >= 2)
                return bulletPoints[1]; // Return the second bullet
            else
                return "Second bullet point not found.";

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
