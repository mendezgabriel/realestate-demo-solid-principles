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
    /// Provides mapping between <see cref="PropertyInformation"/> and its underlying database object.
    /// </summary>
    public class PropertyInformationMapping : EntityTypeConfiguration<PropertyInformation>
    {
        /// <summary>
        /// Performs the mapping.
        /// </summary>
        public PropertyInformationMapping()
        {
            ToTable("ViewPropertiesInformation");
            HasKey(t => new
            {
                t.PropertyId
            });
        }
    }
}
