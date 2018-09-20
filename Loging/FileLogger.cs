using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Loging
{
    public class FileLogger : ILogger
    {
        private string filePath;
        private object _lock = new object();
        public FileLogger (string path)
        {
            filePath = path;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            //return logLevel == logLevel.Trace
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                 lock (_lock)
                {
                    File.AppendAllText(filePath, formatter(state, exception) + Environment.NewLine);
                }
            }
        }
    }
}
/*
 Класс логгера должен реализовать интерфейс ILogger. Этот интерфейс определяет три метода:

BeginScope: этот метод возвращает объект IDisposable, который представляет некоторую область видимости для логгера. В данном случае нам этот метод не важен, поэтому возвращаем значение null

IsEnabled: возвращает значения true или false, которые указыват, доступен ли логгер для использования. Здесь можно здать различную логику. В частности, в этот метод передается объект LogLevel, и мы можем, к примеру, задействовать логгер в зависимости от значения этого объекта. Но в данном случае просто возвращаем true, то есть логгер доступен всегда.

Log: этот метод предназначен для выполнения логгирования. Он принимает пять параметров:

LogLevel: уровень детализации текущего сообщения

EventId: идентификатор события

TState: некоторый объект состояния, который хранит сообщение

Exception: информация об исключении

formatter: функция форматирвания, которая с помощью двух предыдущих параметов позволяет получить собственно сообщение для логгирования

И в данном методе как раз и производится запись в текстовый файл. Путь к этому файлу передается через конструктор
 */
