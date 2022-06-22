using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class SyntaxChecker
    {
        public class BadMathematicalExpression : Exception {
            public BadMathematicalExpression(string msg) :base(msg) {
            }
        }

        public class BadParensException : Exception
        {
            public BadParensException(string msg): base(msg)
            {

            }

        }

        private static char[] _exprWhitelist = {'0','1','2','3','4','5','6','7','8','9', '+', '-', '*', '/', ' ', ',', '(', ')'};
        private static char[] _operators = { '+', '-', '*', '/' };
        private static char[] _mulOperators = { '*', '/' };

        private static void OperatorDannMulOperator(string expr)
        {
            for (int i = 1; i < expr.Length; i++)
            {
                if (_operators.Contains(expr[i - 1]) && _mulOperators.Contains(expr[i]))
                {
                    throw new BadMathematicalExpression("Nach einem Operator darf nicht noch ein Multiplikationsoperator folgen");
                }
            }
        }
        private static void EmptyParen(string expr)
        {
            for (int i = 1; i < expr.Length; i++)
            {
                if(expr[i-1] == '(' && expr[i] == ')')
                {
                    throw new BadParensException("Leere Klammer entdeckt");
                }
            }
        }
        private static void DreiOperatorenNebenEinander(string expr)
        {
            for (int i = 2; i < expr.Length; i++)
            {
                if (_operators.Contains(expr[i - 2]) && _operators.Contains(expr[i - 1]) && _operators.Contains(expr[i]))
                {
                    throw new BadMathematicalExpression("Es dürfen nicht 3 Operatoren aufeinander Folgen");
                }
            }
        }
        private static void ScanForBadParens(string expr)
        {
            int level = 0;
            foreach(char c in expr)
            {
                if(c == '(')
                {
                    level++;
                }
                else if( c == ')')
                {
                    if (--level < 0)
                    {
                        throw new BadParensException("Nicht vorhandene Klammer wurde geschlossen");
                    }
                }
            }
            if (level > 0)
            {
                throw new BadParensException("Es wurden nicht alle Klammern geschlossen");
            }
        }

        private static void FirstCharIsMulOperator(string expr)
        {
            if (_mulOperators.Contains(expr[0]))
            {
                throw new BadMathematicalExpression("Am anfang eines Ausdrucks kann keine Multiplikationszeichen stehen");
            }
        }
        private static void ExpressionEmpty(string expr)
        {
            if(string.IsNullOrEmpty(expr))
            {
                throw new ArgumentNullException("Leere Eingabe erkannt");
            }
        }

        private static void InvalidChars(string expr)
        {
            for (int i = 0; i < expr.Length;i++)
            {
                if (!_exprWhitelist.Contains(expr[i]))
                {
                    throw new BadMathematicalExpression("Invalide Zeichen gefunden !");
                }
            }
        }

        public static void checkSyntax(string expr)
        {
            ScanForBadParens(expr);
            OperatorDannMulOperator(expr);
            DreiOperatorenNebenEinander(expr);
            ExpressionEmpty(expr);
            EmptyParen(expr);
            InvalidChars(expr);
        }
    }
}
