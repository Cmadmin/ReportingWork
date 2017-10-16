
using System.Windows.Forms;
using System.Drawing;
using Services.Infrastructure;

namespace Services.Implementation
{
    public class QueryInterfaceBuilder : IQueryInterfaceBuilder
    {
        public Label MakeLabel(string text, bool autosize, Point position)
        {
            return new Label
            {
                Text = text,
                AutoSize = autosize,
                ForeColor = Color.Black,
                Location = position
            };
        }

        public TextBox MakeTextBox(string defaultText, int width, Point position)
        {
            return new TextBox
            {
                Width = width,
                Text = defaultText,
                Location = position
            };
        }

        public RadioButton MakeChainRadio(string id, Point position)
        {
            return new RadioButton
            {
                Name = id,
                Location = position,
                Width = 20
            };
        }

        public ToolTip MakeTooltip()
        {
            return new ToolTip
            {
                ToolTipTitle = "Help Text",
                UseAnimation = true
            };
        }

        public Control QueryForMatch(string labelText)
        {
            var label = new Label();
            label.Text = labelText;
            label.AutoSize = true;

            return new Panel
            {
                Controls = { label, new TextBox() }

            };
        }

        public Control QueryForSimpleMatch()
        {
            var box = new TextBox();
            box.Visible = true;
            box.Location = new Point(10, 20);

            return box;
        }

        public Control QueryForRange(string startLabel, string endLabel)
        {
            return new Panel
            {   
                Controls = { QueryForMatch(startLabel), QueryForMatch(endLabel) }
            };
        }

        public Panel QueryForRange()
        {
            return new Panel
            {
                Controls = { QueryForMatch(""), QueryForMatch(" And ") }
            };
        }


    }
}
