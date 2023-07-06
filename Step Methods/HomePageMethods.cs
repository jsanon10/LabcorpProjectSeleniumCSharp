using LabcorpProject.Page_Objects;


namespace LabcorpProject.Step_Methods
{
    internal class HomePageMethods
    {
        HomePageObjects _homePageObjects = new HomePageObjects();

        public void ClickOnTheCareersLink()
        {
            _homePageObjects.linkCareers.Click();

        }
    }
}
