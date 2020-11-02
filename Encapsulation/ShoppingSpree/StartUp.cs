using ShoppingSpree.Core;
using System;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                Engine engine = new Engine();
                engine.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
