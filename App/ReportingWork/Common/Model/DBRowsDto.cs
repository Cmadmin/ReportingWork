using Common.Enums;

namespace Common.Model
{
    public class DBRowsDto
    {
        public string Name { get; set; }
        public string SchemaName { get; set; }
        public ColumnDataType DataType { get; set; }
        public string ColumnDefault { get; set; }
        public int? MaxLength { get; set; }
        public int? NumericPrecision { get; set; }
        public int? NumericPrecisionRadix { get; set; }
        public int? NumericScale { get; set; }
        public int? DateTimePrecision { get; set; }
    }
}
