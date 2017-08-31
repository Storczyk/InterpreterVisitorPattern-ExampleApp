using InterpreterVisitorSampleApp.Abstract;

namespace InterpreterVisitorSampleApp
{
    public abstract class IntermediateString
    {
        public string Expr { get; set; }
        public string Oper { get; set; }
        public abstract void Accept(IExpressionVisitor visitor);
    }
}
