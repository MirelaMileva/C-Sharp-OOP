namespace DependenciesDemo.Tests.Fakes
{
    public class FakeIntroducer : IIntroducer
    {
        public string Message { get; private set; }
        public void Introduce(string message)
        {
            this.Message = message;
        }
    }
}
