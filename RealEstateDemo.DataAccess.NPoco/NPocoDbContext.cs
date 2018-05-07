using NPoco;
using RealEstateDemo.Common.Interfaces;
using RealEstateDemo.RepositoryInterfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.DataAccess.NPoco
{
    /// <summary>
    /// DbContext's implementation using NPoco https://github.com/schotime/NPoco/wiki
    /// </summary>
    public class NPocoDbContext : IDbContext<IDatabase>
    {
        /// <summary>
        /// Default constructor for the context.
        /// </summary>
        /// <param name="databaseConfigurationSettings">How to obtain the configuration setting applicable to the database.</param>
        public NPocoDbContext(IDatabaseConfigurationSettings databaseConfigurationSettings)
        {
            NPocoDbFactory.Setup(databaseConfigurationSettings);
        }

        /// <summary>
        /// Gets an instance of the context.
        /// </summary>
        /// <returns>The context instantiated.</returns>
        public IDatabase GetInstance()
        {
            return NPocoDbFactory.Factory.GetDatabase();
        }
    }
}
