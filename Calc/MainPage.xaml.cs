using Calc.ViewModels;

namespace Calc
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            _ = new MainPageVM(grdMain);
        }
    }
}
