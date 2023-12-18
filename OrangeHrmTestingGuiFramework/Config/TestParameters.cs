using OrangeHrmTestingGuiFramework.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHrmTestingGuiFramework.Config
{
    public class TestParameters
    {
        public BrowserType BrowserType { get; set; }
        public Uri ApplicationUrl { get; set; }
        public float? TimeoutInterval { get; set; }
    }
}
