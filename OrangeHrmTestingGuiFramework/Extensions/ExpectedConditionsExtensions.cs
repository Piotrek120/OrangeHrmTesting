using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHrmTestingGuiFramework.Extensions
{
    using OpenQA.Selenium;

    public static class ExpectedConditionsExtensions
    {
        public static Func<IWebDriver, bool> ElementIsVisible(By locator)
        {
            return (driver) =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            };
        }

        public static Func<IWebDriver, bool> PathsEquals(string startPage, Func<string> expectedPage)
        {
            //return startPage == expectedPage();
            return (driver) =>
            {
                try
                {
                    var condition = startPage == expectedPage();
                    return condition;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            };
        }
    }

}
