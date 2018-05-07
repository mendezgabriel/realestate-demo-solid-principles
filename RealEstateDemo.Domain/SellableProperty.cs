using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.Domain
{
    /// <summary>
    /// Defines a property that is available for sale.
    /// </summary>
    public class SellableProperty : Property
    {
        /// <summary>
        /// The date on which a sale auction will be performed. This date is optional.
        /// </summary>
        public DateTime? AuctionDate { get; set; }

        /// <summary>
        /// Creates a new instance of this.
        /// </summary>
        public SellableProperty()
        {
            SetPropertyType();
        }

        /// <summary>
        /// Creates a new instance of this by copying the properties of the base class.
        /// </summary>
        /// <param name="baseProperty">An instance of the base property class.</param>
        public SellableProperty(Property baseProperty)
        {
            this.Address = baseProperty.Address;
            this.Agent = baseProperty.Agent;
            this.Description = baseProperty.Description;
            this.Enquiries = baseProperty.Enquiries;
            this.Id = baseProperty.Id;
            this.Photos = baseProperty.Photos;
            this.Price = baseProperty.Price;
            SetPropertyType();
        }

        /// <summary>
        /// Sets the property type for this instance.
        /// </summary>
        private void SetPropertyType()
        {
            this.Type = PropertyType.Sale;
        }
    }
}
