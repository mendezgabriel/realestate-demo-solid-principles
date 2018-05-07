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
    /// Provides mapping between <see cref="PropertyInformation"/> and its underlying database object.
    /// </summary>
    public class PropertyInformationMapping : Map<PropertyInformation>
    {
        /// <summary>
        /// Performs the mapping.
        /// </summary>
        public PropertyInformationMapping()
        {
            PrimaryKey("PropertyId");
            TableName("ViewPropertiesInformation");
        }
    }
}
