namespace Logger.Models.Files
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using global::Logger.Common;
    using Models.Contracts;
    using Models.Enumerations;
    using Models.IOMannagement;

    public class LogFile : IFile
    {
        private IOManager IOManager;

        public LogFile(string folderName, string fileName)
        {
            this.IOManager = new IOManager(folderName, fileName);
           this.IOManager.EnsureDirectoryAndFileExist();
        }
        public string Path => this.IOManager.CurrentFilePath;

        public long Size => this.GetFileSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = String.Format(format, dateTime.ToString(GlobalConstants.DATE_FORMAT, CultureInfo.InvariantCulture), message, level.ToString()) + Environment.NewLine;

            return formattedMessage;
        }

        private long GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            long size = text
                .Where(ch => char.IsLetter(ch))
                .Sum(ch => ch);

            return size;
        }
    }
}
