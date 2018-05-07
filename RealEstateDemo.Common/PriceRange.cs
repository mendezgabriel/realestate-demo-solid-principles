using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDemo.Common
{
    /// <summary>
    /// Defines a price range.
    /// </summary>
    public class PriceRange
    {
        decimal minimum = decimal.Zero;
        decimal maximum = decimal.Zero;
        const string outsideRangeErrorMessage = "The value of '{0}' is invalid for the price range.";

        /// <summary>
        /// Gets or sets the minimum value for the range.
        /// </summary>
        public decimal Minimum
        {
            get { return this.minimum; }
            set
            {
				ValidateMinimum(value);
                this.minimum = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum value for the range.
        /// </summary>
        public decimal Maximum
        {
            get { return this.maximum; }
            set
            {
				ValidateMaximum(value);
                this.maximum = value;
            }
        }

		/// <summary>
		/// Creates a new instance of the <see cref="PriceRange"/> class.
		/// </summary>
		/// <param name="minimum">The inclusive lower-end boundary for the price range.</param>
		/// <param name="maximum">The inclusive upper-end boundary for the price range.</param>
		public PriceRange(decimal minimum, decimal maximum)
		{
			this.minimum = minimum;
			this.maximum = maximum;

			ValidateMinimum(minimum);
			ValidateMaximum(maximum);
		}

		/// <summary>
		/// Validates that <paramref name="value"/> is a valid minimum for the price range.
		/// </summary>
		/// <param name="value">The value to validate.</param>
		private void ValidateMinimum(decimal value)
		{
			bool isValidRange = (value <= this.maximum && value >= decimal.Zero);
			ThrowErrorIfRangeIsInvalid("minimum", value, isValidRange);
		}

		/// <summary>
		/// Validates that <paramref name="value"/> is a valid maximum for the price range.
		/// </summary>
		/// <param name="value">The value to validate.</param>
		private void ValidateMaximum(decimal value)
		{
			bool isValidRange = (value >= this.minimum && value >= decimal.Zero);
			ThrowErrorIfRangeIsInvalid("maximum", value, isValidRange);
		}

        /// <summary>
        /// Throws an error if the range contains invalid data.
        /// </summary>
		/// <param name="invalidParameterName">The name of the parameter that contains invalid data.</param>
        /// <param name="invalidValue">The invalid value.</param>
        /// <param name="isValidRange">True if the range contains valid data. False otherwise.</param>
        private void ThrowErrorIfRangeIsInvalid(string invalidParameterName, decimal invalidValue, bool isValidRange)
        {
            if (!isValidRange)
                throw new ArgumentOutOfRangeException(invalidParameterName, invalidValue,
					string.Format(outsideRangeErrorMessage, invalidParameterName));
        }
    }
}
