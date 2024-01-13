using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHrmTestingGuiFramework.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHrmTestingGuiFramework.Extensions
{
    public static class WebElementExtension
    {
        public static void SetInputValue(this IWebElement element, string inputText)
        {
            element.Clear();
            element.SendKeys(inputText);
        }

        public static void ClearAndEnterText(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }
    }
}
