namespace Calc.Views;

public partial class XMLCalcPage : ContentPage
{
	public XMLCalcPage()
	{
		InitializeComponent();
		BindingContext = new ViewModels.XMLCalcPageVM();
    }
}