namespace WildFarm.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Models.Foods;

    public class FoodFactory
    {
        public Food CreateFood(string strType, int quantity)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == strType);

            if (type == null)
            {
                throw new InvalidOperationException("Invalid type");
            }

            object[] ctorParams = new object[] { quantity };

           Food food = (Food)Activator.CreateInstance(type, ctorParams);

            return food;
        }
    }
}
