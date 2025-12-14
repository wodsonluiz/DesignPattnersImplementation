using System.Collections.Generic;
using System.Linq;

namespace Mediator
{
    /// <summary>
    /// Mediator
    /// </summary>
    public interface IChatRoom
    {
        void Register(TeamMember teamMember);
        void Send(string from, string message);
        void Send(string from, string to, string message);
        void SentTo<T>(string from, string message) where T : TeamMember;
    }
    
    /// <summary>
    /// Colleague
    /// </summary>
    public abstract class TeamMember
    {
        private IChatRoom? _chatRoom;
        public string Name { get; set; }

        public TeamMember(string name)
        {
            Name = name;
        }

        internal void SetChatRoom(IChatRoom chatRoom)
        {
            _chatRoom = chatRoom;
        }

        public void Send(string message)
        {
            _chatRoom?.Send(Name, message);
        }

        public void Send(string to, string message)
        {
            _chatRoom?.Send(Name, to, message);
        }

        public void SendTo<T>(string message) where T : TeamMember
        {
            _chatRoom?.SentTo<T>(Name, message);
        }

        public virtual void Receive(string from, string message)
        {
            System.Console.WriteLine($"Message {from} to {Name}: {message}");
        }
    }

    /// <summary>
    /// Concrete Colleague
    /// </summary>
    public class Lawyer: TeamMember
    {
        public Lawyer(string name): base(name)
        {
            
        }

        public override void Receive(string from, string message)
        {
            System.Console.WriteLine($"{nameof(Lawyer)} {Name} received: ");
            base.Receive(from, message);
        }
    }

    /// <summary>
    /// Concrete Colleague
    /// </summary>
    public class AccountManager: TeamMember
    {
        public AccountManager(string name): base(name)
        {
            
        }

        public override void Receive(string from, string message)
        {
            System.Console.WriteLine($"{nameof(AccountManager)} {Name} received: ");
            base.Receive(from, message);
        }        
    }

    /// <summary>
    /// Concrete Mediator
    /// </summary>
    public class TeamChatRoom : IChatRoom
    {
        private readonly Dictionary<string, TeamMember> teamMembers = new();

        public TeamChatRoom()
        {
            
        }

        public void Register(TeamMember teamMember)
        {
            teamMember.SetChatRoom(this);
            if(!teamMembers.ContainsKey(teamMember.Name))
            {
                teamMembers.Add(teamMember.Name, teamMember);
            }
        }

        public void Send(string from, string message)
        {
            foreach (var teamMember in teamMembers.Values)
            {
                teamMember.Receive(from, message);
            }
        }

        public void Send(string from, string to, string message)
        {
            var teamMember = teamMembers[to];
            teamMember?.Receive(from, message);
        }

        public void SentTo<T>(string from, string message) where T : TeamMember
        {
            foreach (var teamMember in teamMembers.Values.OfType<T>())
            {
                teamMember.Receive(from, message);
            }
        }
    }
}