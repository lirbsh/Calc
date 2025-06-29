using Calc.ViewModels;

namespace Calc
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageVM(grdMain);
        }
    }
}
