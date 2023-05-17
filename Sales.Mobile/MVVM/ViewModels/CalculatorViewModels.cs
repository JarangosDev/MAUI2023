using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Mobile.MVVM.ViewModels
{
    public class CalculatorViewModels
    {
        public int Number1 { get; set; }

        public int Number2 { get; set; }

        public static double Calculate(double Number1, double Number2, string Operator)
        {
            double result = 0;

            switch (Operator)
            {

                case "+":
                    result = Number1 + Number2;
                    break;

                case "-":
                    result = Number1 - Number2;
                    break;

                case "*":
                    result = Number1 * Number2;
                    break;

                case "/":
                    result = Number1 / Number2;
                    break;

                default:
                    break;
            }

            return result;
        }
    }
}
