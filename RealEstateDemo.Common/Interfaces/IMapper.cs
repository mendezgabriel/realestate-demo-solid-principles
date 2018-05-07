using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.Common.Interfaces
{
    /// <summary>
    /// Converts from <typeparamref name="TSource"/> to <typeparamref name="TDestination"/>
    /// </summary>
    /// <typeparam name="TSource">What to convert from</typeparam>
    /// <typeparam name="TDestination">What to convert to</typeparam>
    public interface IMapper<TSource, TDestination>
    {
        /// <summary>
        /// Converts <paramref name="source"/>
        /// </summary>
        /// <param name="source">What to convert</param>
        /// <returns>The result</returns>
        TDestination Map(TSource source);
    }
}
