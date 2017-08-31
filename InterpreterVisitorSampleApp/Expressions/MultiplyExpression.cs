using InterpreterVisitorSampleApp.Abstract;

namespace InterpreterVisitorSampleApp.Expressions
{
    public class MultiplyExpression : IAbstractExpression
    {
        IAbstractExpression leftExpression;
        IAbstractExpression rightExpression;
        public MultiplyExpression(IAbstractExpression left, IAbstractExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public double Interpret()
        {
            return leftExpression.Interpret() * rightExpression.Interpret();
        }
    }
}
