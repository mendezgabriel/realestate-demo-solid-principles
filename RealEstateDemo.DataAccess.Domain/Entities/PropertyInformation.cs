using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.DataAccess.Domain.Entities
{
    public class PropertyInformation
    {
        public int PropertyId { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime? AuctionDate { get; set; }

        public decimal? Bond { get; set; }

        public DateTime? AvailabilityDate { get; set; }

        public int AgentId { get; set; }

        public string AgentFirstName { get; set; }

        public string AgentLastName { get; set; }

        public string AgentEmail { get; set; }

        public string AgentPhone { get; set; }

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

        public int AddressId { get; set; }

        public string StreetAddress { get; set; }
    }
}
