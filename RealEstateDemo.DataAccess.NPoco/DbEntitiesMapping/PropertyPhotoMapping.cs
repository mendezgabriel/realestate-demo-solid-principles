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
    /// Provides mapping between <see cref="PropertyPhoto"/> and its underlying database object.
    /// </summary>
    public class PropertyPhotoMapping : Map<PropertyPhoto>
    {
        /// <summary>
        /// Performs the mapping.
        /// </summary>
        public PropertyPhotoMapping()
        {
            PrimaryKey("PhotoId");
            TableName("PropertyPhotos");
        }
    }
}
