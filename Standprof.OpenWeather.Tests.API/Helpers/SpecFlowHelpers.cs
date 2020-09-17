using TechTalk.SpecFlow;

namespace Standprof.OpenWeather.Tests.API.Helpers
{
    internal static class SpecFlowHelpers
    {
        public static void ReAdd(this ScenarioContext context, string key, object value)
        {
            if (context.ContainsKey(key))
            {
                context.Remove(key);
                context.Add(key, value);
            }
            else
            {
                context.Add(key, value);
            }
        }
    }
}
