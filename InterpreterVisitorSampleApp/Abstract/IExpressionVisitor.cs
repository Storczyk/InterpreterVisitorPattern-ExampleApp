using InterpreterVisitorSampleApp.Expressions;
using InterpreterVisitorSampleApp.ExpressionStrings;

namespace InterpreterVisitorSampleApp.Abstract
{
    public interface IExpressionVisitor
    {
        //void Visit(IntermediateString intermediate);
        void Visit(NumberExpressionString intermediate);
        void Visit(PriorOneExpressionString intermediate);
        void Visit(PriorZeroExpressionString intermediate);
    }
}
