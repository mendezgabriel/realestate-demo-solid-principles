using NPoco;
using NPoco.FluentMappings;
using RealEstateDemo.Common.Interfaces;
using RealEstateDemo.DataAccess.NPoco.DbEntitiesMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.DataAccess.NPoco
{
    /// <summary>
    /// Configures the instance of the database object and initializes the mapping of the Db entities.
    /// </summary>
    public static class NPocoDbFactory
    {
        /// <summary>
        /// Gets or sets NPoco's Db factory.
        /// </summary>
        public static DatabaseFactory Factory { get; set; }

        /// <summary>
        /// Initializes the configuration and sets the <see cref="Factory"/> property.
        /// </summary>
        /// <remarks>Adapted from https://github.com/schotime/NPoco/wiki/Fluent-Mappings-including-Conventional
        /// </remarks>
        public static void Setup(IDatabaseConfigurationSettings databaseConfigurationSettings)
        {
            var fluentConfig = FluentMappingConfiguration.Configure(new IMap[]
            {
                new LocationInformationMapping(),
                new PropertyEnquiryMapping(),
                new PropertyInformationMapping(),
                new PropertyPhotoMapping()
            });

            Factory = DatabaseFactory.Config(x =>
            {
                x.UsingDatabase(() => new Database(databaseConfigurationSettings.ConnectionStringName));
                x.WithFluentConfig(fluentConfig);
            });
        }
    }
}
