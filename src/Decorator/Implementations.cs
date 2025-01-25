using System;
using System.Collections.Generic;

namespace Decorator
{
    /// <summary>
    /// Component (as Interface)
    /// </summary>
    public interface IMailService
    {
        bool SendMail(string message);
    }


    /// <summary>
    /// ConcreteComponent1
    /// </summary>
    public class CloudMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message \"{message}\" " + $"sent via {nameof(CloudMailService)}");

            return true;
        }
    }

    /// <summary>
    /// ConcreteComponent2
    /// </summary>
    public class OnPremiseMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message \"{message}\" " + $"sent via {nameof(OnPremiseMailService)}");

            return true;
        }
    }

    /// <summary>
    /// Decorator
    /// </summary>
    public abstract class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;

        public MailServiceDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }

        public virtual bool SendMail(string message)
        {
            return _mailService.SendMail(message);
        }
    }

    /// <summary>
    /// Decorator Concrete1
    /// </summary>
    public class StatisticsDecorator: MailServiceDecoratorBase
    {
        public StatisticsDecorator(IMailService mailService): base(mailService)
        {
            
        }

        public override bool SendMail(string message)
        {
            System.Console.WriteLine($"Collecting statistics in {nameof(StatisticsDecorator)}");
            return base.SendMail(message);
        }
    }

    /// <summary>
    /// Decorator Concrete2
    /// </summary>
    public class MessageDatabaseDecorator: MailServiceDecoratorBase
    {
        public List<string> SentMessages { get; private set; } = new List<string>();

        public MessageDatabaseDecorator(IMailService mailService): base(mailService)
        {
            
        }

        public override bool SendMail(string message)
        {
            if(base.SendMail(message))
            {
                SentMessages.Add(message);
                return true;
            }

            return base.SendMail(message);
        }
    }
}