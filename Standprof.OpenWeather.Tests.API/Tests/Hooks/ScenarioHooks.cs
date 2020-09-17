using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using Standprof.OpenWeather.Tests.API.Tests.Steps;
using Standprof.QA.Common;
using TechTalk.SpecFlow;

namespace Standprof.OpenWeather.Tests.API.Tests.Hooks
{
    [Binding]
    class ScenarioHooks:BaseStepsApi
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly TestContext _testContext;

        private readonly ScenarioLogging _scenarioLogger;

        public ScenarioHooks(ScenarioContext scenarioContext, FeatureContext featureContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;

            _testContext = _scenarioContext.ScenarioContainer
                .Resolve<TestContext>();


            _scenarioLogger = new ScenarioLogging(scenarioContext, featureContext);
        }

        [BeforeScenario(Order = 1)]
        public void AddKeysInScenarioContext()
        {
            _scenarioContext.Add("StepsText", "");
            _scenarioContext.Add("PreviousStepDefinitionType", "");
        }

        [BeforeScenario(Order = 2)]
        public void CreateEmptyRequest()
        {
            _scenarioContext.Set(new RestRequest());
        }

        [AfterScenario(Order = 1)]
        public void LogTestInformation()
        {
            _testContext.CustomTestLogger().Line();
            _testContext.CustomTestLogger().Trace("AfterScenario - LogTestInformation]");
            _scenarioLogger.LogScenarioInformation();
        }
        
        [AfterScenario(Order = 2)]
        public void SaveTestResultsToDb()
        {
            _scenarioLogger.SaveTestResultToAutomatedTestingDatabase();
        }

        public ScenarioHooks(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }
    }
}
