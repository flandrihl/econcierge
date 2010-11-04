using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace eConcierge.Common
{
    public class AppSettingHelper
    {
        public static string GetValue(string key)
        {
            if(ConfigurationManager.AppSettings[key] != null)
            {
                return ConfigurationManager.AppSettings[key];
            }
            return string.Empty;
        }
    }
}
