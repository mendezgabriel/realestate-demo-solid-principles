using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.Domain
{
    /// <summary>
    /// Represents a suburb or area within a <see cref="City"/>.
    /// </summary>
    public class Suburb : Entity
    {
        /// <summary>
        /// The suburb's postal code.
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// The suburb/area name.
        /// </summary>
        public string Name { get; set; }
    }
}
