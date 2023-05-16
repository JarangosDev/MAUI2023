using Sales.Mobile.MVVM.ViewModels;

namespace Sales.Mobile.MVVM.Views;

public partial class Calculator : ContentPage
{
	public Calculator()
	{
		InitializeComponent();
		BindingContext = new CalculatorViewModels();
	}
}