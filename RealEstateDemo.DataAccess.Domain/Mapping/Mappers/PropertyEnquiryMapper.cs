using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateDemo.Domain;
using localDbEntities = RealEstateDemo.DataAccess.Domain.Entities;
using RealEstateDemo.Common.Interfaces;

namespace RealEstateDemo.DataAccess.Domain.Mapping.Mappers
{
    /// <summary>
    /// Populates instances of <see cref="localDbEntities.PropertyEnquiry"/> from information
    /// obtained from the domain model.
    /// </summary>
    public class PropertyEnquiryMapper : IMapper<KeyValuePair<Property, Enquiry>, localDbEntities.PropertyEnquiry>
    {
        /// <summary>
        /// Populates an instance of <see cref="localDbEntities.PropertyEnquiry"/> from
        /// information obtained from the local database.
        /// </summary>
        /// <param name="source">The information to use to populate the
        /// resulting object</param>
        /// <returns><paramref name="source"/> in the destination format</returns>
        public localDbEntities.PropertyEnquiry Map(KeyValuePair<Property, Enquiry> source)
        {
            return new localDbEntities.PropertyEnquiry
            {
                PropertyId = source.Key.Id,
                ContactEmail = source.Value.ContactEmail,
                Body = source.Value.Body
            };
        }
    }
}
