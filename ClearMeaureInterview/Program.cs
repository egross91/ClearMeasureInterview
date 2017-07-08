using System;
using System.Collections.Generic;
using FizzBuzzLibrary;

namespace ClearMeaureInterview
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            try 
            {
                FizzBuzz fizzBuzz = new FizzBuzz();

				IEnumerable<FizzBuzzResult> results = fizzBuzz.CallFizzBuzz(Convert.ToInt32(Console.ReadLine()));

				foreach (FizzBuzzResult result in results)
				{
					if (String.IsNullOrEmpty(result.Result))
					{
						Console.WriteLine(result.Value);
					}
					else
					{
						Console.WriteLine(result.Result);
					}
				}
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }
        }
    }
}
