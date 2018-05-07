using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.Domain
{
    /// <summary>
    /// Represents a physical address of a property.
    /// </summary>
    public class PropertyAddress : Location
    {
        /// <summary>
        /// The unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The street address.
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// The full address. This property is read-only.
        /// </summary>
        public string FullAddress 
        {
            get { return this.StreetAddress + ", " + this.Suburb.Name + ", " + this.State.Abbreviation + " " + this.Suburb.PostCode; }
        }
    }
}
