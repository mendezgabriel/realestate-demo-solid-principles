using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.Domain
{
    /// <summary>
    /// Represents a real estate agent or broker.
    /// </summary>
    public class Agent : Entity
    {
        /// <summary>
        /// The agent's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The agent's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The agent's full name. This property is read-only.
        /// </summary>
        public string FullName { get { return this.FirstName + " " + this.LastName; } }

        /// <summary>
        /// The agent's email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The agent's phone number. This may include country and/or area code.
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
