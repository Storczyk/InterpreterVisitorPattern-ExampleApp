using InterpreterVisitorSampleApp.Abstract;
using System.Collections.Generic;
using InterpreterVisitorSampleApp.Expressions;
using InterpreterVisitorSampleApp.ExpressionStrings;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace InterpreterVisitorSampleApp
{
    public class ExpressionPrinter : IExpressionVisitor
    {
        public Stack<IntermediateString> Stack { get; }
        public string Expression { get; set; }
        public ExpressionPrinter()
        {
            Stack = new Stack<IntermediateString>();
        }

        public void Visit(NumberExpressionString intermediate)
        {
            Stack.Push(new NumberExpressionString { Expr = intermediate.Expr, Oper = intermediate.Oper });
            Expression = Stack.Peek().Expr;
        }

        public void Visit(PriorZeroExpressionString intermediate)
        {
            IsPossibleToPop();
            string right = Stack.Pop().Expr;
            string left = Stack.Pop().Expr;

            Stack.Push(new PriorZeroExpressionString { Expr = left + intermediate.Oper + right, Oper = intermediate.Oper });
            Expression = Stack.Peek().Expr;
        }

        public void Visit(PriorOneExpressionString intermediate)
        {
            IsPossibleToPop();
            string left, right;

            var rightIntermediate = Stack.Pop();
            if (rightIntermediate.Oper == "+" || rightIntermediate.Oper == "-")
            {
                right = "(" + rightIntermediate.Expr + ")";
            }
            else
            {
                right = rightIntermediate.Expr;
            }

            if (Stack.Count == 0)
                Interpreter.InvalidRPN();

            var leftIntermediate = Stack.Pop();
            if (leftIntermediate.Oper == "+" || leftIntermediate.Oper == "-")
            {
                left = "(" + leftIntermediate.Expr + ")";
            }
            else
            {
                left = leftIntermediate.Expr;
            }
            var newExpr = left + intermediate.Oper + right;
            Stack.Push(new PriorOneExpressionString { Expr = left + intermediate.Oper + right, Oper = intermediate.Oper });
            Expression = Stack.Peek().Expr;
        }

        private void IsPossibleToPop()
        {
            if (Stack.Count < 2)
            {
                Interpreter.InvalidRPN();
            }
        }
    }
}
