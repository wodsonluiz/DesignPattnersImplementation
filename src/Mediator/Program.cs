using System;

namespace Mediator;

class Program
{
    static void Main(string[] args)
    {
        TeamChatRoom teamChatRoom = new();

        var joao = new Lawyer("Joao");
        var maria = new Lawyer("Maria");
        var mae = new Lawyer("Mae");
        var antonio = new Lawyer("Antonio");
        var thalia = new Lawyer("Thalia");

        teamChatRoom.Register(joao);
        teamChatRoom.Register(maria);
        teamChatRoom.Register(mae);
        teamChatRoom.Register(antonio);
        teamChatRoom.Register(thalia);

        joao.Send("Hi everyone, can someone have a look at file ABS123? I need a compliace check");
        maria.Send("On it");

        antonio.Send("Thalia", "Are you busy?");
        antonio.SendTo<AccountManager>("The file was approved");
    }
}
