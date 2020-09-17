using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using Standprof.QA.Common;
using TechTalk.SpecFlow;

namespace Standprof.OpenWeather.Tests.API.Tests.Hooks
{
    [Binding]
    public sealed class ScenarioStepsHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly TestContext _testContext;
        private string _currentStep;

        public ScenarioStepsHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            _testContext = _scenarioContext.ScenarioContainer
                .Resolve<TestContext>();
        }

        [BeforeStep]
        public void SaveStepText()
        {
            // replace the step definition type with "And" if it is the same as the previous one

            var currentStepDefinitionType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var previousStepDefinitionType = _scenarioContext["PreviousStepDefinitionType"].ToString();

            var stepDefinitionType = currentStepDefinitionType == previousStepDefinitionType
                ? "And"
                : currentStepDefinitionType;

            _currentStep = string.Concat(stepDefinitionType, " ", _scenarioContext.StepContext.StepInfo.Text);

            _scenarioContext["StepsText"] = string.Join("\r\n", _scenarioContext["StepsText"],
                _currentStep);

            _testContext.CustomTestLogger().Step(_currentStep);

            // save the current step definition for the next step
            _scenarioContext["PreviousStepDefinitionType"] =
                _scenarioContext.StepContext.StepInfo.StepDefinitionType;
        }

        [AfterStep]
        public void MarkStepAsFailed()
        {
            if (_scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
            {
                var message = $@"Failed at step: '{_currentStep}' with the exception: " +
                              _scenarioContext.TestError.Message;
                message = message.Replace("{", "<").Replace("}", ">");

                _testContext.CustomTestLogger().Trace(message);
            }
        }

        #region private

        #endregion
    }
}