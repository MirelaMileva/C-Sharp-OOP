using System;

namespace FixingVol2
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int num1 = 30;
            int num2 = 60;

            try
            {
                byte result = Convert.ToByte(num1 * num2);
                Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
                Console.WriteLine();
            }
            catch (OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }

        }
    }
}