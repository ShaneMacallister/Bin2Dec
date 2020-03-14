using System;

namespace Bin2Dec
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter mode - [1] Binary => Decimal (Bin2Dec) or [2] Decimal => Binary (Dec2Bin)");
            string mode = Console.ReadLine();

            if (mode == "Bin2Dec" || mode == "1")
            {
                Console.WriteLine("Enter a number in binary (base 2) format OR enter 'xx' to exit:");
                string number;

                while ((number = Console.ReadLine()) != "xx")
                {
                    if (!string.IsNullOrEmpty(number) && IsBinary(number) && number.Length <= 64)
                    {
                        ulong convertedNumber = Convert.ToUInt64(number, 2);
                        Console.WriteLine(convertedNumber);
                        Console.WriteLine("Enter another binary number or enter 'xx' to exit.");
                    }
                    else
                    if (!IsBinary(number))
                    {
                        Console.WriteLine("Invalid number - did you use base 2 (1s and 0s only)?");
                        Console.WriteLine("Try again or enter 'xx' to exit.");
                    }
                    else
                    if (number.Length > 64)
                    {
                        Console.WriteLine("Number too large for conversion to a 64-bit integer.");
                        Console.WriteLine("Try again or enter 'xx' to exit.");
                    }
                    else
                    {
                        Console.WriteLine("No number entered. Enter another number or 'xx' to exit.");
                    }
                }
            }
            else 
            if (mode == "Dec2Bin" || mode == "2")
            {
                Console.WriteLine("Enter a number (using numeric characters 0-9 only) OR enter 'xx' to exit:");
                string number;

                while ((number = Console.ReadLine()) != "xx")
                {
                    if (!string.IsNullOrEmpty(number))
                    {
                        if (Int32.TryParse(number, out int result))
                        {
                            Console.WriteLine(Convert.ToString(result, 2).PadLeft(32, '0'));
                            Console.WriteLine("Enter another number or 'xx' to exit.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid number; possibly out of range. Try again or enter 'xx' to exit.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You didn't enter a number!");
                        Console.WriteLine("Enter a numeric value or 'xx' to exit.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid mode. Must be either Bin2Dec (1) or Dec2Bin (2).");
            }
        }

        private static bool IsBinary(string s)
        {
            foreach (var c in s)
                if (c != '0' && c != '1')
                    return false;
            return true;
        }
    }
}
