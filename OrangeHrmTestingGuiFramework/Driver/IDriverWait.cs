using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHrmTestingGuiFramework.Driver
{
    public interface IDriverWait
    {
        IWebElement FindElement(By elementLocator);
        IEnumerable<IWebElement> FindElements(By elementLocator);
        bool CheckIfElementExist(By elementLocator);
        string GetCurrentUrl();
        bool CheckIfPageChanged(string startPage);
        bool WaitForPageLoad();
    }
}
