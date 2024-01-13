using OrangeHrmTestingGuiFramework.Driver;
using OrangeHrmTestingGuiFramework.Pages;
using OrangeHrmTests.BaseFunctionalities;
using OrangeHrmTests.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHrmTests.UnitTests
{
    [Collection("Base after login collection")]
    public class MainPage
    {
        BaseAfterLogin _baseAfterLogin;

        public string CurrentUrl => _baseAfterLogin._driverWait.GetCurrentUrl();

        public MainPage(BaseAfterLogin baseAfterLogin)
        {
            _baseAfterLogin = baseAfterLogin;
        }

        [Theory]
        [InlineData("Admin", "Admin User Management")]
        [InlineData("PIM")]
        [InlineData("Leave")]
        public void SelectTabs(string nameTab, string expectedValue = "")
        {
            var startPage = CurrentUrl;
            expectedValue = expectedValue == string.Empty ? nameTab : expectedValue; 
            _baseAfterLogin._tabPanel.TabsList[nameTab].Click();
            _baseAfterLogin._driverWait.CheckIfPageChanged(startPage);
            var title = _baseAfterLogin._tabPanel.Title;
            Assert.True(title == expectedValue);
        }
    }
}
