using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class Expression
    {
        private char op;
        private Expression leftExpr;
        private Expression rightExpr;
        public string exprAsString;

        public Expression(string expressionString)
        {
            exprAsString = expressionString;
            parseExpr(expressionString);
        }

        public void parseExpr(string expr)
        {
            double _;
            /*
            Wenn keine operatoren auf level 0 zu finden sind,
            dann entferne solange schichten an Klammern bis entweder:
            ein operator wieder da ist, oder
            eine Zahl da ist
            */
            while(OperatorFinder.IndexOfLastOperator(expr, true) == -1 && OperatorFinder.IndexOfLastOperator(expr, false) == -1 && expr[0] == '(')
            {
                expr = expr.Substring(1, expr.Length - 2);
            }
            //Wenn nur noch eine Zahl übrig ist, oder die expression leer ist, brich hier die rekursion ab
            if(double.TryParse(expr,out _) || string.IsNullOrEmpty(expr)) {
                this.exprAsString = expr;
                return;
            }

            bool searchForNumOperators = OperatorFinder.IndexOfLastOperator(expr, true) != -1;
            int indexOfLastOperator = OperatorFinder.IndexOfLastOperator(expr, searchForNumOperators);
            op = expr[indexOfLastOperator];

            this.leftExpr = new Expression(expr.Substring(0,indexOfLastOperator));
            this.rightExpr = new Expression(expr.Substring(indexOfLastOperator + 1));
        }


        public override string ToString()
        {
            return exprAsString;
        }
        public Double Evaluate()
        {
            switch (op)
            {
                case '+':
                    return leftExpr.Evaluate() + rightExpr.Evaluate();
                case '-':
                    return leftExpr.Evaluate() - rightExpr.Evaluate();
                case '*':
                    return leftExpr.Evaluate() * rightExpr.Evaluate();
                case '/':
                    if(rightExpr.Evaluate() == 0)
                    {
                        throw new DivideByZeroException("Man Darf nicht durch 0 teilen");
                    }
                    return leftExpr.Evaluate() / rightExpr.Evaluate();
                default:
                    double number;
                    double.TryParse(exprAsString, out number);
                    return number;
            }
        }
    }
}
