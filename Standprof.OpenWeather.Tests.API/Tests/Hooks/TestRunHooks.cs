using System;
using System.IO;
using Standprof.OpenWeather.Tests.API.Helpers;
using Standprof.QA.Common;
using TechTalk.SpecFlow;
using TestConfig = Standprof.OpenWeather.Tests.API.Helpers.TestConfig;

//using TestConfig = QA.MyProduct.Tests.API.Helpers.TestConfig;

namespace Standprof.OpenWeather.Tests.API.Tests.Hooks
{
    [Binding]
    static class TestRunHooks
    {
        private static readonly string _configRelativeFolder = @".\Config";

        [BeforeTestRun]
        public static void SetGlobalProperties()
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

            QA.Common.TestConfig.InitializeGlobalSettings();
            QA.Common.TestConfig.CreateLogsFolder();

            var testEnvironmentConfigFile = $@"{_configRelativeFolder}\{QA.Common.TestConfig.TestEnvironment}.json";
            var appIdFile = $@"{_configRelativeFolder}\appId.json";

            // Read API URLs for the target environment 
            TestConfig.BaseUrl = QA.Common.TestConfig.ReadAppSetting(testEnvironmentConfigFile, "BaseUrl");
            TestConfig.ApiId = QA.Common.TestConfig.ReadAppSetting(appIdFile, "ApiId");
        }
    }
}
