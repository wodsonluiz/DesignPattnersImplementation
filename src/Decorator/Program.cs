using System;
using System.ComponentModel;

namespace Decorator;

class Program
{
    static void Main(string[] args)
    {
        // instantiate mail service
        var cloudMailService = new CloudMailService();
        cloudMailService.SendMail("Hi there.");

        var onPremiseMailService = new OnPremiseMailService();
        onPremiseMailService.SendMail("Hi there");

        // add behavior
        var statisticsDecorator = new StatisticsDecorator(cloudMailService);
        statisticsDecorator.SendMail($"He there via {nameof(StatisticsDecorator)} wrapper");

        var messageDatabaseDecorator = new MessageDatabaseDecorator(onPremiseMailService);
        messageDatabaseDecorator.SendMail( $"Hi there via {nameof(MessageDatabaseDecorator)} wrapper, message1.");
        messageDatabaseDecorator.SendMail( $"Hi there via {nameof(MessageDatabaseDecorator)} wrapper, message2.");

        foreach (var message in messageDatabaseDecorator.SentMessages)
        {
            Console.WriteLine($"Stored message: \"{message}\"");
        }
    }
}
