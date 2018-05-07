using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.Domain
{
    /// <summary>
    /// Represents an image/photo that can be associated to a <see cref="Property"/> for visual reference.
    /// </summary>
    public class PropertyPhoto : Entity
    {
        /// <summary>
        /// The image's url.
        /// </summary>
        public string Url { get; set; }
    }
}
