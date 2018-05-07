using RealEstateDemo.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.DependencyResolution.AppStart
{
    /// <summary>
    /// Holds the app's configuration values.
    /// </summary>
    public class ConfigurationSettings : IDatabaseConfigurationSettings
    {
        /// <summary>
        /// Gets or sets the connection string key name of the config file.
        /// </summary>
        public string ConnectionStringName { get; set; }
    }
}
