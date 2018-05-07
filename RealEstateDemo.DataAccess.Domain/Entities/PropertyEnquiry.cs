using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.DataAccess.Domain.Entities
{
    public class PropertyEnquiry
    {
        public int EnquiryId { get; set; }

        public int PropertyId { get; set; }

        public string ContactEmail { get; set; }

        public string Body { get; set; }
    }
}
