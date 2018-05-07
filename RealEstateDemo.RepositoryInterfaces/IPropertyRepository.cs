using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateDemo.Common;
using RealEstateDemo.Domain;
using RealEstateDemo.RepositoryInterfaces.Base;

namespace RealEstateDemo.RepositoryInterfaces
{
    /// <summary>
    /// Defines the contracts for repositories handling <see cref="Domain.Property"/> objects.
    /// </summary>
    public interface IPropertyRepository : IQueryableRepository<Property>
    {
        /// <summary>
        /// Gets a collection of the available locations.
        /// </summary>
        /// <returns>The resulting collection.</returns>
        IEnumerable<Location> GetAvailableLocations();

        /// <summary>
		/// Gets a collection of <see cref="TEntity"/> by a specified expression.
		/// </summary>
        /// <param name="suburb">The suburb used for filtering.</param>
        /// <param name="priceRange">The price range used for filtering.</param>
		/// <returns>A collection of <see cref="TEntity"/> matching the filtering expression.</returns>
        IEnumerable<Property> FindBy(Suburb suburb, PriceRange priceRange);

        /// <summary>
		/// Adds an enquiry to a property.
		/// </summary>
		/// <param name="property">The <see cref="Property"/> object that is the subject of the enquiry.</param>
		/// <param name="enquiry">The <see cref="Enquiry"/> details.</param>
        void AddEnquiry(Property property, Enquiry enquiry);
    }
}
