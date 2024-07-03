using System;

namespace Singleton;

class Program
{
    static void Main(string[] args)
    {
        var log = Logger.Instance;
        var log2 = Logger.Instance;

        if(log == log2)
            log2.Log("É a mesma instancia");

        log.Log("Teste");
    }
}
