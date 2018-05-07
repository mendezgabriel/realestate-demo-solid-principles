using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.DataAccess.Domain.Entities
{
    public class PropertyPhoto
    {
        public int PhotoId { get; set; }

        public int PropertyId { get; set; }

        public string Url { get; set; }
    }
}
