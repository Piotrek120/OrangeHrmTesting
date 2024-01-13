using OpenQA.Selenium;
using OrangeHrmTestingGuiFramework.Driver;
using OrangeHrmTestingGuiFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHrmTestingGuiFramework.Pages
{
    public class HomePage : IHomePage
    {
        private readonly IDriverWait _driver;

        private readonly string _urlHomePage;

        public HomePage(IDriverWait driver)
        {
            _driver = driver;
            _urlHomePage = driver.GetCurrentUrl();
        }

        public IWebElement LoginElement => _driver.FindElement(By.XPath("//input[@name='username']"));
        public IWebElement PasswordElement => _driver.FindElement(By.XPath("//input[@type='password']"));
        public IWebElement ConfirmButton => _driver.FindElement(By.XPath("//button"));
        public bool IsPageVisible => _driver.CheckIfElementExist(By.XPath("//div[@class='orangehrm-login-layout']"));

        public void SetUserName(string userName)
        {
            LoginElement.SetInputValue(userName);
        }

        public void SetPassword(string password)
        {
            PasswordElement.SetInputValue(password);
        }

        public void Confirm()
        {
            ConfirmButton.Click();
        }
    }
}
