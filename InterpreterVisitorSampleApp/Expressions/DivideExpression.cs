using InterpreterVisitorSampleApp.Abstract;

namespace InterpreterVisitorSampleApp.Expressions
{
    public class DivideExpression : IAbstractExpression
    {
        IAbstractExpression leftExpression;
        IAbstractExpression rightExpression;
        public DivideExpression(IAbstractExpression left, IAbstractExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public double Interpret()
        {
            return leftExpression.Interpret() / rightExpression.Interpret();
        }
    }
}
