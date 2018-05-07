using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.Domain
{
    /// <summary>
    /// Defines a property in the real-estate business. Examples of this can be: House, Car, Bike, Boat, Building, etc.
    /// </summary>
    public class Property : Entity
    {
        List<PropertyPhoto> photos = new List<PropertyPhoto>();
		List<Enquiry> enquiries = new List<Enquiry>();
        PropertyType type = PropertyType.Unknown;

        /// <summary>
        /// The property's price. Either used for rental or selling price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The property's address.
        /// </summary>
        public PropertyAddress Address { get; set; }

        /// <summary>
        /// The property's description or features.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the first 200 characters of the description. This property is read-only.
        /// </summary>
        public string ShortDescription
        {
            get {
                if (this.Description.Length > 200)
                    return new string(this.Description.Take(200).ToArray()) + "...";
                else
                    return this.Description;
            }
        }

        /// <summary>
        /// The photos associated to this property.
        /// </summary>
        public List<PropertyPhoto> Photos
        {
            get { return this.photos; }
            set { this.photos = value; }
        }

        /// <summary>
        /// The real estate agent that manages the property.
        /// </summary>
        public Agent Agent { get; set; }

        /// <summary>
        /// The type of the property.
        /// </summary>
        public PropertyType Type
        {
            get { return this.type; }
            internal set { this.type = value; }
        }

		/// <summary>
		/// The enquiries associated to this property.
		/// </summary>
		public List<Enquiry> Enquiries
		{
			get { return this.enquiries; }
			set { this.enquiries = value; }
		}
    }
}
