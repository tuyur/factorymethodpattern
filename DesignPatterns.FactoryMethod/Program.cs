using System;

namespace DesignPatterns.FactoryMethod
{
    public interface ILoggerFactory{
        ILogger CreateLogger();
    }

    public class LoggerFactoryY : ILoggerFactory{
        public ILogger CreateLogger(){
            return new YLogger();
        }
    }

    public interface ILogger{
        void log();
    }

    public class TLogger : ILogger{
        public void log(){
            System.Console.WriteLine("logged by Tlogger");
        }
    }

    public class YLogger :ILogger{
        public void log(){
            System.Console.WriteLine("logged by Ylogger");
        }
    }

    public class ProductManager{
        private readonly ILoggerFactory _loggerFactory;

        public ProductManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save(){
            System.Console.WriteLine("saved");

            // ILoggerFactory loggerFactory = new LoggerFactoryY();

            var logger = _loggerFactory.CreateLogger();
            logger.log();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new LoggerFactoryY());
            productManager.Save();
        }
    }
}
