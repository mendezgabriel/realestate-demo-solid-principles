using System.Collections.Generic;
using System.Reflection;
using RealEstateDemo.Business;
using RealEstateDemo.BusinessInterfaces;
using RealEstateDemo.DataAccess.Domain.Mapping.Mappers;
using RealEstateDemo.DataAccess.NPoco.Repositories;
using RealEstateDemo.DependencyResolution.AppStart;
using RealEstateDemo.Domain;
using RealEstateDemo.RepositoryInterfaces;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using localDbEntities = RealEstateDemo.DataAccess.Domain.Entities;
using RealEstateDemo.DataAccess.NPoco;
using RealEstateDemo.DataAccess.EntityFramework.Repositories;
using RealEstateDemo.DataAccess.EntityFramework;
using RealEstateDemo.Common.Interfaces;
using NPoco;
using RealEstateDemo.RepositoryInterfaces.Base;
using System.Data.Entity;
using System.Web.Mvc;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(CompositionRoot), "Start")]

namespace RealEstateDemo.DependencyResolution.AppStart
{
	/// <summary>
	/// Provides the dependency resolution entry point for configuration.
	/// </summary>
    public class CompositionRoot
    {
		/// <summary>
		/// The IoC container.
		/// </summary>
		/// <remarks>Simple injector is the one chosen because of its simplicity and speed compared to others.
		/// For more info go to http://simpleinjector.codeplex.com </remarks>
		readonly Container container;

		/// <summary>
		/// Creates a new instance of this.
		/// </summary>
		public CompositionRoot()
		{
			this.container = new Container();
		}

		/// <summary>
		/// Gets executed when the application starts.
		/// </summary>
		public static void Start()
		{
			new CompositionRoot().RegisterServices();
		}

		/// <summary>
		/// Registers the application services within the IoC container.
		/// </summary>
		private void RegisterServices()
		{
            RegisterConfigurationSettings();
			RegisterDataAccess();
			RegisterBusiness();
			RegisterControllers();

			container.Verify();
		}

        /// <summary>
        /// Registers the application's configuration settings.
        /// </summary>
        private void RegisterConfigurationSettings()
        {
            container.Register<IDatabaseConfigurationSettings>(() => new ConfigurationSettings
            {
                ConnectionStringName = "Database"
            });
        }

		/// <summary>
		/// Registers the data access interfaces and concrete implementations.
		/// </summary>
		private void RegisterDataAccess()
		{
            RegisterNPocoDataRepositories();
            //RegisterEntityFrameworkRepositories();

            RegisterDbToDomainEntitiesMappers();
		}

        /// <summary>
        /// Registers the data repository implementation using NPoco
        /// </summary>
        private void RegisterNPocoDataRepositories()
        {
            container.RegisterSingle<IDbContext<IDatabase>, NPocoDbContext>();
            container.Register<IPropertyRepository, NPocoPropertyRepository>();
        }

        private void RegisterEntityFrameworkRepositories()
        {
            container.RegisterSingle<IDbContext<DbContext>, EFDbContext>();
            container.Register<IPropertyRepository, EFPropertyRepository>();
        }

        /// <summary>
        /// Registers the domain object mappers from the database domain objects.
        /// </summary>
        private void RegisterDbToDomainEntitiesMappers()
        {
            container.Register<IMapper<localDbEntities.LocationInformation, Location>, LocationMapper>();
            container.Register<IMapper<localDbEntities.PropertyInformation, Property>, PropertyMapper>();
            container.Register<IMapper<localDbEntities.PropertyPhoto, PropertyPhoto>, PropertyPhotoMapper>();
            container.Register<IMapper<KeyValuePair<Property, Enquiry>, localDbEntities.PropertyEnquiry>, PropertyEnquiryMapper>();
        }

		/// <summary>
		/// Registers the business interfaces and concrete implementations.
		/// </summary>
		private void RegisterBusiness()
		{
			container.Register<IPropertyProcessor, PropertyProcessor>();
		}

		/// <summary>
		/// Registers the MVC controllers' dependencies.
		/// </summary>
		private void RegisterControllers()
		{
			container.RegisterMvcControllers(Assembly.GetExecutingAssembly());			
			container.RegisterMvcIntegratedFilterProvider();
			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
		}
    }
}
