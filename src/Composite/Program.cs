using System;

namespace Composite;

class Program
{
    static void Main(string[] args)
    {
        var root = new Directory("root", 0);
        var topLevelFile = new File("toplevel.txt", 100);
        var toplevelDirectory1 = new Directory("toplevelDirectory1", 4);
        var toplevelDirectory2 = new Directory("toplevelDirectory2", 4);

        root.Add(topLevelFile);
        root.Add(toplevelDirectory1);
        root.Add(toplevelDirectory2);

        var subLevelFile1 = new File("sublevel1.txt", 200);
        var subLevelFile2 = new File("sublevel2.txt", 150);
        toplevelDirectory1.Add(subLevelFile1);
        toplevelDirectory2.Add(subLevelFile2);

        Console.WriteLine($"Size of topLevelDirectory1: {toplevelDirectory1.GetSize()}");
        Console.WriteLine($"Size of topLevelDirectory2: {toplevelDirectory2.GetSize()}");
        Console.WriteLine($"Size of root: {root.GetSize()}" );
    }
}
