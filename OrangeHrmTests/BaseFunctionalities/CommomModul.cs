using OrangeHrmTestingGuiFramework.Driver;
using OrangeHrmTestingGuiFramework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHrmTests.BaseFunctionalities
{
    public class CommomModul : IClassFixture<DriverFixture>
    {
        private protected readonly IDriverFixture _driverFixture;
        private protected readonly IDriverWait _driverWait;
        private protected readonly ILoginPage _homePage;

        private protected string CurrentUrl => _driverWait.GetCurrentUrl();

        public CommomModul(IDriverFixture driverFixture, IDriverWait driverWait, ILoginPage homePage)
        {
            _driverFixture = driverFixture;
            _driverWait = driverWait;
            _homePage = homePage;
            _driverFixture.NavigateToMainPage();
        }
    }
}