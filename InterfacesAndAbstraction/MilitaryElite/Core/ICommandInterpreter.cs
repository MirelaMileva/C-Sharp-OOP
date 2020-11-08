namespace MilitaryElite.Core
{
    public interface ICommandInterpreter
    {
        public string Read(string[] args);
    }
}