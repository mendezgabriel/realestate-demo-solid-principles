using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.Domain
{
    /// <summary>
    /// Represents an enquiry made by a user.
    /// </summary>
    public class Enquiry : Entity
    {
        /// <summary>
        /// The enquirer's email address.
        /// </summary>
        public string ContactEmail { get; set; }

        /// <summary>
        /// The text of the enquiry.
        /// </summary>
        public string Body { get; set; }
    }
}
