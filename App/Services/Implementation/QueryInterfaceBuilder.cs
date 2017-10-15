using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Services.Implementation
{
    public class QueryInterfaceBuilder
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


    }
}
