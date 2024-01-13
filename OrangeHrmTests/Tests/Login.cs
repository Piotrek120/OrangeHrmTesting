using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrangeHrmTestingGuiFramework.Pages;
using OrangeHrmTestingGuiFramework.Driver;

namespace OrangeHrmTests.Tests
{
    public class Login
    {
        private readonly IDriverFixture _driverFixture;
        private readonly IDriverWait _driverWait;
        private readonly IHomePage _homePage;

        public string CurrentUrl => _driverWait.GetCurrentUrl();

        public Login(IDriverFixture driverFixture, IDriverWait driverWait, IHomePage homePage)
        {
            _driverFixture = driverFixture;
            _driverWait = driverWait;
            _homePage = homePage;
        }

        [Theory]
        [InlineData("Admin", "admin123")]
        public void LoginPositiveTest(string login, string pasword)
        {
            var startPage = CurrentUrl;

            _homePage.SetUserName(login);
            _homePage.SetPassword(pasword);
            _homePage.Confirm();

            var loadedPageAfterConfirm = CurrentUrl;

            Assert.False(startPage == loadedPageAfterConfirm);
        }

        [Theory]
        [InlineData("Admin123", "admin123")]
        [InlineData("Adm", "admin123")]
        [InlineData("Admin", "admin")]
        public void LoginNegativeTest(string login, string pasword)
        {
            var startPage = CurrentUrl;

            _homePage.SetUserName(login);
            _homePage.SetPassword(pasword);
            _homePage.Confirm();

            var loadedPageAfterConfirm = CurrentUrl;

            Assert.True(startPage == loadedPageAfterConfirm);
        }
    }
}
