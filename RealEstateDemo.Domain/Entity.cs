using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.Domain
{
    /// <summary>
    /// Base class for all entities
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Uniquely identifies this.
        /// </summary>
        public int Id { get; set; }
    }
}
