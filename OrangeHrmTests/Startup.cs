using Microsoft.Extensions.DependencyInjection;
using OrangeHrmTestingGuiFramework.Config;
using OrangeHrmTestingGuiFramework.Driver;
using OrangeHrmTestingGuiFramework.Pages;
using OrangeHrmTests.UnitTests;

namespace OrangeHrmTests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton(ReaderConfig.ReadConfig())
                .AddScoped<IDriverFixture, DriverFixture>()
                .AddScoped<IDriverWait, DriverWait>()
                .AddScoped<ILoginPage, LoginPage>()
                .AddScoped<ITabPanel, TabPanel>();
        }
    }
}
