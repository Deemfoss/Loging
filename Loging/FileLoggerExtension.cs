using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loging
{
    public static class FileLoggerExtension
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory,string filepath)
        {
            //Этот класс добавляет к объекту ILoggerFactory метод расширения AddFile, который будет добавлять наш провайдер логгирования.
            factory.AddProvider(new FileLoggerProvider(filepath));
            return factory;
        }

    }

}
