using OpenQA.Selenium;

namespace OrangeHrmTestingGuiFramework.Driver
{
    public interface IDriverFixture
    {
        IWebDriver Driver { get; }
    }
}
