using LabcorpProject.Context;
using LabcorpProject.Drivers;
using LabcorpProject.Step_Methods;
using NUnit.Framework;


namespace LabcorpProject.StepDefinitions
{
    [Binding]
    public sealed class CareersStepDefinitions 
    {
        CareersPageMethods _careersPageMethods = new CareersPageMethods();
        QAAnalystPageMethods _qAAnalystPageMethods = new QAAnalystPageMethods();
        HomePageMethods _homePageMethods = new HomePageMethods();
        
        private readonly PositionDetailsContext _positionDetailsContext;

        public CareersStepDefinitions(PositionDetailsContext positionDetailsContext)
        {
            _positionDetailsContext = positionDetailsContext;      
        }

        [Given(@"user navigates to the the URL")]
        public void GivenUserNavigatesToTheTheURL()
        {
            //SeleniumDriver.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
            SeleniumDriver.driver.Navigate().GoToUrl("https://www.labcorp.com/");
        }

        [Given(@"user clicks on the Careers link")]
        public void GivenUserClicksOnTheCareersLink()
        {
            _homePageMethods.ClickOnTheCareersLink();
        }

        [When(@"user searches for position ""([^""]*)""")]
        public void WhenUserSearchesForPosition(string position)
        {
            _careersPageMethods.SearchPosition(position);
            _positionDetailsContext.positionName = position;
        }

        [When(@"user finds the searched position and retreives its details")]
        public void WhenUserFindsTheSearchedPositionAndRetreivesItsDetails()
        {
            _positionDetailsContext.positionID = _careersPageMethods.GetPositionID(_positionDetailsContext.positionName);
            _positionDetailsContext.positionLocation = _careersPageMethods.GetPositionLocation(_positionDetailsContext.positionID);
            _positionDetailsContext.firstSentence = _careersPageMethods.GetTheFirstSentenceFromSummary(_positionDetailsContext.positionID);
        }

        [When(@"user clicks on the serached position from the list of results")]
        public void WhenUserClicksOnTheSerachedPositionFromTheListOfResults()
        {
            string position = _positionDetailsContext.positionName;
            _careersPageMethods.SelectPositionFromResults(position);
        }

        [Then(@"Confirm that position's details from the list of results matches the details on its page")]
        public void ThenConfirmThatPositionsDetailsFromTheListOfResultsMatchesTheDetailsOnItsPage()
        {
            Assert.AreEqual(_positionDetailsContext.positionName, _qAAnalystPageMethods.GetTheJobTitle(), "The actual value and the expected value are not equal");
            Assert.AreEqual(_positionDetailsContext.positionID, _qAAnalystPageMethods.GetTheJobID(), "The actual value and the expected value are not equal");
            Assert.AreEqual(_positionDetailsContext.positionLocation, _qAAnalystPageMethods.GetTheJobLocation(), "The actual value and the expected value are not equal");
        }

        [Then(@"Confirm that the first sentence in the second intro paragraph is ""([^""]*)""")]
        public void ThenConfirmThatTheFirstSentenceInTheSecondIntroParagraphIs(string sentence)
        {
            Assert.AreEqual(sentence,_qAAnalystPageMethods.GetFirstSentenceOfTheSecondParagraph(), "The actual sentence doesn't match the expected sentence" );
        }

        [Then(@"Confirm that the first suggestion for Automation Tools is ""([^""]*)""")]
        public void ThenConfirmThatTheFirstSuggestionForAutomationToolsIs(string firstRequiredTool)
        {
            Assert.AreEqual(firstRequiredTool, _qAAnalystPageMethods.GetTheFirstAutomationTool(), "The actual first tool doesn't match the expected sentence");
        }
    }
}