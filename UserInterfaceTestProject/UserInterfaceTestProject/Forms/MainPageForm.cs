using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UserInterfaceTestProject
{
    public class MainPageForm : Form
    {
        private IButton nextPageButton = ElementFactory.GetButton(By.XPath("//*[contains(@class,'start__link')]"), "Next Page button 'HERE' ");
        
        public MainPageForm(): base(By.XPath("//*[contains(@class,'start__link')]"), "Main Page"){}

        public void GoToNextPage()
        {
            nextPageButton.Click();
        }
    }
}
