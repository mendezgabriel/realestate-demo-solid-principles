using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateDemo.Domain;
using localDbEntities = RealEstateDemo.DataAccess.Domain.Entities;
using RealEstateDemo.DataAccess.Domain.Mapping;
using RealEstateDemo.Common.Interfaces;

namespace RealEstateDemo.DataAccess.Domain.Mapping.Mappers
{
    /// <summary>
    /// Populates instances of <see cref="Domain.PropertyPhoto"/> from information
    /// obtained from the local database.
    /// </summary>
    public class PropertyPhotoMapper : IMapper<localDbEntities.PropertyPhoto, PropertyPhoto>
    {
        /// <summary>
        /// Populates an instance of <see cref="Domain.Property"/> from
        /// information obtained from the local database.
        /// </summary>
        /// <param name="source">The information to use to populate the
        /// resulting object</param>
        /// <returns><paramref name="source"/> in the destination format</returns>
        public PropertyPhoto Map(localDbEntities.PropertyPhoto source)
        {
            return new PropertyPhoto
            {
                Id = source.PhotoId,
                Url = source.Url
            };
        }
    }
}
