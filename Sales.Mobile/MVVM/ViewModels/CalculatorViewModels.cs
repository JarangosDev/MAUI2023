using PropertyChanged;
using System.ComponentModel;
using System.Windows.Input;

namespace Sales.Mobile.MVVM.ViewModels
{

    [AddINotifyPropertyChangedInterface]
    public class CalculatorViewModels : INotifyPropertyChanged
    {
        public string _result;

        public ICommand ClearCommand => new Command(() => Result = "0");
        public ICommand DeleteCharacter => new Command(() => Result = Result.Substring(0, Result.Length - 1));
        public ICommand PercentCommand => new Command(() => Result = (Double.Parse(Result) * 0.01).ToString());
        public ICommand SelectCommand { get; set; }
        public ICommand OperatorSelectCommand { get; set; }
        public ICommand CalculateOrder { get; set; }

        public CalculatorViewModels()
        {
            SelectCommand = new Command<string>(NumberSelect);
            OperatorSelectCommand = new Command<string>(OperatorSelect);
            CalculateOrder = new Command(Calculate);

            Result = "0";
        }

        public void NumberSelect(string number)
        {
            if (Result == "0")
                Result = number;
            else
                Result += number;
        }

        public void Calculate()
        {
            try
            {
                var data = new System.Data.DataTable();
                var result = data.Compute(Result, "");
                Result = result.ToString();
            }
            catch (Exception ex)
            {
                Result = "*Error* " + ex.Message;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void changedButton(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void OperatorSelect(string operation)
        {
            Result += operation;
        }

        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                changedButton(nameof(Result));
            }
        }
    }
}
