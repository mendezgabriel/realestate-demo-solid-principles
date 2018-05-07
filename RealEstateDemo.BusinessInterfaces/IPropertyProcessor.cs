using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateDemo.Common;
using RealEstateDemo.Domain;

namespace RealEstateDemo.BusinessInterfaces
{
    /// <summary>
    /// Defines the contract methods for the business layer in order to process a <see cref="Domain.Property"/> object.
    /// </summary>
    public interface IPropertyProcessor
    {
        /// <summary>
        /// Gets a list of matching properties by <paramref name="suburb"/> and <paramref name="priceRange"/>.
        /// </summary>
        /// <param name="suburb">The <see cref="Suburb"/> on which the property is located.</param>
        /// <param name="priceRange">The price range used to filter the properties.</param>
        /// <returns>A list of matching properties.</returns>
        List<Property> FindMatchingPropertiesBy(Suburb suburb, PriceRange priceRange);

        /// <summary>
        /// Finds a property by its Id
        /// </summary>
        /// <param name="id">The property's identifier.</param>
        /// <returns>The object found.</returns>
        Property FindBy(int id);

        /// <summary>
        /// Adds an enquiry to a property.
        /// </summary>
        /// <param name="property">The <see cref="Property"/> object that is the subject of the enquiry.</param>
        /// <param name="enquiry">The <see cref="Enquiry"/> details.</param>
        void AddEnquiry(Property property, Enquiry enquiry);

        /// <summary>
        /// Gets a list of matching locations by <paramref name="suburb"/>.
        /// </summary>
        /// <param name="suburb">The search criteria used by the filter.</param>
        /// <returns>A list of matching locations.</returns>
        List<Location> FindMathingLocationsBy(string searchText);
    }
}
