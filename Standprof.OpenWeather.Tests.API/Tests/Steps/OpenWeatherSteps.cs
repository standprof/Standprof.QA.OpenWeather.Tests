using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using Standprof.OpenWeather.Tests.API.Data.Models;
using Standprof.OpenWeather.Tests.API.Helpers;
using TechTalk.SpecFlow;

namespace Standprof.OpenWeather.Tests.API.Tests.Steps
{
    [Binding]
    public class OpenWeatherSteps:BaseStepsApi
    {
        private string _city;
        public IRestResponse Response => TheScenarioContext.Get<IRestResponse>();

        [Given(@"I have a city '(.*)'")]
        public void GivenIHaveACity(string city)
        {
            _city = city;
        }
        
        [When(@"I request the current weather for the city")]
        public void WhenIRequestTheCurrentWeatherForTheCity()
        {
            var client = new RestClient(TestConfig.BaseUrl);
            var request = new RestRequest($"weather");
            request.AddParameter("q", _city);
            request.AddParameter("appid", TestConfig.ApiId);
            var response = client.Execute(request);


            TheScenarioContext.Set(response);

            CustomTestLogger.Debug($"Request URI: {response.ResponseUri}");
            CustomTestLogger.AttachTextAsFile(response.Content, "RequestCurrentWeatherForCity", "json");
        }

        [Then(@"the Current Weather response should contain the city name")]
        public void ThenTheCurrentWeatherResponseShouldContainTheCityName()
        {
            var weatherForecast = JsonConvert.DeserializeObject<WeatherModel>(Response.Content);
            var city = weatherForecast.Name;

            city.Should().Be(_city);
        }


        public OpenWeatherSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }
    }
}
