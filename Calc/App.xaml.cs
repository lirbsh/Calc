using Calc.Views;

namespace Calc
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new XMLCalcPage(); // new AppShell();
        }
    }
}
