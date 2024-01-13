using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrangeHrmTestingGuiFramework.Pages;
using OrangeHrmTestingGuiFramework.Driver;
using OrangeHrmTests.BaseFunctionalities;

namespace OrangeHrmTests.Tests
{
    public class Login : CommomModul
    {
        /*private protected readonly IDriverFixture _driverFixture;
        private protected readonly IDriverWait _driverWait;
        private protected readonly IHomePage _homePage;*/

        public Login(IDriverFixture driverFixture, IDriverWait driverWait, ILoginPage homePage) : 
            base(driverFixture, driverWait, homePage)
        {
        }

        //private protected string CurrentUrl => _driverWait.GetCurrentUrl();

        [Theory]
        [InlineData("Admin", "admin123")]
        internal void LoginPositiveTest(string login, string pasword)
        {
            var isLoaded = _homePage.Login(login, pasword);

            Assert.True(isLoaded);
        }

        [Theory]
        [InlineData("Admin123", "admin123")]
        [InlineData("Adm", "admin123")]
        [InlineData("Admin", "admin")]
        internal void LoginNegativeTest(string login, string pasword)
        {
            var isLoaded = _homePage.Login(login, pasword);

            Assert.False(isLoaded);
        }
    }
}
