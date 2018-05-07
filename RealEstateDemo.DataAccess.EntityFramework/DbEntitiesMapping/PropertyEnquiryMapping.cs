using RealEstateDemo.DataAccess.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.DataAccess.EntityFramework.DbEntitiesMapping
{
    /// <summary>
    /// Provides mapping between <see cref="PropertyEnquiry"/> and its underlying database object.
    /// </summary>
    public class PropertyEnquiryMapping : EntityTypeConfiguration<PropertyEnquiry>
    {
        /// <summary>
        /// Performs the mapping.
        /// </summary>
        public PropertyEnquiryMapping()
        {
            ToTable("PropertyEnquiries");
            HasKey(t => new
            {
                t.EnquiryId
            });
        }
    }
}
