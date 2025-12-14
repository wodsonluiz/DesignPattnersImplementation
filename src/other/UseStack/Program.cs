using System;
using System.Collections.Generic;

namespace UseStack;

class Program
{
    static void Main(string[] args)
    {
        var stack = new Stack<int>();

        stack.Push(1);
        stack.Push(50);
        stack.Push(30);
        stack.Push(25);

        Console.WriteLine(stack.Pop()); 
        Console.WriteLine(stack.Pop()); 
        Console.WriteLine(stack.Pop()); 
        Console.WriteLine(stack.Pop()); 
    }
}
