using InterpreterVisitorSampleApp.Abstract;
using InterpreterVisitorSampleApp.Expressions;
using InterpreterVisitorSampleApp.ExpressionStrings;
using System;
using System.Collections.Generic;

namespace InterpreterVisitorSampleApp
{
    public static class Interpreter
    {
        public static void Interpret(Context ctx)
        {
            Stack<IAbstractExpression> expressionsStack = new Stack<IAbstractExpression>();
            ExpressionPrinter printer = new ExpressionPrinter();
            foreach (string token in ctx.Input)
            {
                if (IsOperator(token))
                {
                    IAbstractExpression rightExpression = expressionsStack.Count >= 2 ? expressionsStack.Pop() : null;
                    if (rightExpression == null) InvalidRPN();
                    IAbstractExpression leftExpression = expressionsStack.Pop();
                    IAbstractExpression operation = GetOperatorInstance(token, leftExpression, rightExpression, printer);
                    if (operation == null) InvalidRPN();

                    double result = operation.Interpret();
                    expressionsStack.Push(new NumberExpression(result));

                    var printedExpression = GetOperationExpression(token);
                    printedExpression.Accept(printer);
                }
                else
                {
                    IAbstractExpression num = new NumberExpression(token);
                    expressionsStack.Push(num);

                    var printedExpression = new NumberExpressionString { Expr = token, Oper = "" };
                    printedExpression.Accept(printer);
                }
            }
            ctx.Output = expressionsStack.Pop().Interpret();
            Console.Write(printer.Expression);
        }

        private static IntermediateString GetOperationExpression(string token)
        {
            if (token.Equals("+") || token.Equals("-"))
                return new PriorZeroExpressionString { Expr = null, Oper = token };
            return new PriorOneExpressionString { Expr = null, Oper = token };
        }

        private static bool IsOperator(string s)
        {
            return (s.Equals("+") || s.Equals("-") || s.Equals("*") || s.Equals("/"));
        }
        private static IAbstractExpression GetOperatorInstance(string s, IAbstractExpression left, IAbstractExpression right, ExpressionPrinter printer)
        {
            switch (s)
            {
                case "+":
                    return new AddExpression(left, right);
                case "-":
                    return new SubstractExpression(left, right);
                case "*":
                    return new MultiplyExpression(left, right);
                case "/":
                    return new DivideExpression(left, right);
            }
            return null;
        }

        public static void InvalidRPN()
        {
            Console.WriteLine("Invalid RPN expression");
            Console.ReadKey();
            Environment.Exit(0);
        }

    }
}
