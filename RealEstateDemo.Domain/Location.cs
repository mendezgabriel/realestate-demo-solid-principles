using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.Domain
{
    /// <summary>
    /// Represents a physical location in an area of a city.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// The country in which the property exists.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// The state/territory of the country in which the property exists.
        /// </summary>
        public State State { get; set; }

        /// <summary>
        /// The city of the state in which the property exists.
        /// </summary>
        public City City { get; set; }

        /// <summary>
        /// The suburb of the state and country in which the property exists.
        /// </summary>
        public Suburb Suburb { get; set; }
    }
}
