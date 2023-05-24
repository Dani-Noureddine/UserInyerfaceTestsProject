using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UserInterfaceTestProject
{
    public class TwoCardForm : Form
    {
        private static ISettingsFile TestData => new JsonSettingsFile("testData.json");
        private  static int[] InterestIndexes = RandomUtils.GetRandomInterestIndex();
        private ICheckBox unselectAllCheckbox = ElementFactory.GetCheckBox(By.XPath("//*[@for='interest_unselectall']"), "Unselect All Checkbox");
        private ICheckBox randomInterest1 = ElementFactory.GetCheckBox(By.XPath(GetRandomInterestXPath(InterestIndexes[0])), "Random Interest 1");
        private ICheckBox randomInterest2 = ElementFactory.GetCheckBox(By.XPath(GetRandomInterestXPath(InterestIndexes[1])), "Random Interest 2");
        private ICheckBox randomInterest3 = ElementFactory.GetCheckBox(By.XPath(GetRandomInterestXPath(InterestIndexes[2])), "Random Interest 3");
        private IButton uploadImage = ElementFactory.GetButton(By.XPath("//*[contains(@class,'avatar-and-interests__upload-button')]"), "Upload image Button");
        private IButton nextButton = ElementFactory.GetButton(By.XPath("//*[@name='button' and contains(text(),'Next')]"), "Next Button");
       
        public TwoCardForm() : base(By.XPath("//*[contains(@class,'page-indicator') and contains(text(),'2')]"), "Card 2 Form"){}

        public void CheckUnselectAll()
        {
            unselectAllCheckbox.Click();
        }
        public void CheckThreeRandomInterests()
        {
            randomInterest1.Click();
            randomInterest2.Click();
            randomInterest3.Click();
        }
        public void UploadImage()
        {
            uploadImage.Click();
            string pathToImage = Directory.GetCurrentDirectory();
            AutoItXUtils.UploadFile(pathToImage+TestData.GetValue<string>("UploadFilePath"));
        }
        public void ClickNext()
        {
            nextButton.Click();
        }
        private static string GetRandomInterestXPath(int IndexOfInterest)
        {
            return $"(//*[contains(@class,'checkbox') and contains(@class,'small')])[{IndexOfInterest}]";
        }
    }
}
