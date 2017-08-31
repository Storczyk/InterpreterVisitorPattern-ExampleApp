using InterpreterVisitorSampleApp.Abstract;

namespace InterpreterVisitorSampleApp.Expressions
{
    public class NumberExpression : IAbstractExpression
    {
        double number;
        public NumberExpression(double i)
        {
            number = i;
        }
        public NumberExpression(string s)
        {
            number = double.Parse(s);
        }

        public double Interpret()
        {
            return number;
        }
    }
}
