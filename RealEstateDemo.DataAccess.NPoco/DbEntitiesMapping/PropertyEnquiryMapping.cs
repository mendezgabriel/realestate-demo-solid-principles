using NPoco;
using NPoco.FluentMappings;
using RealEstateDemo.DataAccess.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.DataAccess.NPoco.DbEntitiesMapping
{
    /// <summary>
    /// Provides mapping between <see cref="PropertyEnquiry"/> and its underlying database object.
    /// </summary>
    public class PropertyEnquiryMapping : Map<PropertyEnquiry>
    {
        /// <summary>
        /// Performs the mapping.
        /// </summary>
        public PropertyEnquiryMapping()
        {
            PrimaryKey("EnquiryId");
            TableName("PropertyEnquiries");
        }
    }
}
