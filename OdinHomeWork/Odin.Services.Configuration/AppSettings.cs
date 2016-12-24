using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Odin.Services.Configuration
{
    public class AppSettings
    {
        private AppSettings()
        {
            var properties = typeof(AppSettings).GetProperties();

            foreach (var property in properties)
            {
                var value = Convert.ChangeType(WebConfigurationManager.AppSettings[property.Name], property.PropertyType);
                if (value != null)
                    property.SetValue(this, value, null);
            }
        }

        private static AppSettings _instance;

        public static AppSettings Instance
        {
            get { return _instance ?? (_instance = new AppSettings()); }
        }

        /// <summary>
        /// Root directory for directory and files listing
        /// </summary>
        public string RootDirectoryPath { get; set; }

        /// <summary>
        /// Max view file size
        /// </summary>
        public long MaxFileSize { get; set; }
    }
}
