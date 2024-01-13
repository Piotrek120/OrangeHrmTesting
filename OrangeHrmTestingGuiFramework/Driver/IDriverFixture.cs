using OpenQA.Selenium;

namespace OrangeHrmTestingGuiFramework.Driver
{
    public interface IDriverFixture
    {
        IWebDriver Driver { get; }
        string CurrentUrl { get; }
        void NavigateToMainPage ();
    }
}
