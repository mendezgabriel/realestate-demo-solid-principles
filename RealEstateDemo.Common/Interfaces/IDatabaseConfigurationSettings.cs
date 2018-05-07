
namespace RealEstateDemo.Common.Interfaces
{
    /// <summary>
    /// Information about how to establish communication with the local application database
    /// </summary>
    public interface IDatabaseConfigurationSettings
    {
        /// <summary>
        /// Determines how to get the Entity Framework connection string
        /// </summary>
        string ConnectionStringName { get; set; }

        /// <summary>
        /// Determines the connection timeout in seconds.
        /// </summary>
        /// <returns>The number of seconds after which the connection to the database will be
        /// terminated if has not responded back to the caller.</returns>
        //int ConnectionTimeOut { get; set; }
    }
}
