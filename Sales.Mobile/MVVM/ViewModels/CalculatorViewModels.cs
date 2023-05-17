using Android.App;
using PropertyChanged;
using Sales.Mobile.MVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sales.Mobile.MVVM.ViewModels
{

    [AddINotifyPropertyChangedInterface]
    public class CalculatorViewModels : INotifyPropertyChanged
    {
        public string _result;

        public ICommand ClearCommand => new Command(() => Result = "0");
        public ICommand DeleteCharacterCommand => new Command(() => Result = Result.Substring(0, Result.Length - 1));
        public ICommand PercentageCommand => new Command(() => Result = (Double.Parse(Result) * 0.01).ToString());
        public ICommand NumberSelectionCommand { get; set; }
        public ICommand OperatorSelectionCommand { get; set; }
        public ICommand CalculateCommand { get; set; }

        public CalculatorViewModels()
        {
            NumberSelectionCommand = new Command<string>(NumberSelect);
            OperatorSelectionCommand = new Command<string>(OperatorSelect);
            CalculateCommand = new Command(Calculate);

            Result = "0";
        }

        public void NumberSelect(string number)
        {
            if (Result == "0")
                Result = number;
            else
                Result += number;
        }

        public void OperatorSelect(string operation)
        {
            Result += operation;
        }

        public void Calculate()
        {
            try
            {
                var dataTable = new System.Data.DataTable();
                var result = dataTable.Compute(Result, "");
                Result = result.ToString();
            }
            catch (Exception ex)
            {
                Result = "Se presentó un error en la calculadora: " + ex.Message;
            }
        }

        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                changedButtonsCalculator(nameof(Result));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void changedButtonsCalculator(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
