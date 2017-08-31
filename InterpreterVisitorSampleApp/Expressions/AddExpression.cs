using InterpreterVisitorSampleApp.Abstract;

namespace InterpreterVisitorSampleApp.Expressions
{
    public class AddExpression: OperationExpression, IAbstractExpression
    {
        IAbstractExpression leftExpression;
        IAbstractExpression rightExpression;
        public AddExpression(IAbstractExpression left, IAbstractExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public double Interpret()
        {
            return leftExpression.Interpret() + rightExpression.Interpret();
        }
    }
}
