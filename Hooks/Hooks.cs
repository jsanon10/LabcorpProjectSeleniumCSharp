using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.ComponentModel;
using TechTalk.SpecFlow;
using LabcorpProject.Drivers;

namespace LabcorpProject.Hooks
{
    [Binding]
    public sealed class Hooks : SeleniumDriver
    {
        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            // Example of filtering hooks using tags. (in this case, this 'before scenario' hook will execute if the feature/scenario contains the tag '@tag1')
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=hooks#tag-scoping

            //TODO: implement logic that has to run before executing each scenario
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("-no-sandbox");

            SeleniumDriver.driver = new ChromeDriver(options);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            SeleniumDriver.driver.Quit();   

        }
    }
}