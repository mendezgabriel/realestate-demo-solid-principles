using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace RealEstateDemo.Common.Tests
{
	[TestClass]
	public class PriceRangeTests
	{
		[TestMethod]
		public void ValuesShouldBeRetrievedCorrectly()
		{
			// Arrange
			decimal originalMinimum = 50;
			decimal originalMaximum = 200;
			var range = new PriceRange(originalMinimum, originalMaximum);

			// Act
			var expectedMinimum = range.Minimum;
			var expectedMaximum = range.Maximum;

			// Assert
			expectedMinimum.Should().Be(originalMinimum);
			expectedMaximum.Should().Be(originalMaximum);
		}

		[TestMethod]
		public void MinimumShouldNotBeNegative()
		{
			// Arrange
			decimal originalMinimum = -15;
			decimal originalMaximum = 20;
			
			AssertInvalidRange(originalMinimum, originalMaximum);
		}

		[TestMethod]
		public void MaximumShouldNotBeNegative()
		{
			// Arrange
			decimal originalMinimum = 5;
			decimal originalMaximum = -20;

			AssertInvalidRange(originalMinimum, originalMaximum);
		}

		[TestMethod]
		public void MinimumShouldNotBeGreaterThanMaximum()
		{
			// Arrange
			decimal originalMinimum = 300;
			decimal originalMaximum = 100;

			AssertInvalidRange(originalMinimum, originalMaximum);
		}

		[TestMethod]
		public void ValuesCanBeTheSame()
		{
			// Arrange
			decimal originalMinimum = 1000;
			decimal originalMaximum = 1000;

			AssertValidRange(originalMinimum, originalMaximum);
		}

		private void AssertInvalidRange(decimal minimum, decimal maximum)
		{
			// Act
			Action action = CreatePriceRangeForAssertion(minimum, maximum);

			// Assert
			action.ShouldThrow<ArgumentOutOfRangeException>();
		}

		private void AssertValidRange(decimal minimum, decimal maximum)
		{
			// Act
			Action action = CreatePriceRangeForAssertion(minimum, maximum);

			// Assert
			action.ShouldNotThrow<ArgumentOutOfRangeException>();
			action.ShouldNotThrow<Exception>();
		}

		private Action CreatePriceRangeForAssertion(decimal minimum, decimal maximum)
		{
			Action action = () => { var range = new PriceRange(minimum, maximum); };
			return action;
		}
	}
}
