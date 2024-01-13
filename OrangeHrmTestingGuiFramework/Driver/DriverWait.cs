#region Usings

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHrmTestingGuiFramework.Config;
using OrangeHrmTestingGuiFramework.Extensions;

#endregion

namespace OrangeHrmTestingGuiFramework.Driver
{
    /// <summary>
    ///     The driver wait.
    /// </summary>
    public class DriverWait : IDriverWait
    {
        #region Properties

        /// <summary>
        ///     The driver fixture.
        /// </summary>
        private IDriverFixture DriverFixture { get; init; }

        /// <summary>
        ///     The test settings.
        /// </summary>
        private TestParameters TestSettings { get; init; }

        /// <summary>
        ///     The webDriver Wait.
        /// </summary>
        private Lazy<WebDriverWait> WebDriverWait { get; init; }

        #endregion

        #region Constructors

        /// <summary>
        ///     The driver wait.
        /// </summary>
        /// <param name="driverFixture">
        ///     The driver fixture.
        /// </param>
        /// <param name="testSettings">
        ///     The test settings.
        /// </param>
        public DriverWait(IDriverFixture driverFixture, TestParameters testSettings)
        {
            DriverFixture = driverFixture;
            TestSettings = testSettings;
            WebDriverWait = new Lazy<WebDriverWait>(GetWaitDriver);
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Find IWebElement by element locator.
        /// </summary>
        /// <param name="elementLocator">
        ///     The element locator.
        /// </param>
        /// <returns>
        ///     The found IWebElement.
        /// </returns>
        public IWebElement FindElement(By elementLocator)
        {
            return WebDriverWait.Value.Until(_ => DriverFixture.Driver.FindElement(elementLocator));
        }

        /// <summary>
        ///     Find IWebElements by element locator.
        /// </summary>
        /// <param name="elementLocator">
        ///     The element locator.
        /// </param>
        /// <returns>
        ///     The found IWebElements.
        /// </returns>
        public IEnumerable<IWebElement> FindElements(By elementLocator)
        {
            return WebDriverWait.Value.Until(_ => DriverFixture.Driver.FindElements(elementLocator));
        }

        public string GetCurrentUrl()
        {
            if (WaitForPageLoad())
            {
                return DriverFixture.CurrentUrl;
            }

            return string.Empty;
        }


        public bool CheckIfElementExist(By selector)
        {
            return WebDriverWait.Value.Until(ExpectedConditionsExtensions.ElementIsVisible(selector));
        }

        public bool WaitForPageLoad()
        {
            return WebDriverWait.Value.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Get wait driver.
        /// </summary>
        /// <returns>
        ///     The WebDriverWait.
        /// </returns>
        public WebDriverWait GetWaitDriver()
        {
            return new(DriverFixture.Driver, timeout: TimeSpan.FromSeconds(TestSettings.TimeoutInterval ?? 20))
            {
                PollingInterval = TimeSpan.FromSeconds(1),
            };
        }

        #endregion
    }
}
