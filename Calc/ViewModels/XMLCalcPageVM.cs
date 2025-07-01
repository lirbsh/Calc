using Calc.Models;
using Calc.ModelsLogic;
using System.Windows.Input;

namespace Calc.ViewModels
{
    public class XMLCalcPageVM: ObservableObject
    {
        private readonly Calculator calc = new();
        public ICommand ButtonsCommand { get; }
        public string Display => calc.Display;
        public XMLCalcPageVM()
        {
            ButtonsCommand = new Command<string>(OnButtonClick);
        }

        private void OnButtonClick(string cmd)
        {
            calc.OnXMLButtonClick(cmd);
            OnPropertyChanged(nameof(Display));
        }
    }
}
