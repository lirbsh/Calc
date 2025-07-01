using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Models
{
    public abstract class CalculatorModel
    {
        protected readonly Label lblDisplay;
        public CalculatorModel()
        {
            lblDisplay = new()
            {
                FontSize = 30,
                Margin = 2,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
        }
        protected abstract void InitGrid(Grid grdMain);
        protected abstract void AddButton(Grid grdMain, string text, int column, int row);
        protected abstract void OnButtonClick(object? sender, EventArgs e);
        protected abstract void Calculate(bool xml);
        public abstract void OnXMLButtonClick(string cmd);

    }
}
