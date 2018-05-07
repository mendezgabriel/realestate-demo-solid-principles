using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.RepositoryInterfaces.Base
{
    /// <summary>
    /// Defines a generic db context.
    /// </summary>
    /// <typeparam name="T">The type of the context used.</typeparam>
    public interface IDbContext<T> where T : class
    {
        /// <summary>
        /// Gets an instance of the context.
        /// </summary>
        /// <returns>The context instantiated.</returns>
        T GetInstance();
    }
}
