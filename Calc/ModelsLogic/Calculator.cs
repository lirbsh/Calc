
namespace Calc.ModelsLogic
{
    internal class Calculator
    {
        Label display;
        public Calculator(Grid grdMain) 
        {
            InitGrid(grdMain);
            display = new()
            {
                FontSize = 30,
                Margin = 2
            };
        }

        private void InitGrid(Grid grdMain)
        {
            int value = 1;
            grdMain.AddWithSpan(display, 0, 0, 1, 4);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    AddButton(grdMain, value++.ToString(), j, i + 1, 1);
            AddButton(grdMain, "+", 3, 1, 1);
            AddButton(grdMain, "-", 3, 2, 1);
            AddButton(grdMain, "x", 3, 3, 1);
            AddButton(grdMain, "/", 3, 4, 1);
            AddButton(grdMain, "0", 2, 4, 1);
            AddButton(grdMain, "=", 0, 4, 2);
        }

        private static void AddButton(Grid grdMain,string text,int column,int row,int columnSpan)
        {
            Button b = new()
            {
                Margin = 2,
                FontSize = 30,
                Text = text
            };
            if(columnSpan==1)
                grdMain.Add(b, column, row);
            else
                grdMain.AddWithSpan(b, row,column,1,columnSpan);
        }
    }
}
