using System;

namespace Singleton
{
    public class Logger
    {
        //private static Logger? _instance;
        private static Lazy<Logger> _lazyLogger = new Lazy<Logger>(() => new Logger());
        protected Logger()
        {

        }

        public static Logger Instance { get => _lazyLogger.Value ; }

        //public static Logger Instance2 
        //{ 
            //get => 
            //{
                //_lazyLogger.Value;
                //if(_instance == null)
                    //_instance = new Logger();

                //return _instance;
            //};
        //}

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}