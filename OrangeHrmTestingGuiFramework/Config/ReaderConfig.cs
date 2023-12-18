using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrangeHrmTestingGuiFramework.Config
{
    public static class ReaderConfig
    {
        /// <summary>
        ///     App settings json file name.
        /// </summary>
        private const string AppSettingsJsonFileName = "appsettings.json";

        /// <summary>
        ///     App settings json file path.
        /// </summary>
        private static string AppSettingsJsonFilePath => 
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), AppSettingsJsonFileName);

        /// <summary>
        ///     The read config.
        /// </summary>
        /// <returns>
        ///     The test parameters.
        /// </returns>
        public static TestParameters? ReadConfig()
        {
            var configFile = File.ReadAllText(AppSettingsJsonFilePath);

            var jsonSerializeOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            jsonSerializeOptions.Converters.Add(new JsonStringEnumConverter());

            return JsonSerializer.Deserialize<TestParameters>(configFile, jsonSerializeOptions);
        }
    }
}
