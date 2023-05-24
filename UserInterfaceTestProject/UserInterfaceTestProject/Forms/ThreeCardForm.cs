using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace UserInterfaceTestProject
{
    public class ThreeCardForm : Form
    {
        public ThreeCardForm() : base(By.XPath("//*[contains(@class,'page-indicator') and contains(text(),'3')]"), "Card 3 Form"){}

    }
}
