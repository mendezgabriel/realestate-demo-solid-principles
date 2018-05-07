using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.Domain
{
    /// <summary>
    /// Represents a country in the world.
    /// </summary>
    public class Country : Entity
    {
        /// <summary>
        /// The name of the country.
        /// </summary>
        public string Name { get; set; }
    }
}
