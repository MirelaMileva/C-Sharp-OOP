namespace Logger.Models.Errors
{
    using System;

    using Models.Contracts;
    using Models.Enumerations;
    public class Error : IError
    {
        public Error(DateTime dateTime, string message, Level level)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }
        public DateTime DateTime { get; private set; }

        public string Message { get; private set; }

        public Level Level { get; private set; }
    }
}