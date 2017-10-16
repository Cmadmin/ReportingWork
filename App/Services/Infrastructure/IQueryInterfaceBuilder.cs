
using System.Drawing;
using System.Windows.Forms;

namespace Services.Infrastructure
{
    public interface IQueryInterfaceBuilder
    {
        Label MakeLabel(string text, bool autosize, Point position);

        TextBox MakeTextBox(string defaultText, int width, Point position);

        RadioButton MakeChainRadio(string id, Point position);

        ToolTip MakeTooltip();

        Control QueryForMatch(string labelText);

        Control QueryForSimpleMatch();

        Control QueryForRange(string startLabel, string endLabel);

        Panel QueryForRange();
    }
}
