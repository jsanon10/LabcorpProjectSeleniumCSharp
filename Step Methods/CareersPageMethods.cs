using LabcorpAutomation.Page_Objects;
using OpenQA.Selenium;


namespace LabcorpAutomation.Step_Methods
{
    public class CareersPageMethods
    {
        private readonly CareersPageObjects _careersPageObjects;

        public CareersPageMethods(IWebDriver driver)
        {
            _careersPageObjects = new CareersPageObjects(driver);
        }

        public void SearchPosition(string position)
        {
            _careersPageObjects.inputJobSearchMain.SendKeys(position);
            _careersPageObjects.btnJobSearchMain.Click();
        }

        public void SelectPositionFromResults(string position)
        {

            _careersPageObjects.positionName(position).Click();

        }

        public string GetPositionID(string position)
        {
            return _careersPageObjects.positionID(position).Text;
        }

        public string GetPositionLocation(string positionId) 
        {

            try 
            {
                bool isLocationVisible = _careersPageObjects.positionLocationByID(positionId).Displayed;
                return _careersPageObjects.positionLocationByID(positionId).Text.Substring(19);
            }
            catch 
            {
                _careersPageObjects.locationsDropdown.Click();
                return _careersPageObjects.firstpositionLocationByID(positionId).Text;
            }         
        }

        public string GetTheFirstSentenceFromSummary(string id)
        {
            char defaultLimit = '.';
            char[] exceptionString = { 'J', 'r' };
            char[] temp = new char[2];
            string firstSentence = string.Empty;

            foreach (char ch in _careersPageObjects.summaryFirstSentenceByID(id).Text)
            {

                if (ch == exceptionString[0])
                {
                    temp[0] = exceptionString[0];
                }
                else if (ch == exceptionString[1])
                {
                    temp[1] = exceptionString[1];
                }
                else if (ch != '.' || temp[0] != 'J' || temp[1] != 'r')
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

                firstSentence += ch;
            }
            return firstSentence;
        }
    }
}
