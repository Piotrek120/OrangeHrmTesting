using OpenQA.Selenium;

namespace OrangeHrmTests
{
    public interface ITabPanel
    {
        Dictionary<string, IWebElement> TabsList {  get; }
        public string Title { get; }
    }
}