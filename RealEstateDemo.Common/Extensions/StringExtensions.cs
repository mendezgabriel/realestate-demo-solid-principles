using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.Common.Extensions
{
    /// <summary>
    /// Provides extension methods for strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Gets a decimal value out of a string if the parsing succeeds. Otherwise returns the default value specified.
        /// </summary>
        /// <param name="stringValue">The string used for the extension method.</param>
        /// <param name="defaultValue">The value to be used as default if the parsing fails.</param>
        /// <returns>A decimal value out of a string if the parsing succeeds. Otherwise the default value specified.</returns>
        public static decimal GetDecimalValueOrDefault(this string stringValue, decimal defaultValue = 0)
        {
            stringValue = stringValue != null ? stringValue : string.Empty;
            decimal value = defaultValue;
            var canBeParsed = decimal.TryParse(stringValue, out value);
            return canBeParsed ? value : defaultValue;
        }
    }
}
