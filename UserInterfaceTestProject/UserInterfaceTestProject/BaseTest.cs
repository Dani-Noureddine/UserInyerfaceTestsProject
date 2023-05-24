using AngleSharp.Dom;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace UserInterfaceTestProject
{
    public class BaseTest
    {
        Browser browser;
        private static ISettingsFile ConfigSettings => new JsonSettingsFile("config.json");
        [SetUp]
        public void Setup()
        {
            browser = AqualityServices.Browser;
            browser.Maximize();
            browser.GoTo(ConfigSettings.GetValue<string>("Url"));
            browser.WaitForPageToLoad();
        }
        [TearDown]
        public void TearDown()
        {
            browser.Quit();
        }
    }
}
