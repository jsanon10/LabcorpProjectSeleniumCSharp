using LabcorpAutomation.Page_Objects;
using OpenQA.Selenium;

namespace LabcorpAutomation.Step_Methods
{
    public class QAAnalystPageMethods
    {
        private readonly QAAnalystPageObjects _qaAnalystPageObjects;

        public QAAnalystPageMethods(IWebDriver driver)
        {
            _qaAnalystPageObjects = new QAAnalystPageObjects(driver);
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

            return fullText.Split(new[] { header }, StringSplitOptions.RemoveEmptyEntries)[1]
                .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();

        }
    }
}
