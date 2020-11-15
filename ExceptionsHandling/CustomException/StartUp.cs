using System;

namespace CustomException
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                Student gincho = new Student("Gin4o", "gincho.gmail.com");
                Console.WriteLine(gincho);
            }
            catch (InvalidPersonNameException ipne)
            {
                Console.WriteLine(ipne.Message);
            }
        }
    }
}
