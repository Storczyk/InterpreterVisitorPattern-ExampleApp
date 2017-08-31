using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpreterVisitorSampleApp.Abstract;

namespace InterpreterVisitorSampleApp.ExpressionStrings
{
    public class NumberExpressionString : IntermediateString
    {
        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
