namespace Logger.Factories
{
    using System;

    using Models.Contracts;
    using Models.Layouts;
    
    public class LayoutFactory
    {
        public ILayout ProduceLayout(string type)
        {
            ILayout layout;

            if (type == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (type == "XmlLayout")
            {
                layout = new XmlLayout();
            }
            else
            {
                throw new ArgumentException("Invalid layout type!");
            }

            return layout;
        }
    }
}
