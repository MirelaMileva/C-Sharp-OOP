namespace DependenciesDemo
{
    using System;
    public class Dragon
    {
        private IIntroducer introducer;
        public Dragon(string name, IIntroducer introducer)
        {
            this.Name = name;
            this.introducer = introducer;
        }
        public string Name { get; set; }

        public void Introduce()
        {
            introducer.Introduce($"My name is {this.Name}! I am an ancient...");
        }
    }
}
