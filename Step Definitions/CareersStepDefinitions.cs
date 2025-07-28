
using LabcorpAutomation.Context;
using LabcorpAutomation.Step_Methods;
using Reqnroll;
using Xunit;

namespace LabcorpAutomation.StepDefinitions
{
    [Binding]
    public sealed class CareersStepDefinitions
    {
        private readonly CareersPageMethods _careersPageMethods;
        private readonly QAAnalystPageMethods _qAAnalystPageMethods;
        private readonly HomePageMethods _homePageMethods;
        private readonly ApplicationPageMethods _applicationPageMethods;
        private readonly PositionDetailsContext _positionDetailsContext;

        public CareersStepDefinitions(
            CareersPageMethods careersPageMethods,
            QAAnalystPageMethods qAAnalystPageMethods,
            HomePageMethods homePageMethods,
            ApplicationPageMethods applicationPageMethods,
            PositionDetailsContext positionDetailsContext)
        {
            _careersPageMethods = careersPageMethods;
            _qAAnalystPageMethods = qAAnalystPageMethods;
            _homePageMethods = homePageMethods;
            _applicationPageMethods = applicationPageMethods;
            _positionDetailsContext = positionDetailsContext;
        }

        [Given(@"user navigates to the the URL")]
        public void GivenUserNavigatesToTheTheURL()
        {
            _homePageMethods.NavigateToHomePage();
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
        }

        [When(@"user clicks on the serached position from the list of results")]
        public void WhenUserClicksOnTheSerachedPositionFromTheListOfResults()
        {
            _careersPageMethods.SelectPositionFromResults(_positionDetailsContext.positionName);
        }

        [Then(@"Confirm that position's details from the list of results matches the details on its page")]
        public void ThenConfirmThatPositionsDetailsFromTheListOfResultsMatchesTheDetailsOnItsPage()
        {
            Assert.Equal(_positionDetailsContext.positionName, _qAAnalystPageMethods.GetTheJobTitle());
            Assert.Equal(_positionDetailsContext.positionID, _qAAnalystPageMethods.GetTheJobID());
            Assert.Equal(_positionDetailsContext.positionLocation, _qAAnalystPageMethods.GetTheJobLocation());
        }

        [Then(@"Confirm that the first sentence in the second intro paragraph is ""([^""]*)""")]
        public void ThenConfirmThatTheFirstSentenceInTheSecondIntroParagraphIs(string sentence)
        {
            Assert.Equal(sentence, _qAAnalystPageMethods.GetFirstSentenceOfTheSecondParagraph());
        }

        [Then("Confirm that the first sentence in the third paragraph is {string}")]
        public void ThenConfirmThatTheFirstSentenceInTheThirdParagraphIs(string sentence)
        {
            Assert.Equal(sentence, _qAAnalystPageMethods.GetFirstSentenceOfTheThirdParagraph());
        }

        [Then("Confirm that the second bullet point under header {string} is {string}")]
        public void ThenConfirmThatTheSecondBulletPointUnderHeaderIs(string header, string sentence)
        {
            Assert.Equal(sentence, _qAAnalystPageMethods.GetSecondBulletPoint(header));
        }

        [Then(@"Confirm that the first suggestion for Automation Tools is ""([^""]*)""")]
        public void ThenConfirmThatTheFirstSuggestionForAutomationToolsIs(string firstRequiredTool)
        {
            Assert.Equal(firstRequiredTool, _qAAnalystPageMethods.GetTheFirstAutomationTool());
        }

        [Then("Start applying for the job and verify the position details")]
        public void ThenStartApplyingForTheJobAndVerifyThePositionDetails()
        {
            _qAAnalystPageMethods.StartApplying();
        }

        [Then("Navigate back to the job search")]
        public void ThenNavigateBackToTheJobSearch()
        {
            //Assert.Equal(_positionDetailsContext.positionName, _applicationPageMethods.GetJobTitle());
            _applicationPageMethods.NavigateToCareerHome();
        }


    }
}
