namespace Logger.Models.Contracts
{
    using Models.Enumerations;
    public interface IAppender
    {
        ILayout Layout { get; }
        Level Level { get; }
        long MessagesAppended { get; }
        void Append(IError error);
    }
}