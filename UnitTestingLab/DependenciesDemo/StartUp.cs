namespace DependenciesDemo
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dragon = new Dragon("Drago", new ConsoleIntroducer());

            dragon.Introduce();
        }
    }
}
