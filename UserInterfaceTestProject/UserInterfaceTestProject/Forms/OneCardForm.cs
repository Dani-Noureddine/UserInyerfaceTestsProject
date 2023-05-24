using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;


namespace UserInterfaceTestProject
{
    public class OneCardForm :Form
    {
        private ITextBox passwordTextBox = ElementFactory.GetTextBox(By.XPath("//*[@placeholder='Choose Password']"),"Password Textbox");
        private ITextBox emailTextBox = ElementFactory.GetTextBox(By.XPath("//*[@placeholder='Your email']"), "Email Textbox");
        private ITextBox domainTextBox = ElementFactory.GetTextBox(By.XPath("//*[@placeholder='Domain']"), "Domain Textbox");
        private IComboBox dropDownExtensionHeader = ElementFactory.GetComboBox(By.XPath("//*[contains(@class,'dropdown__header')]"), "Drop down for email extensions"); 
        private ICheckBox termsAndConditonsCheckBox = ElementFactory.GetCheckBox(By.XPath("//*[contains(@class,'checkbox__box')]"), "Terms and conditions Checkbox");
        private IButton extensionChoice = ElementFactory.GetButton(By.XPath($"//*[contains(@class, 'dropdown__list')]//div[{RandomUtils.GenerateRandomExtensionIndex()}]"), "Extension Choice");
        private IButton nextButton = ElementFactory.GetButton(By.XPath("//*[@class='button--secondary']"), "Next Button");
        private IButton acceptCookiesButton = ElementFactory.GetButton(By.XPath("//*[@name='button' and contains(text(),'Not really, no')]"), "Accept Cookies button");
        private ILabel timerLabel = ElementFactory.GetLabel(By.XPath("//*[contains(@class,'timer') and contains(@class,'timer--white')]"), "Timer time Label");
        
        public OneCardForm() : base(By.XPath("//*[contains(@class,'page-indicator') and contains(text(),'1')]"), "Card 1 Form") {}
        
        public void FillInForm()
        {
            passwordTextBox.ClearAndType(RandomUtils.GenerateRandomValidPassword());
            emailTextBox.ClearAndType(RandomUtils.GenerateRandomEmail());
            domainTextBox.ClearAndType(RandomUtils.GenerateRandomDomain());
            dropDownExtensionHeader.Click();
            extensionChoice.Click();
            termsAndConditonsCheckBox.Click();
        }
        public void ClickNextButton()
        {
            nextButton.Click();
        }
        public void AcceptCookies()
        {
            acceptCookiesButton.Click();
        }
        public bool CookiesArePresent()
        {
            return acceptCookiesButton.State.IsClickable;
        }
        public bool CookiesAreNotPresent()
        {
            return !acceptCookiesButton.State.IsExist;
        }
        public string GetTimerValue()
        {
            return timerLabel.GetText();
        }
    }
}
