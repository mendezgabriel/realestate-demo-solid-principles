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
    /// Provides mapping between <see cref="LocationInformation"/> and its underlying database object.
    /// </summary>
    public class LocationInformationMapping : Map<LocationInformation>
    {
        /// <summary>
        /// Performs the mapping.
        /// </summary>
        public LocationInformationMapping()
        {
            PrimaryKey("SuburbId");
            TableName("ViewLocationsInformation");
            //Columns(x =>
            //{
            //    x.Column(y => y.CountryId);
            //    x.Column(y => y.Country);
            //    x.Column(y => y.StateId);
            //    x.Column(y => y.State);
            //    x.Column(y => y.StateAbbreviation);
            //    x.Column(y => y.CityId);
            //    x.Column(y => y.City);
            //    x.Column(y => y.SuburbId);
            //    x.Column(y => y.PostCode);
            //    x.Column(y => y.Suburb);
            //});
        }
    }
}
