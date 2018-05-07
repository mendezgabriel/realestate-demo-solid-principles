using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.Domain
{
    /// <summary>
    /// The types of property that can be handled by the system.
    /// </summary>
    public enum PropertyType
    {
        /// <summary>
        /// The property type is unknown or not yet set.
        /// </summary>
        Unknown,

        /// <summary>
        /// The property is (or will be) available for sale.
        /// </summary>
        Sale,

        /// <summary>
        /// The property is (or will be) available for rent.
        /// </summary>
        Rent
    }
}
