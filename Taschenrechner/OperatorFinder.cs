using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class OperatorFinder
    {
        private static char[] _mulOperators = { '*', '/' };
        private static char[] _numOperators = { '+', '-' };

        public static int IndexOfLastOperator(string expr, bool isNumOperator)
        {
            int localLevel = 0;
            var operators = isNumOperator ? _numOperators : _mulOperators;
            var lastOperator = -1;
            for(int i = 0; i < expr.Length; i++)
            {
                char c = expr[i];
                if(c == '(')
                {
                    localLevel++;
                }
                else if(c == ')')
                {
                    localLevel--;
                }
                else if (operators.Contains(c) && localLevel == 0)
                {
                    lastOperator = i;
                }
            }
            return lastOperator;
        }
    }
}
