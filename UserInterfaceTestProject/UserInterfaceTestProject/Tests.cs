using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using NUnit.Allure.Core;

namespace UserInterfaceTestProject
{
    [AllureNUnit]
    public class Tests : BaseTest
    {
        private static ISettingsFile TestData => new JsonSettingsFile("testData.json"); //test commit for jenkins build
        [Test]
        public void FillInPageCardsTest()
        {
            MainPageForm mainPage = new MainPageForm();
            Assert.True(mainPage.State.IsDisplayed, "Main Page did not open");
            mainPage.GoToNextPage();
            OneCardForm oneCard = new OneCardForm();
            Assert.True(oneCard.State.IsDisplayed, "Card 1 page did not open");
            oneCard.FillInForm();
            oneCard.ClickNextButton();
            TwoCardForm twoCard = new TwoCardForm();
            Assert.True(twoCard.State.IsDisplayed, "Card 2 page did not open");
            twoCard.CheckUnselectAll();
            twoCard.CheckThreeRandomInterests();
            twoCard.UploadImage();
            twoCard.ClickNext();
            ThreeCardForm threeCard = new ThreeCardForm();
            Assert.True(threeCard.State.IsDisplayed, "Card 3 page did not open");
        }
        [Test]
        public void HideHelpFormTest()
        {
            MainPageForm mainPage = new MainPageForm();
            Assert.True(mainPage.State.IsDisplayed, "Main Page did not open");
            mainPage.GoToNextPage();
            OneCardForm oneCard = new OneCardForm();
            Assert.True(oneCard.State.IsDisplayed, "Card 1 page did not open");
            HelpForm helpForm = new HelpForm();
            Assert.True(helpForm.State.IsDisplayed, "Help form is not displayed");
            helpForm.CloseHelpForm();
            Assert.False(helpForm.State.IsExist, "Help form is still displayed");
        }
        [Test]
        public void AcceptCookiesTest()
        {
            MainPageForm mainPage = new MainPageForm();
            Assert.True(mainPage.State.IsDisplayed, "Main Page did not open");
            mainPage.GoToNextPage();
            OneCardForm oneCard = new OneCardForm();
            Assert.True(oneCard.State.IsDisplayed, "Card 1 page did not open");
            AqualityServices.ConditionalWait.WaitForTrue(oneCard.CookiesArePresent);
            oneCard.AcceptCookies();
            Assert.True(oneCard.CookiesAreNotPresent(), "Cookies are still present");
        }
        [Test]
        public void VerifyTimerStartTimeTest()
        {
            MainPageForm mainPage = new MainPageForm();
            Assert.True(mainPage.State.IsDisplayed, "Main Page did not open");
            mainPage.GoToNextPage();
            OneCardForm oneCard = new OneCardForm();
            Assert.True(oneCard.State.IsDisplayed, "Card 1 page did not open");
            Assert.That(oneCard.GetTimerValue(),Is.EqualTo(TestData.GetValue<string>("StartTimeOfTimer")), "Timer did not start at a proper time based on test data");
        }
    }
}