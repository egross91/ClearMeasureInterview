using System;
using System.Collections.Generic;

namespace FizzBuzzLibrary
{
    public class FizzBuzz
    {
        #region Class Variables

        /// <summary>
        /// The default comparator that similates the functionality outlined by the classic problem FizzBuzz.
        /// </summary>
        private static readonly Func<Int32, FizzBuzzResult> DefaultComparator = delegate (int arg)
        {
            bool divisibleBy3 = arg % 3 == 0;
            bool divisibleBy5 = arg % 5 == 0;

            if (divisibleBy3 && divisibleBy5)
            {
                return new FizzBuzzResult(arg, "FizzBuzz");
            }
            else if (divisibleBy3)
            {
                return new FizzBuzzResult(arg, "Fizz");
            }
            else if (divisibleBy5)
            {
                return new FizzBuzzResult(arg, "Buzz");
            }
            else
            {
                return new FizzBuzzResult(arg, null);
            }
        };

        /// <summary>
        /// The (potentially custom) comparator to be used for returning the values of FizzBuzz.
        /// </summary>
        /// <value>The comparator.</value>
        public Func<Int32, FizzBuzzResult> Comparator { private get; set; }

        #endregion

        #region Constructors

        public FizzBuzz()
        {
            this.Comparator = FizzBuzz.DefaultComparator;
        }

        public FizzBuzz(Func<Int32, FizzBuzzResult> comparator)
        {
            if (comparator == null)
            {
                throw new ArgumentNullException(nameof(comparator), "FizzBuzz comparator cannot be null.");
            }

            this.Comparator = comparator;
        }

        #endregion

        #region API

        /// <summary>
        /// Executes the implementation of FizzBuzz from 1 to an upper bound.
        /// </summary>
        /// <returns>The results of executing FizzBuzz's implementation against values [1..n].</returns>
        /// <param name="upperBound">The upper bound of values to execute against.</param>
        public IEnumerable<FizzBuzzResult> CallFizzBuzz(int upperBound)
        {
            if (upperBound < 1)
            {
                throw new ArgumentException("FizzBuzz upper bound cannot be less than 1.", nameof(upperBound));
            }

            for (int i = 1; i <= upperBound; ++i)
            {
                yield return this.Comparator(i);
            }
        }

        #endregion
    }

    public class FizzBuzzResult 
    {
        public readonly int Value;
        public readonly String Result;

        public FizzBuzzResult(int v, String r)
        {
            this.Value = v;
            this.Result = r;
        }

        /// <summary>
        /// Determines whether the specified <see cref="FizzBuzzLibrary.FizzBuzzResult"/> is equal to the current <see cref="T:FizzBuzzLibrary.FizzBuzzResult"/>.
        /// </summary>
        /// <param name="other">The <see cref="FizzBuzzLibrary.FizzBuzzResult"/> to compare with the current <see cref="T:FizzBuzzLibrary.FizzBuzzResult"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="FizzBuzzLibrary.FizzBuzzResult"/> is equal to the current
        /// <see cref="T:FizzBuzzLibrary.FizzBuzzResult"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(FizzBuzzResult other)
        {
            if (other == null)
            {
                return false;
            }

            return (this.Value == other.Value && this.Result == other.Result);
        }
    }
}
