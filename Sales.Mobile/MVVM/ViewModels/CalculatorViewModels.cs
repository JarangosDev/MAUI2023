using Android.App;
using PropertyChanged;
using Sales.Mobile.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sales.Mobile.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CalculatorViewModels
    {
        public double Number1 { get; set; }

        public double Number2 { get; set; }

        public string Operator { get; set; }

        public string Result { get; set; }

        public ICommand OnCalculate => new Command(() =>
        {
            if (currentState == 2)
            {
                var result = Calculate(Number1, Number2, Operator);

                Result = result.ToString();
                Number1 = result;
                currentState = -1;
            }
        });


        public int currentState = 1;

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

        public ICommand OnClear => new Command((object sender) =>
        {
            Number1 = 0;
            Number2 = 0;
            currentState = 1;
            Result = "0";
        });

        //public ICommand OnNumberSelection => new Command((sender) =>
        //{
        //    Button button = (Button)sender;
        //    string btnPressed = button.Text;

        //    if (this.result.Text == "0" || currentState < 0)
        //    {
        //        this.result.Text = string.Empty;
        //        if (currentState < 0)
        //            currentState *= -1;
        //    }

        //    this.result.Text += btnPressed;

        //    double number;
        //    if (double.TryParse(this.result.Text, out number))
        //    {
        //        this.result.Text = number.ToString("N0");
        //        if (currentState == 1)
        //        {
        //            Number1 = number;
        //        }
        //        else
        //        {
        //            Number2 = number;
        //        }
        //    }
        //});

        public ICommand OnOperatorSelection => new Command((object sender) =>
        {
            currentState = -2;
            Button button = (Button)sender;
            string btnPressed = button.Text;
            Operator = btnPressed;

        });
    }
}
