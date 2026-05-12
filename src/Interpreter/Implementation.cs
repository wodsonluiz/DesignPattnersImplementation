namespace Interpreter
{
    /// <summary>
    /// Context
    /// </summary>
    public class RomanContext
    {
        public int Input { get; set; }
        public string Output { get; set; } = string.Empty;

        public RomanContext(int input)
        {
            Input = input;
        }
    }

    /// <summary>
    /// Abstraction expression
    /// </summary>
    public abstract class RomanExpression
    {
        public abstract void Interpret(RomanContext context);
    }

    //9 = IX
    //8 = VIII
    //7 = VII
    //6 = VI
    //5 = V
    //4 = IV
    //3 = III
    //2 = II
    //1 = I

    //simplified - each combination is reachable with subscription and these 4:
    //9 = IX
    //5 = V
    //4 = IV
    //1 = I


    /// <summary>
    /// Terminal Expression
    /// </summary>
    public class RomanOneExpression : RomanExpression
    {
        public override void Interpret(RomanContext context)
        {
            while((context.Input - 9) >= 0)
            {
                context.Output += "IX";
                context.Input -= 9;
            }

            while((context.Input - 5) >= 0)
            {
                context.Output += "V";
                context.Input -= 5;
            }

            while((context.Input - 4) >= 0)
            {
                context.Output += "IV";
                context.Input -= 4;
            }

            while((context.Input - 1) >= 0)
            {
                context.Output += "I";
                context.Input -= 1;
            }
        }
    }

    //90 = XC
    //80 = LIII
    //70 = LII
    //60 = LX
    //50 = L
    //40 = XL
    //30 = XXX
    //20 = XX
    //10 = X

    //simplified - each combination is reachable with subscription and these 4:
    //90 = XC
    //50 = L
    //40 = XL
    //10 = X

    public class RomanTenExpression : RomanExpression
    {
        public override void Interpret(RomanContext context)
        {
            while ((context.Input - 90) >= 0)
            {
                context.Output += "XC";
                context.Input -= 90;
            }

            while ((context.Input - 50) >= 0)
            {
                context.Output += "L";
                context.Input -= 50;
            }

            while ((context.Input - 40) >= 0)
            {
                context.Output += "XL";
                context.Input -= 40;
            }

            while ((context.Input - 10) >= 0)
            {
                context.Output += "X";
                context.Input -= 10;
            }
        }
    }

    //900 = CM
    //800 = DCCC
    //700 = DCC
    //600 = DC
    //500 = D
    //400 = CD
    //300 = CCC
    //200 = CC
    //100 = C

    //simplified - each combination is reachable with subscription and these 4:
    //900 = CM
    //500 = D
    //400 = CD
    //100 = C

    public class RomanHundreExpression : RomanExpression
    {
        public override void Interpret(RomanContext context)
        {
            while ((context.Input - 900) >= 0)
            {
                context.Output += "CM";
                context.Input -= 900;
            }

            while ((context.Input - 500) >= 0)
            {
                context.Output += "D";
                context.Input -= 500;
            }

            while ((context.Input - 400) >= 0)
            {
                context.Output += "CD";
                context.Input -= 400;
            }

            while ((context.Input - 100) >= 0)
            {
                context.Output += "C";
                context.Input -= 100;
            }
        }
    }
}