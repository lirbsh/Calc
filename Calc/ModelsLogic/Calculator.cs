
using Calc.Models;
namespace Calc.ModelsLogic
{
    public class Calculator : CalculatorModel
    {
        public string Display { get; private set; } = string.Empty;
        public Calculator(Grid grdMain) : base()
        {
            InitGrid(grdMain);
        }

        public Calculator()
        {
        }

        protected override void InitGrid(Grid grdMain)
        {
            int value = 1;
            grdMain.AddWithSpan(lblDisplay, 0, 0, 1, 4);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    AddButton(grdMain, value++.ToString(), j, i + 1);
            AddButton(grdMain, "+", 3, 1);
            AddButton(grdMain, "-", 3, 2);
            AddButton(grdMain, "*", 3, 3);
            AddButton(grdMain, "=", 0, 4);
            AddButton(grdMain, "Clr", 1, 4);
            AddButton(grdMain, "0", 2, 4);
            AddButton(grdMain, "/", 3, 4);
        }

        protected override void AddButton(Grid grdMain, string text, int column, int row)
        {
            Button b = new()
            {
                Margin = 2,
                FontSize = 30,
                Text = text
            };
            b.Clicked += OnButtonClick;
            grdMain.Add(b, column, row);
        }

        protected override void OnButtonClick(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                Button btn = (Button)sender;
                string cmd = btn.Text;
                if (cmd == "Clr")
                    lblDisplay.Text = string.Empty;
                else if (cmd == "=")
                    Calculate(false);
                else
                    lblDisplay.Text += cmd;
            }
        }

        protected override void Calculate(bool xml)
        {
            static double Add(double x, double y) => x + y;
            static double Substruct(double x, double y) => x - y;
            static double Multiply(double x, double y) => x * y;
            static double Devide(double x, double y) => x / y;
            Func<double, double, double>[] funcs = [Add, Substruct, Multiply, Devide];
            string oparators = "+-*/", separator = string.Empty, result = string.Empty,
                expration = xml ? Display : lblDisplay.Text;
            string[] parts = [];
            bool found = false;
            for (int i = 0; i < oparators.Length && !found; i++)
            {
                separator = oparators.Substring(i, 1);
                if (expration.Contains(separator))
                {
                    parts = expration.Split(separator);
                    if (parts.Length == 2 && double.TryParse(parts[0], out double left) && double.TryParse(parts[1], out double right))
                    {
                        if (i == 3 && right == 0 && separator == "/")
                            result = "Division by zero is not allowed";
                        else
                            result = funcs[i](left, right).ToString();
                        found = true;
                    }
                }
            }
            if (!found)
                result = "Not leagal Expretion";
            if (xml)
                Display = result;
            else
                lblDisplay.Text = result;
        }
        public override void OnXMLButtonClick(string cmd)
        {
            if (cmd == "Clr")
                Display = string.Empty;
            else if (cmd == "=")
                Calculate(true);
            else
                Display += cmd;
        }
    }
}
