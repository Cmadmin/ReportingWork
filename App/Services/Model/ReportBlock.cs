
using Services.Enums;
using System.Collections.Generic;

namespace Services.Model
{
    public class ReportBlock
    {
        public int Id { get; set; }

        public string TopLabel { get; set; }

        public string BottomLabel { get; set; }

        public List<Table> Tables { get; set; }

        public List<ColumnClue> Clues { get; set; }

        public DisplayType DisplayType { get; set; }

        public string DynamicSQL { get; set; }

        public string[,] MetaData { get; set; }

    }
}
