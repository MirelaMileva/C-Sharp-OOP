namespace Logger.Models.Layouts
{
    using Models.Contracts;
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}