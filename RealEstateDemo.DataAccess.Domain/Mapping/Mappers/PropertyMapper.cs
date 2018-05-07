using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateDemo.DataAccess.Domain.Entities;
using RealEstateDemo.Domain;
using RealEstateDemo.DataAccess.Domain.Mapping;
using RealEstateDemo.Common.Interfaces;

namespace RealEstateDemo.DataAccess.Domain.Mapping.Mappers
{
    /// <summary>
    /// Populates instances of <see cref="Domain.WaterInformation"/> from information
    /// obtained from the local database.
    /// </summary>
    public class PropertyMapper : IMapper<PropertyInformation, Property>
    {
        /// <summary>
        /// Populates an instance of <see cref="Domain.Property"/> from
        /// information obtained from the local database.
        /// </summary>
        /// <param name="source">The information to use to populate the
        /// resulting object</param>
        /// <returns><paramref name="source"/> in the destination format</returns>
        public Property Map(PropertyInformation source)
        {
            PropertyType type = (PropertyType)Enum.Parse(typeof(PropertyType), source.Type);
            Property mappedProperty = null;
            Property baseProperty = new Property
            {
                Id = source.PropertyId,
                Price = source.Price,
                Description = source.Description,
                Agent = new Agent
                {
                    Id = source.AgentId,
                    FirstName = source.AgentFirstName,
                    LastName = source.AgentLastName,
                    Email = source.AgentEmail,
                    PhoneNumber = source.AgentPhone
                },
                Address = new PropertyAddress
                {
                    Id = source.AddressId,
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
                    },
                    StreetAddress = source.StreetAddress
                }
            };

            switch (type)
            {
                case PropertyType.Rent:
                    mappedProperty = new RentalProperty(baseProperty);
                    var rentalProperty = mappedProperty as RentalProperty;

                    rentalProperty.AvailabilityDate = (DateTime)source.AvailabilityDate;
                    rentalProperty.Bond = (decimal)source.Bond;

                    return rentalProperty;

                case PropertyType.Sale:

                    mappedProperty = new SellableProperty(baseProperty);
                    var sellableProperty = mappedProperty as SellableProperty;

                    sellableProperty.AuctionDate = source.AuctionDate;

                    return sellableProperty;

                case PropertyType.Unknown:
                default:
                    throw new ApplicationException(string.Format("The property type '{0}' is not recognized.", Enum.GetName(typeof(PropertyType), type)));
            }

            
        }
    }
}
