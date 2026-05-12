using System;
using System.Collections.Generic;

namespace Interpreter;

static class Program
{
    static void Main(string[] args)
    {
        var expressions = new List<RomanExpression>
        {
            new RomanHundreExpression(),
            new RomanTenExpression(),
            new RomanOneExpression()
        };

        var context = new RomanContext(5);
        foreach (var expression in expressions)
        {
            expression.Interpret(context);
        }

        Console.WriteLine($"Translating Arabic numerals to Roman numerals: 5 {context.Output}");

        context = new RomanContext(81);
        foreach (var expression in expressions)
        {
            expression.Interpret(context);
        }

        Console.WriteLine($"Translating Arabic numerals to Roman numerals: 81 {context.Output}");

        context = new RomanContext(733);
        foreach (var expression in expressions)
        {
            expression.Interpret(context);
        }

        Console.WriteLine($"Translating Arabic numerals to Roman numerals: 733 {context.Output}");
    }
}
