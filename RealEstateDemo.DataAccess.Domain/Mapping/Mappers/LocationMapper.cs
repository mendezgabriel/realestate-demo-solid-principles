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
    /// Populates instances of <see cref="Domain.Location"/> from information
    /// obtained from the local database.
    /// </summary>
    public class LocationMapper : IMapper<localDbEntities.LocationInformation, Location>
    {
        /// <summary>
        /// Populates an instance of <see cref="Domain.Location"/> from
        /// information obtained from the local database.
        /// </summary>
        /// <param name="source">The information to use to populate the
        /// resulting object</param>
        /// <returns><paramref name="source"/> in the destination format</returns>
        public Location Map(localDbEntities.LocationInformation source)
        {
            return new Location
            {
                Country = new Country
                {
                    Id = source.CountryId,
                    Name = source.Country
                },
                State = new State
                {
                    Id = source.StateId,
                    Name = source.State,
                    Abbreviation = source.StateAbbreviation
                },
                City = new City
                {
                    Id = source.CityId,
                    Name = source.City
                },
                Suburb = new Suburb
                {
                    Id = source.SuburbId,
                    Name = source.Suburb,
                    PostCode = source.PostCode
                }
            };
        }
    }
}
