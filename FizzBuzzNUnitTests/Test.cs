using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using FizzBuzzLibrary;

namespace FizzBuzzUnitTests
{
	[TestFixture]
	public class SmokeTests
	{
		#region Unit under test.

		private FizzBuzz FizzBuzz;

		#endregion

		#region Unit tests.

		[Test]
		public void FizzBuzz_DefaultComparator_ShouldReturnFizzBuzzFor15_True()
		{
			// Setup.
			this.FizzBuzz = new FizzBuzz();

			// Execute.
			IEnumerable<FizzBuzzResult> results = this.FizzBuzz.CallFizzBuzz(15);

            // Assert.
            Assert.AreEqual(results.Count(), 15);
            Assert.True(results.ElementAt(2).Equals(new FizzBuzzResult(3, "Fizz")));
            Assert.True(results.ElementAt(4).Equals(new FizzBuzzResult(5, "Buzz")));
            Assert.True(results.ElementAt(14).Equals(new FizzBuzzResult(15, "FizzBuzz")));
		}

		#endregion
	}
}
