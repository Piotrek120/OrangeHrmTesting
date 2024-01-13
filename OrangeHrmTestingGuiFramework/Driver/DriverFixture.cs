using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OrangeHrmTestingGuiFramework.Config;
using OrangeHrmTestingGuiFramework.Enums;

namespace OrangeHrmTestingGuiFramework.Driver
{
    public class DriverFixture : IDriverFixture, IDisposable
    {
        private readonly TestParameters _testParameters;
        public string CurrentUrl => Driver.Url;
        public IWebDriver Driver {  get; set; }
        /*{
            get
            {
                return _testParameters.BrowserType switch
                {
                    BrowserType.Chrome => new ChromeDriver(),
                    BrowserType.Firefox => new FirefoxDriver(),
                    BrowserType.Safari => new SafariDriver(),
                    _ => new ChromeDriver()
                };
            }
        }*/

        private IWebDriver GetWebDriver()
        {
            return _testParameters.BrowserType switch
            {
                BrowserType.Chrome => new ChromeDriver(),
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Safari => new SafariDriver(),
                _ => new ChromeDriver()
            };
        }

        public DriverFixture(TestParameters testParameters)
        {
            _testParameters = testParameters;
            Driver = GetWebDriver();
            Driver.Navigate().GoToUrl(_testParameters.ApplicationUrl);
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
