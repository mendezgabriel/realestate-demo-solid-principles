using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateDemo.Domain;

namespace RealEstateDemo.RepositoryInterfaces.Base
{
    /// <summary>
    /// Defines the base contracts for queryable repositories handling <see cref="Domain.Entity"/> objects.
    /// </summary>
    /// <typeparam name="TEntity">A <see cref="Domain.Entity"/> object.</typeparam>
    public interface IQueryableRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Gets the  <see cref="TEntity"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The entity's unique identifier.</param>
        /// <returns>An instance of  <see cref="TEntity"/>.</returns>
        TEntity FindById(int id);
    }
}
