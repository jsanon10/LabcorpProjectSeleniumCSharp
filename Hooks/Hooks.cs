
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Reqnroll.BoDi;
using LabcorpAutomation.Drivers;


namespace LabcorpAutomation.Hooks
{

    //[Binding]
    //public class Hooks
    //{
    //    private readonly IObjectContainer _objectContainer;
    //    private IWebDriver _driver;

    //    public Hooks(IObjectContainer objectContainer)
    //    {
    //        _objectContainer = objectContainer;
    //    }

    //    [BeforeScenario]
    //    public void Setup()
    //    {
    //        _driver = new ChromeDriver();
    //        _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
    //    }

    //    [AfterScenario]
    //    public void TearDown()
    //    {
    //        _driver?.Quit();
    //    }
    //}

    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            IWebDriver driver = DriverFactory.CreateDriver("chrome");

            // Register the driver so Reqnroll/BoDi can inject it
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _objectContainer.Resolve<IWebDriver>();
            driver.Quit();
        }
    }
}