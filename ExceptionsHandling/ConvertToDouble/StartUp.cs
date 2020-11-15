using System;

namespace ConvertToDouble
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            try
            {
                double number = Convert.ToDouble(input);
                Console.WriteLine(number);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch(OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }
        }
    }
}
