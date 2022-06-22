using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class Calculator
    {
        private static double CalculateImpl(Expression expr)
        {
            return expr.Evaluate();
        }

        public static void Calculate(string exprString)
        {
            try
            {
                SyntaxChecker.checkSyntax(exprString);
                var result = CalculateImpl(new Expression(exprString));
                Console.WriteLine("Das Ergebniss ist: {0}", result);
            }
            catch (SyntaxChecker.BadMathematicalExpression e)
            {
                Console.WriteLine("INVALIDE SYNTAX !!!");
                Console.WriteLine("{0}", e.Message);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Man darf nicht durch 0 teilen !!!");
            }
            catch (SyntaxChecker.BadParensException e)
            {
                Console.WriteLine("{0}", e.Message);
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
