using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loging
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private string path;

        public FileLoggerProvider(string _path)
        {
            path = _path;
        }
        //CreateLogger: создает и возвращает объект логгера. Для создания логгера используется путь к файлу, который передается через конструктор
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(path);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
