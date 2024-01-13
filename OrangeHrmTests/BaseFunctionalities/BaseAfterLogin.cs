using OrangeHrmTestingGuiFramework.Driver;
using OrangeHrmTestingGuiFramework.Pages;
using OrangeHrmTests.Tests;
using OrangeHrmTests.UnitTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHrmTests.BaseFunctionalities
{
    public class BaseAfterLogin
    {
        internal readonly IDriverFixture _driverFixture;
        internal readonly IDriverWait _driverWait;
        internal readonly ILoginPage _loginPage;
        internal readonly ITabPanel _tabPanel;

        public BaseAfterLogin(IDriverFixture driverFixture, IDriverWait driverWait, ILoginPage loginPage, ITabPanel tabPanel)
        {
            _driverFixture = driverFixture;
            _driverWait = driverWait;
            _loginPage = loginPage;
            _tabPanel = tabPanel;
            _driverFixture.NavigateToMainPage();
            _loginPage.Login();
        }

        private protected string CurrentUrl => _driverWait.GetCurrentUrl();

        /*private bool Login()
        {
            var startPage = CurrentUrl;

            _homePage.SetUserName(AdminName);
            _homePage.SetPassword(Password);
            _homePage.Confirm();

            return _driverWait.CheckIfPageChanged(startPage);
        }*/

    }
}
