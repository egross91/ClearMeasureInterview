using System;
using System.Collections.Generic;

namespace FizzBuzzLibrary
{
    public class FizzBuzz
    {
        #region Class Variables

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
        public int Value { get; }
        public String Result { get; }

        public FizzBuzzResult(int v, String r)
        {
            this.Value = v;
            this.Result = r;
        }
    }
}
