namespace DependenciesDemo
{
    using System;
    public class ConsoleIntroducer : IIntroducer
    {
        public void Introduce(string message)
        {
            Console.WriteLine(message);
        }
    }
}
