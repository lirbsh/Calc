using Calc.ModelsLogic;

namespace Calc.ViewModels
{
    internal class MainPageVM
    {
        public MainPageVM(Grid grdMain)
        {
          _ = new Calculator(grdMain);
        }
    }
}
