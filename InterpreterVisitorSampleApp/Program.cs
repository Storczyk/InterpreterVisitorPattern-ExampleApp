using System;

namespace InterpreterVisitorSampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Examples: 2 7 + 3 / 14 3 - 4 * + 2 /\n10 2 * 3 4 + * 2 /\nExpression:");

            string tokenString = Console.ReadLine();
            Context ctx = new Context(tokenString);
            Interpreter.Interpret(ctx);
            Console.Write("=" + ctx.Output);

            Console.ReadKey();
        }
    }

}
