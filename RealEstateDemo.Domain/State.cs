using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.Domain
{
    /// <summary>
    /// Represents a state within a <see cref="Country"/>.
    /// </summary>
    public class State : Entity
    {
        /// <summary>
        /// The state's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The state's abbreviation if applicable.
        /// </summary>
        public string Abbreviation { get; set; }
    }
}
