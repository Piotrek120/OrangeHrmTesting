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
    public class LoginPage : ILoginPage
    {
        private const string AdminName = "Admin";
        private const string Password = "admin123";

        private readonly IDriverWait _driver;

        //private readonly string _urlHomePage;

        public LoginPage(IDriverWait driver)
        {
            _driver = driver;
            //_urlHomePage = driver.GetCurrentUrl();
        }

        public IWebElement LoginElement => _driver.FindElement(By.XPath("//input[@name='username']"));
        public IWebElement PasswordElement => _driver.FindElement(By.XPath("//input[@type='password']"));
        public IWebElement ConfirmButton => _driver.FindElement(By.XPath("//button"));
        public bool IsPageVisible => _driver.CheckIfElementExist(By.XPath("//div[@class='orangehrm-login-layout']"));

        private void SetUserName(string userName)
        {
            LoginElement.SetInputValue(userName);
        }

        private void SetPassword(string password)
        {
            PasswordElement.SetInputValue(password);
        }

        private void Confirm()
        {
            ConfirmButton.Click();
        }

        public bool Login(string adminName, string password)
        {
            var startPage = _driver.GetCurrentUrl();

            this.SetUserName(adminName);
            this.SetPassword(password);
            this.Confirm();

            return _driver.CheckIfPageChanged(startPage);
        }

        public bool Login() => Login(AdminName, Password);

    }
}
