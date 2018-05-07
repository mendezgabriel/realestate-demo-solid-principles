using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.DataAccess.Domain.Entities
{
    public class LocationInformation
    {
        public int CountryId { get; set; }

        public string Country { get; set; }

        public int StateId { get; set; }

        public string State { get; set; }

        public string StateAbbreviation { get; set; }

        public int CityId { get; set; }

        public string City { get; set; }

        public int SuburbId { get; set; }

        public string PostCode { get; set; }

        public string Suburb { get; set; }
    }
}
