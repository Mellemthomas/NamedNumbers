using System;

namespace NamedNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Input a number between 0 and 999999.99: ");
                var input = Console.ReadLine();
                Console.WriteLine(DecimalToWord(input));
                Console.WriteLine();
            }
            
        }

        /// <summary>
        ///  A method that translates a number to the corresponding spelled version.
        /// </summary>
        /// <param name="numberWithDecimal">Accepts values from 0 -> 999999.99 </param>
        /// <returns> A string with the number spelled using words</returns>
        public static string DecimalToWord(string numberWithDecimal)
        {
            var inputArray = numberWithDecimal.Split('.');
            var failureMessage = "FAILURE, INPUT DATA IS WRONG";
            if (int.TryParse(inputArray[0], out int number) && number < 1000000 && number >= 0)
            {
                var dollars = number != 1 ? " DOLLARS" : " DOLLAR";
                var output = NumberToWords(number) + dollars;

                if (inputArray.Length > 1)
                {
                    if(int.TryParse(inputArray[1], out int decimalValue) && decimalValue < 100 && decimalValue >= 0)
                    {
                        var cents = decimalValue != 1 ? " CENTS" : " CENT"; 
                        output += " AND " + NumberToWords(decimalValue) + cents;
                    } else
                    {
                        output = failureMessage;
                    }
                } else
                {
                    output += " AND ZERO CENTS";
                }
                return output;
            }
            return failureMessage;
        }

        private static string NumberToWords(int number)
        {
            var lowDigits = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
            var highDigits = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };
            
            if (number == 0) return "ZERO";

            string output = "";

            if ((number / 1000) > 0)
            {
                output += NumberToWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                output += NumberToWords(number / 100) + " HUNDRED ";
                number %= 100;
            }

            if (number > 0)
            {
                if (output != "") output += "AND ";

                if (number < 20) output += lowDigits[number];
                else
                {
                    output += highDigits[number / 10];
                    if ((number % 10) > 0) output += " " + lowDigits[number % 10];
                }
            }

            return output;
        }
    }
}
