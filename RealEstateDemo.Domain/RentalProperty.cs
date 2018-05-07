using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.Domain
{
    /// <summary>
    /// Defines a property that is available for rent.
    /// </summary>
    public class RentalProperty : Property
    {
        /// <summary>
        /// A security deposit a tenant pays at the start of a tenancy. It is held by the RTBA (Residential Tenancies Bond Authority)
        /// and is paid back to the tenant at the end of the tenancy provided no money is owed to the lessor/agent for rent,
        /// damages or other costs.
        /// </summary>
        public decimal Bond { get; set; }

        /// <summary>
        /// The date on which the property becomes available for renting.
        /// </summary>
        public DateTime AvailabilityDate { get; set; }

        /// <summary>
        /// Creates a new instance of this.
        /// </summary>
        public RentalProperty()
        {
            SetPropertyType();
        }

        /// <summary>
        /// Creates a new instance of this by copying the properties of the base class.
        /// </summary>
        /// <param name="baseProperty">An instance of the base property class.</param>
        public RentalProperty(Property baseProperty)
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
            this.Type = PropertyType.Rent;
        }
    }
}
