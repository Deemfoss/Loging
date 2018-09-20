using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Loging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
        //Для установки базовой конфигурации логгирования в классе Program при создании объекта IWebHostBuilder мы можем вызвать метод ConfigureLogging(). Например, по умолчанию минимальный уровень сообщений представлен константой LogLevel.Information. А это значит, что сообщения, которые относятся к уровням Trace и Debug, будут игнорироваться. Установим в качестве минимального уровня Trace, изменив файл Program.cs следующим образом:
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            .ConfigureLogging(logining=>logining.SetMinimumLevel(LogLevel.Trace))
                .Build();
    }
}
