using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var myStack = new StackOfStrings();

            myStack.AddRange(new List<string> { "Ana", "Mimi" });

            Console.WriteLine(string.Join(" ", myStack));
        }
    }
}
