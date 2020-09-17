using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Standprof.QA.Common;
using TechTalk.SpecFlow;

namespace Standprof.OpenWeather.Tests.API.Tests.Steps
{
    [Binding]

    public class BaseStepsApi
    {
        public ScenarioContext TheScenarioContext;

        public BaseStepsApi(ScenarioContext scenarioContext)
        {
            this.TheScenarioContext = scenarioContext ?? throw new ArgumentNullException("scenarioContext");
            var testContext = scenarioContext.ScenarioContainer.Resolve<TestContext>();
            CustomTestLogger = new CustomTestLogger(testContext);
        }

        public CustomTestLogger CustomTestLogger { get; private set; }
    }
}