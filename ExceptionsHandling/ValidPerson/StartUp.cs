using System;

namespace ValidPerson
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                Person pesho = new Person("Pesho", "Petrov", 20);

                Person noName = new Person(string.Empty, "Todorova", 5);

                Person noLastName = new Person("Gosho", null, 30);

                Person negativeAge = new Person("Mimi", "Ivanova", -50);

                Person tooOldForThisProgram = new Person("Gosho", "Goshev", 125);

            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            catch(ArgumentOutOfRangeException aore)
            {
                Console.WriteLine(aore.Message);
            }
        }
    }
}