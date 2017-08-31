using InterpreterVisitorSampleApp.Abstract;

namespace InterpreterVisitorSampleApp
{
    public class Context:IAbstractExpression
    {
        public Context(string input)
        {
            Input = input.Split(' ');
        }
        public string[] Input { get; }
        public double Output { get; set; }

        public double Interpret()
        {
            return Output;
        }
    }
}
