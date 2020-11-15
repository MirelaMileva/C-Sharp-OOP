using System;

namespace SquareRoot
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine(Sqrt(num));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }

        }
        public static double Sqrt(int value)
        {
            if (value < 0)
            {
                throw new System.ArgumentOutOfRangeException("value",
                  "Sqrt for negative numbers is undefined!");
            }

            return Math.Sqrt(value);
        }

    }
}
