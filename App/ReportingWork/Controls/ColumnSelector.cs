using Common.Enums;
using Common.Model;
using ReportingWork.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportingWork.Controls
{
    public partial class ColumnSelector : UserControl
    {
        private List<string> _selectedTables;
        private Form1 _parentForm;
        private List<TableDto> _columnDetails;
        private IQueryFunctions _queryFunction;
        private Label _labelDetails = new Label();

        public List<QueryOperator> Operators = new List<QueryOperator>
        {
            new QueryOperator { Identifier = Operator.Equals, Name = "Equals", Symbol = "=", Description = "Only records that match input text will be returned."},
            new QueryOperator {Identifier = Operator.LessOrEqTo, Name = "LessOrEqualsTo", Symbol = "<=", Description = "Only records that are less or equal to value in input text will be returned."},
            new QueryOperator {Identifier = Operator.GreaterOrEqTo, Name = "GreaterOrEqualsTo", Symbol = ">=", Description = "Only records that are greater or equal to value in input text will be returned."},
            new QueryOperator {Identifier = Operator.Contains, Name = "Contains", Symbol = "Like", Description = "Only records that contain the value in input text will be returned."},
            new QueryOperator {Identifier = Operator.TrueOrFalse, Name = "TrueOrFalse", Symbol = "Is", Description = "Only records matching your selection will be returned."},
            new QueryOperator {Identifier = Operator.Between, Name = "Between", Symbol = "Between", Description = "Only records that are in the range specified in the input boxes will be returned."}
        };

        public ColumnSelector(Form1 parent, List<string> selectedTables)
        {
            InitializeComponent();
            _parentForm = parent;
            _selectedTables = selectedTables;
            _queryFunction = parent.QueryFunction;
            GetTableSchemaDetails(selectedTables);
            _labelDetails.AutoSize = true;
            pColumnDetails.Controls.Add(_labelDetails);//this will display table column schema details
        }


        public void GetTableSchemaDetails(List<string> tableNames)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("TableNames", string.Join(",", tableNames))
            };

            var table = _queryFunction.DataTableFromStoredProcedure("LoadTablesSchema", parameters);
            _columnDetails = TransformDtIntoObj(table);
            //Grab table names to display
            if (_columnDetails == null || _columnDetails.Count < 1)
                return;          

            lstTables.DataSource = tableNames;
           
            
        }

        private List<TableDto> TransformDtIntoObj(DataTable dt)
        {
            if (dt == null || dt.Rows.Count < 1)
            {
                MessageBox.Show("Sorry could not retrieve table details.");
                return null;
            }

            var returnList = new List<TableDto>();
            var tempTab = new TableDto();
            tempTab.Rows = new List<DBRowsDto>();
            var lastTableName = "";

            foreach(DataRow r in dt.Rows)
            {
                var tempTableName = r["TABLE_NAME"].ToString();

                var tempRow = new DBRowsDto
                {
                    Name = r["COLUMN_NAME"].ToString(),
                    SchemaName = r["TABLE_SCHEMA"].ToString(),
                    DataType = EnumHelper.TranslateDataType(r["DATA_TYPE"]),
                    ColumnDefault = r["COLUMN_DEFAULT"] != DBNull.Value? r["COLUMN_DEFAULT"].ToString() : "",
                    MaxLength = r["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value? Convert.ToInt32(r["CHARACTER_MAXIMUM_LENGTH"]) : default(int),
                    NumericPrecision = r["NUMERIC_PRECISION"] != DBNull.Value ? Convert.ToInt32(r["NUMERIC_PRECISION"]) : default(int),
                    NumericPrecisionRadix = r["NUMERIC_PRECISION_RADIX"] != DBNull.Value ? Convert.ToInt32(r["NUMERIC_PRECISION_RADIX"]) : default(int),
                    NumericScale = r["NUMERIC_SCALE"] != DBNull.Value ? Convert.ToInt32(r["NUMERIC_SCALE"]) : default(int),
                    DateTimePrecision = r["DATETIME_PRECISION"] != DBNull.Value ? Convert.ToInt32(r["DATETIME_PRECISION"]) : default(int)
                };
                
               
                if(!string.IsNullOrEmpty(lastTableName) 
                    && !lastTableName.Equals(tempTableName, StringComparison.CurrentCultureIgnoreCase))
                {
                    tempTab.Name = lastTableName;
                    returnList.Add(tempTab);
                    lastTableName = tempTableName;

                    tempTab = new TableDto();
                    tempTab.Name = tempTableName;
                    tempTab.Rows = new List<DBRowsDto>();                           
                }
                 
                tempTab.Rows.Add(tempRow);
                lastTableName = tempTableName;

            }

            //add the last outstanding table
            if(tempTab != null && tempTab.Rows.Count > 0)
            {
                if (returnList.Count <= 1)
                    tempTab.Name = lastTableName;
                returnList.Add(tempTab);
            }

            return returnList;
        }

        private void lstTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTables.SelectedIndex < 0)
            {
                MessageBox.Show("You need to select a table to view columns.");
                return;
            }

            var selectedTableName = lstTables.SelectedItem.ToString();

            var tab = _columnDetails.FirstOrDefault(x => x.Name.Equals(selectedTableName, StringComparison.CurrentCultureIgnoreCase));

            if(tab == null || tab.Rows.Count < 1)
            {
                MessageBox.Show("No table selected or invalid data in selected table.");
                return;
            }

            lstColumns.DataSource = tab.Rows.Select(x => x.Name).ToList();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            _parentForm.BackToServerSelector();
        }

        private void lstColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTableName = lstTables.SelectedItem.ToString();
            var tab = _columnDetails.FirstOrDefault(x => x.Name.Equals(selectedTableName, StringComparison.CurrentCultureIgnoreCase));

            if (tab == null)
            {
                MessageBox.Show("Sorry could not load selected table details.");
                return;
            }

            var selectedColumn = lstColumns.SelectedItem.ToString();
            var col = tab.Rows.FirstOrDefault(x => x.Name.Equals(selectedColumn, StringComparison.CurrentCultureIgnoreCase));

            if (col == null)
            {
                MessageBox.Show("Sorry could not load selected column details.");
                return;
            }

            var sbDetails = new StringBuilder();

            sbDetails.AppendLine("Name: " + col.Name);
            sbDetails.AppendLine("Default: " + col.ColumnDefault);
            sbDetails.AppendLine("Data Type: " + col.DataType);
            sbDetails.AppendLine("DateTime Precision: " + col.DateTimePrecision);
            sbDetails.AppendLine("Max Length: " + col.MaxLength);
            sbDetails.AppendLine("Numeric Precision: " + col.NumericPrecision);
            sbDetails.AppendLine("Precision Radix: " + col.NumericPrecisionRadix);
            sbDetails.AppendLine("Numeric Scale: " + col.NumericScale);
            sbDetails.AppendLine("Schema: " + col.SchemaName);

            _labelDetails.Text = sbDetails.ToString();

            var control = GenerateQueryInputSelector(col.DataType);
            //pQuery.Controls.Clear();
            //pQuery.Controls.Add(control);


            //tabProperties.Controls.Add(new Label() { Text = "Type:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 0);
            tabProperties.Controls.Clear();
            tabProperties.Controls.Add(control, 0, 0);

            return;

            //testing
            var leftOffset = 10;
            var topOffset = 10;

            //var rdOption = MakeChainRadio(1, selectedTableName, col.Name, new Point(leftOffset, topOffset));
            //var testlab = MakeLabel(" = ", true, new Point(leftOffset + 20, topOffset + 2));
            //var testbox = MakeTextBox("", 100, new Point(leftOffset + 45, topOffset));
            //var tooltip = MakeTooltip();
            //tooltip.SetToolTip(testbox, "Only records that match input text will be returned.");

           // var radioName = selectedTableName + "_" + col.Name + "_" + 1;
           // var container = MakeMatchControl(true, radioName, leftOffset, topOffset);

            //pQuery.Controls.Add(container);
            //pQuery.Controls.Add(rdOption);
            //pQuery.Controls.Add(testlab);
            //pQuery.Controls.Add(testbox);

            //pQuery.Controls.Add(control);      

        }

        private Control GenerateQueryInputSelector(ColumnDataType dataType)
        {
            switch (dataType)
            {
                case ColumnDataType.UniqueIdentifier:
                    return MakeInputOptions(new List<Operator> { Operator.Equals, Operator.Contains });
                case ColumnDataType.Int:
                case ColumnDataType.Decimal:
                    return MakeInputOptions(new List<Operator> { Operator.Equals, Operator.Between, Operator.LessOrEqTo, Operator.GreaterOrEqTo });
                case ColumnDataType.String:
                    return MakeInputOptions(new List<Operator> { Operator.Equals, Operator.Contains });
                case ColumnDataType.Bool:
                    return MakeInputOptions(new List<Operator> { Operator.TrueOrFalse });
                case ColumnDataType.DateTime:
                    return MakeInputOptions(new List<Operator> { Operator.Equals, Operator.Between, Operator.LessOrEqTo, Operator.GreaterOrEqTo });
            }
            return null;
        }

        private Control MakeInputOptions(List<Operator> Ops)
        {
            var comboSelect = new ComboBox();
            comboSelect.Location = new Point(10, 10);
            var panel = new Panel();
            var inputPanel = new Panel();

            panel.Controls.Add(comboSelect);
            panel.Controls.Add(inputPanel);

            comboSelect.SelectedIndexChanged += new EventHandler((object o, EventArgs e) =>
            {
                var selection = comboSelect.SelectedItem.ToString();
                var op = Operators.FirstOrDefault(x => x.Symbol.Equals(selection));
                Control temppanel = null;

                if(op.Identifier == Operator.TrueOrFalse)
                {
                    temppanel = QueryForBoolean("True", "False");
                }
                else if(op.Identifier == Operator.Between)
                {
                    temppanel = QueryForRange();
                }
                else
                {
                    temppanel = QueryForSimpleMatch();
                }

                tabProperties.Controls.Add(temppanel);
                
            });

            foreach (var op in Ops)
            {
                var opsel = Operators.FirstOrDefault(x => x.Identifier == op);
                comboSelect.Items.Add(opsel.Symbol);
            }

            return comboSelect;
        }

       
  

        private Control QueryForMatch(string labelText)
        {
            var label = new Label();
            label.Text = labelText;
            label.AutoSize = true;

            return new Panel
            {
                Controls = { label, new TextBox() }
                
            };
        }

        private Control QueryForSimpleMatch()
        {
            var box = new TextBox();
            box.Visible = true;
            box.Location = new Point(10, 20);

            return box;
        }

        private Control QueryForRange(string startLabel, string endLabel)
        {
            return new Panel
            {
                Controls = { QueryForMatch(startLabel), QueryForMatch(endLabel)}
            };
        }

        private Panel QueryForRange()
        {
            return new Panel
            {
                Controls = { QueryForMatch(""), QueryForMatch(" And ") }
            };
        }

        private Panel QueryForBoolean(string trueString, string falseString)
        {
            var radioButtonList = new RadioButton();
            var trueLabel = new Label();
            var falseLabel = new Label();
            var trueRadio = new RadioButton();
            var falseRadio = new RadioButton();

            trueRadio.Name = "rdTrue";
            falseRadio.Name = "rdFalse";
            trueLabel.Text = trueString;
            falseLabel.Text = falseString;

            return new Panel
            {
                Controls = { trueLabel, trueRadio, falseLabel, falseRadio }
            };
        }

    }
}
