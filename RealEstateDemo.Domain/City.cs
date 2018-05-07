using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.Domain
{
    /// <summary>
    /// Represents a populated area within a <see cref="State"/>.
    /// </summary>
    public class City :  Entity
    {
        /// <summary>
        /// The name of the city.
        /// </summary>
        public string Name { get; set; }
    }
}
