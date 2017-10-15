

namespace Common.Enums
{
    public class EnumHelper
    {
        public static ColumnDataType TranslateDataType(string dataType)
        {
            switch (dataType) {
                case "bigint":
                case "int": return ColumnDataType.Int;
                case "bit": return ColumnDataType.Bool;
                case "datetime":
                case "datetime2": return ColumnDataType.DateTime;
                case "decimal": return ColumnDataType.Decimal;

                case "nchar":
                case "ntext":
                case "nvarchar":               
                case "varchar": return ColumnDataType.String;
                case "uniqueidentifier": return ColumnDataType.UniqueIdentifier;
                default:  return ColumnDataType.Unknown;              
            }
            
        }

        public static ColumnDataType TranslateDataType(object dataType)
        {
            return TranslateDataType(dataType.ToString());
        }
    }
}
