namespace InterpreterVisitorSampleApp.Abstract
{
    public interface IExpression
    {
        void Accept(IExpressionVisitor visitor);
    }
}
