using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;
using RealEstateDemo.Common;
using RealEstateDemo.Common.Interfaces;
using RealEstateDemo.RepositoryInterfaces;
using RealEstateDemo.RepositoryInterfaces.Base;
using domainEntities = RealEstateDemo.Domain;
using localDbEntities = RealEstateDemo.DataAccess.Domain.Entities;

namespace RealEstateDemo.DataAccess.NPoco.Repositories
{
	/// <summary>
	/// Provides implementation details for the <see cref="IPropertyRepository"/>.
	/// </summary>
	public class NPocoPropertyRepository : IPropertyRepository
	{
        readonly IDatabase database;
        readonly IMapper<localDbEntities.LocationInformation, domainEntities.Location> locationMapper;
        readonly IMapper<localDbEntities.PropertyInformation, domainEntities.Property> propertyMapper;
        readonly IMapper<localDbEntities.PropertyPhoto, domainEntities.PropertyPhoto> photoMapper;
        readonly IMapper<KeyValuePair<domainEntities.Property, domainEntities.Enquiry>, localDbEntities.PropertyEnquiry> propertyEnquiryMapper;

        /// <summary>
        /// Creates a new instance of this.
        /// </summary>
        /// <param name="locationMapper">How to map <see cref="Location"/> objects.</param>
        /// <param name="propertyMapper">How to map <see cref="Property"/> objects.</param>
        /// <param name="photoMapper">How to map <see cref="Domain.PropertyPhoto"/> objects.</param>
        /// <param name="propertyEnquiryMapper">How to map <see cref="Entities.PropertyEnquiry"/> objects.</param>
        public NPocoPropertyRepository(IDbContext<IDatabase> context,
            IMapper<localDbEntities.LocationInformation, domainEntities.Location> locationMapper,
            IMapper<localDbEntities.PropertyInformation, domainEntities.Property> propertyMapper,
            IMapper<localDbEntities.PropertyPhoto, domainEntities.PropertyPhoto> photoMapper,
            IMapper<KeyValuePair<domainEntities.Property, domainEntities.Enquiry>, localDbEntities.PropertyEnquiry> propertyEnquiryMapper)
        {
            this.database = context.GetInstance();
            this.locationMapper = locationMapper;
            this.propertyMapper = propertyMapper;
            this.photoMapper = photoMapper;
            this.propertyEnquiryMapper = propertyEnquiryMapper;
        }

		/// <summary>
		/// Gets the  <see cref="TEntity"/> by its unique identifier.
		/// </summary>
		/// <param name="id">The entity's unique identifier.</param>
		/// <returns>An instance of  <see cref="TEntity"/>.</returns>
        public domainEntities.Property FindById(int id)
		{
            var dbProperty = database.Fetch<localDbEntities.PropertyInformation>()
                .Where(property => property.PropertyId == id).FirstOrDefault();

            if (dbProperty == null)
                throw new ApplicationException(string.Format("Could not find property with the id '{0}'.", id));

            var mappedProperty = propertyMapper.Map(dbProperty);
            mappedProperty.Photos = GetPropertyPhotos(dbProperty);
            return mappedProperty;
		}

		/// <summary>
		/// Gets a collection of <see cref="TEntity"/> by a specified expression.
		/// </summary>
        /// <param name="suburb">The suburb used for filtering.</param>
        /// <param name="priceRange">The price range used for filtering.</param>
		/// <returns>A collection of <see cref="TEntity"/> matching the filtering expression.</returns>
        public IEnumerable<domainEntities.Property> FindBy(domainEntities.Suburb suburb, PriceRange priceRange)
		{
            List<domainEntities.Property> properties = new List<domainEntities.Property>();

            var dbProperties = database.FetchWhere<localDbEntities.PropertyInformation>(dbProperty => dbProperty.Price >= priceRange.Minimum);
            if (suburb.Id > 0)
                dbProperties = dbProperties.Where(dbProperty => dbProperty.SuburbId == suburb.Id).ToList();
            if (priceRange.Maximum > 0)
                dbProperties = dbProperties.Where(dbProperty => dbProperty.Price <= priceRange.Maximum).ToList();

            dbProperties.ForEach(dbProperty => properties.Add(propertyMapper.Map(dbProperty)));

            return properties;
		}

        /// <summary>
        /// Gets a collection of the available locations.
        /// </summary>
        /// <returns>The resulting collection.</returns>
        public IEnumerable<domainEntities.Location> GetAvailableLocations()
        {
            List<domainEntities.Location> locations = new List<domainEntities.Location>();

            var dbLocations = database.Fetch<localDbEntities.LocationInformation>();
            dbLocations.ForEach(dblocation => locations.Add(locationMapper.Map(dblocation)));

            return locations;
        }

        /// <summary>
        /// Adds an enquiry to a property.
        /// </summary>
        /// <param name="property">The <see cref="Property"/> object that is the subject of the enquiry.</param>
        /// <param name="enquiry">The <see cref="Enquiry"/> details.</param>
        public void AddEnquiry(domainEntities.Property property, domainEntities.Enquiry enquiry)
        {
            var dbEnquiry = propertyEnquiryMapper.Map(new KeyValuePair<domainEntities.Property, domainEntities.Enquiry>(property, enquiry));
            database.Insert<localDbEntities.PropertyEnquiry>(dbEnquiry);
        }

        /// <summary>
        /// Gets the photos for a given property.
        /// </summary>
        /// <param name="dbProperty">The property object.</param>
        /// <returns>A collection of photos.</returns>
        private List<domainEntities.PropertyPhoto> GetPropertyPhotos(localDbEntities.PropertyInformation dbProperty)
        {
            var mappedPhotos = new List<domainEntities.PropertyPhoto>();
            var dbPropertyPhotos = database.Fetch<localDbEntities.PropertyPhoto>()
                            .Where(photo => photo.PropertyId == dbProperty.PropertyId).ToList();

            dbPropertyPhotos.ForEach(dbPhoto => mappedPhotos.Add(photoMapper.Map(dbPhoto)));

            return mappedPhotos;
        }
	}
}
