
using RealEstateDemo.DataAccess.EntityFramework.DbEntitiesMapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RealEstateDemo.Common.Interfaces;
using RealEstateDemo.RepositoryInterfaces.Base;

namespace RealEstateDemo.DataAccess.EntityFramework
{
    /// <summary>
    /// DbContext's implementation using Entity Framework http://msdn.microsoft.com/en-au/data/ee712907
    /// </summary>
    public class EFDbContext : DbContext, IDbContext<DbContext>
    {
        static readonly Type dbEntitiesMappingType = typeof(PropertyPhotoMapping);

        /// <summary>
        /// Default constructor for the context.
        /// </summary>
        /// <param name="databaseConfigurationSettings">How to obtain the configuration setting applicable to the database.</param>
        public EFDbContext(IDatabaseConfigurationSettings databaseConfigurationSettings)
            : base(databaseConfigurationSettings.ConnectionStringName)
        {

        }

        /// <summary>
        /// Gets an instance of the context.
        /// </summary>
        /// <returns>The context instantiated.</returns>
        public DbContext GetInstance()
        {
            return this;
        }

        /// <summary>
        /// Applies customisations to Entity Framework's configuration.
        /// </summary>
        /// <param name="modelBuilder">Provides access to customise Entity Framework's mapping.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            AddCustomMappings(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Includes custom database domain poco objects with underlying DB objects.
        /// </summary>
        /// <param name="modelBuilder">Provides access to customise Entity Framework's mapping.</param>
        void AddCustomMappings(DbModelBuilder modelBuilder)
        {
            var dataAccessDomainAssembly = Assembly.GetAssembly(dbEntitiesMappingType);
            modelBuilder.Configurations.AddFromAssembly(dataAccessDomainAssembly);

            //modelBuilder.Configurations.Add(new LocationInformationMapping());
            //modelBuilder.Configurations.Add(new PropertyEnquiryMapping());
            //modelBuilder.Configurations.Add(new PropertyInformationMapping());
            //modelBuilder.Configurations.Add(new PropertyPhotoMapping());
        }

    }
}
