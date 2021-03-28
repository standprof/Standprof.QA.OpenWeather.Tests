using System.Net;
using FluentAssertions;
using RestSharp;
using TechTalk.SpecFlow;

namespace Standprof.OpenWeather.Tests.API.Tests.Steps
{
    [Binding]
    public sealed class CommonSteps:BaseStepsApi
    {
        public IRestResponse Response => TheScenarioContext.Get<IRestResponse>();

        [Then(@"the response status code should be ""(.*)""")]
        public void ThenTheResponseStatusCodeShouldBe(HttpStatusCode statusCode)
        {
            Response.StatusCode.Should().Be(statusCode);
        }
        public CommonSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }
    }
}
