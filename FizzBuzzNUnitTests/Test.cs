using System;
using System.Linq;
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

        #region Testing lifecycle methods.

        [TearDown]
        public void NullifyFizzBuzz()
        {
            this.FizzBuzz = null;
		}

        #endregion

        #region Unit tests.

        [Test]
        public void FizzBuzz_DefaultComparator_ShouldReturnFizzBuzzForFifteenthElement()
		{
			// Setup.
			this.FizzBuzz = new FizzBuzz();

			// Execute.
			var results = this.FizzBuzz.CallFizzBuzz(15);

            // Assert.
            Assert.AreEqual(15, results.Count());
            Assert.True(results.ElementAt(2).Equals(new FizzBuzzResult(3, "Fizz")));
            Assert.True(results.ElementAt(4).Equals(new FizzBuzzResult(5, "Buzz")));
            Assert.True(results.ElementAt(14).Equals(new FizzBuzzResult(15, "FizzBuzz")));
		}

        [Test]
        public void FizzBuzz_NullComparator_ShouldThrowArgumentNullException()
        {
            // Setup & Execute.
            Assert.Throws<ArgumentNullException>(() => new FizzBuzz(null));
        }

        [Test]
        public void FizzBuzz_InvalidUpperBound_ShouldThrowArgumentException()
        {
            // Setup.
            this.FizzBuzz = new FizzBuzz();

            // Execute.
            var results = this.FizzBuzz.CallFizzBuzz(0);

            // Assert. NOTE: Without trying to access @results, the exception is never thrown due to lazy execution.
            Assert.Throws<ArgumentException>(() => results.Count());
        }

        [Test]
        public void FizzBuzz_CustomComparator_ShouldShowPrimeForSeventhElement()
        {
            // Setup.
            this.FizzBuzz = new FizzBuzz(delegate(int val)
            {
                if (val == 7)
	            {
	                return new FizzBuzzResult(val, "Prime");
	            }
	            else
	            {
	                return new FizzBuzzResult(val, null);
	            }
	        });

            // Execute.
            var results = this.FizzBuzz.CallFizzBuzz(14);

            // Assert.
            Assert.True(results.ElementAt(1).Equals(new FizzBuzzResult(2, null)));
            Assert.True(results.ElementAt(6).Equals(new FizzBuzzResult(7, "Prime")));
        }

		#endregion
	}
}
