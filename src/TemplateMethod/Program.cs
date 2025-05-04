using System;

namespace TemplateMethod;

class Program
{
    static void Main(string[] args)
    {
        ExchangeMailParser exchangeMailParser = new();
        Console.WriteLine(exchangeMailParser.ParseHtmlMailBody("80b7493e-09b5-4830-9270-69599c8972d6"));
        Console.WriteLine();

        ApacheMailParser apacheMailParser = new();
        Console.WriteLine(apacheMailParser.ParseHtmlMailBody("bd6d2323-0748-4cd2-865c-42b29fa38d3c"));
        Console.WriteLine();

        EudoraMailParser eudoraMailParser = new();
        Console.WriteLine(eudoraMailParser.ParseHtmlMailBody("71c3bd08-be9d-4f70-981c-d07f07df2f56"));
        Console.WriteLine();
    }
}
