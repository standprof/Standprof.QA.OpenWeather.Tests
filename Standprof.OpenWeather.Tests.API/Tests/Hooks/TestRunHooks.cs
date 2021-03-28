using System;
using System.IO;
using Standprof.QA.Common;
using TechTalk.SpecFlow;

namespace Standprof.OpenWeather.Tests.API.Tests.Hooks
{
    [Binding]
    internal static class TestRunHooks
    {
        private static readonly string _configRelativeFolder = @".\Config";

        [BeforeTestRun]
        public static void SetGlobalProperties()
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

            TestConfig.InitializeGlobalSettings();
            TestConfig.CreateLogsFolder();

            var testEnvironmentConfigFile = $@"{_configRelativeFolder}\{TestConfig.TestEnvironment}.json";
            // Read API URLs for the target environment 
            Helpers.TestConfig.BaseUrl = TestConfig.ReadAppSetting(testEnvironmentConfigFile, "BaseUrl");

            Helpers.TestConfig.ApiId = Environment.GetEnvironmentVariable("OpenWeatherAppId");
        }
    }
}