using OpenQA.Selenium;
using OrangeHrmTestingGuiFramework.Driver;
using OrangeHrmTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHrmTestingGuiFramework.Pages
{
    public class TabPanel : ITabPanel
    {
        private readonly IDriverWait _driver;

        private readonly string _urlHomePage;

        public TabPanel(IDriverWait driver)
        {
            _driver = driver;
            _urlHomePage = driver.GetCurrentUrl();
        }

        public Dictionary<string, IWebElement> TabsList =>
            new Dictionary<string, IWebElement>()
                {
                    { "Admin", AdminTab },
                    { "PIM", PimTab },
                    { "Leave", LeaveTab }
                };

        public IWebElement AdminTab => _driver.FindElement(By.XPath($".//span[text() = 'Admin']"));
        public IWebElement PimTab => _driver.FindElement(By.XPath($".//span[text() = 'PIM']"));
        public IWebElement LeaveTab => _driver.FindElement(By.XPath($".//span[text() = 'Leave']"));

        public string Title
        {
            get
            {
                _driver.WaitForPageLoad();
                return string.Join(" ", _driver.FindElements(By.XPath("//span/h6")).Select(x => x.Text));
            }
        }

    }
}
