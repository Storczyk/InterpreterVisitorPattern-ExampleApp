using InterpreterVisitorSampleApp.Abstract;

namespace InterpreterVisitorSampleApp.Expressions
{
    public class SubstractExpression:IAbstractExpression
    {
        IAbstractExpression leftExpression;
        IAbstractExpression rightExpression;
        public SubstractExpression(IAbstractExpression left, IAbstractExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public double Interpret()
        {
            return leftExpression.Interpret() - rightExpression.Interpret();
        }
    }
}
