using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;


namespace UserInterfaceTestProject
{
    public class HelpForm :Form
    {
        private IButton closeButton = ElementFactory.GetButton(By.XPath("//*[contains(@class,'button') and contains(@class,'button--solid') and contains(@class,'button--blue') and contains(@class,'help-form__send-to-bottom-button')]"), "Close Help form button");
        
        public HelpForm():base(By.XPath("//*[@class='help-form']"), "Help Form"){}
       
        public void CloseHelpForm()
        {
            closeButton.Click();
        }
    }
}
