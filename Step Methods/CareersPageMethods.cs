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
    }
}
