


namespace Calc.ModelsLogic
{
    public class Calculator
    {
        private readonly Label lblDisplay;
        public Calculator(Grid grdMain)
        {
            lblDisplay = new()
            {
                FontSize = 30,
                Margin = 2,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            InitGrid(grdMain);
        }

        private void InitGrid(Grid grdMain)
        {
            int value = 1;
            grdMain.AddWithSpan(lblDisplay, 0, 0, 1, 4);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    AddButton(grdMain, value++.ToString(), j, i + 1);
            AddButton(grdMain, "+", 3, 1);
            AddButton(grdMain, "-", 3, 2);
            AddButton(grdMain, "*", 3, 3);
            AddButton(grdMain, "/", 3, 4);
            AddButton(grdMain, "0", 2, 4);
            AddButton(grdMain, "=", 0, 4);
            AddButton(grdMain, "Clr", 1, 4);
        }

        private void AddButton(Grid grdMain, string text, int column, int row)
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

        private void OnButtonClick(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                Button btn = (Button)sender;
                string cmd = btn.Text;
                if (cmd == "Clr")
                    lblDisplay.Text = string.Empty;
                else if (cmd == "=")
                    Calculate();
                else
                    lblDisplay.Text +=cmd;
            }

        }

        private void Calculate()
        {
            string expration = lblDisplay.Text;
            if (expration.Contains('+'))
            {
                string[] parts = expration.Split('+');
                if (parts.Length == 2 && double.TryParse(parts[0], out double left) && double.TryParse(parts[1], out double right))
                    lblDisplay.Text = (left + right).ToString();
            }
            else if (expration.Contains("-"))
            {
                string[] parts = expration.Split('-');
                if (parts.Length == 2 && double.TryParse(parts[0], out double left) && double.TryParse(parts[1], out double right))
                    lblDisplay.Text = (left - right).ToString();
            }
            else if (expration.Contains('*'))
            {
                string[] parts = expration.Split('*');
                if (parts.Length == 2 && double.TryParse(parts[0], out double left) && double.TryParse(parts[1], out double right))
                    lblDisplay.Text = (left * right).ToString();
            }
            else if (expration.Contains("/"))
            {
                string[] parts = expration.Split('/');
                if (parts.Length == 2 && double.TryParse(parts[0], out double left) && double.TryParse(parts[1], out double right) && right != 0)
                    lblDisplay.Text = (left / right).ToString();
            }
            else
                lblDisplay.Text = "Not leagal Expretion";
        }
    }
}
