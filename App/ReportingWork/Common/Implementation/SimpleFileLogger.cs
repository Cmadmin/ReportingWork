using System;
using System.IO;
using Common.Infrastructure;


namespace Common.Implementation
{
    public class SimpleFileLogger : ILogger
    {
        private readonly string _fileName;

        public SimpleFileLogger(string fileName)
        {
            _fileName = fileName;
        }

        public void LogItem(string message)
        {
            using (TextWriter writer = File.CreateText(_fileName))
            {
                writer.WriteLine("--------------------------------------------------------------------");
                writer.WriteLine("Date and Time: " + DateTime.Now.ToString("yyyy mmmm dd hh:mm"));
                writer.WriteLine(message);
            }

        }
    }
}
