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
    /// Provides mapping between <see cref="PropertyPhoto"/> and its underlying database object.
    /// </summary>
    public class PropertyPhotoMapping : EntityTypeConfiguration<PropertyPhoto>
    {
        /// <summary>
        /// Performs the mapping.
        /// </summary>
        public PropertyPhotoMapping()
        {
            ToTable("PropertyPhotos");
            HasKey(t => new
            {
                t.PhotoId
            });
        }
    }
}
