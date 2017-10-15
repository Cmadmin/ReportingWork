using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Common.Infrastructure;
using ReportingWork.Data.Infrastructure;

namespace ReportingWork.Controls
{
    public partial class TableSelectorCtrl : UserControl
    {
        private Form1 _parentForm;
        private ILogger _logger;
        private readonly IQueryFunctions _queryFunctions;
        private List<KeyValuePair<string, string>> _tableData;
       

        public TableSelectorCtrl(Form1 parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
            _logger = parentForm.Logger;
            _queryFunctions = _parentForm.QueryFunction;
            _tableData = new List<KeyValuePair<string, string>>();
            LoadAllTables();
        }

        private void LoadAllTables()
        {
            var table = _queryFunctions.DataTableFromStoredProcedure("LoadAllTables");
            if (table == null || table.Rows.Count <= 0) return;

            foreach (DataRow row in table.Rows)
            {
                _tableData.Add(new KeyValuePair<string, string>(row["name"].ToString(), row["ColumnJson"].ToString()));
                TableList.Items.Add(row["name"].ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tabName = TableList.GetItemText(TableList.SelectedItem);
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            //check that table is selected.
            if (TableList.SelectedIndex < 0)
            {
                MessageBox.Show("You need to select a table before adding.");
                return;
            }

            //check if table has not been added.
            var tabName = TableList.GetItemText(TableList.SelectedItem);
            SelectedTables.Items.Add(tabName);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (SelectedTables.SelectedIndex < 0)
            {
                MessageBox.Show("You need to select a table before removing.");
                return;
            }
            SelectedTables.Items.RemoveAt(SelectedTables.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var selectedTableList = new List<string>();

            foreach(var item in SelectedTables.Items)
            {
                selectedTableList.Add(item.ToString());
            }

            if (!selectedTableList.Any())
            {
                MessageBox.Show("You need to add some tables to generate your report!");
                return;
            }

            _parentForm.LoadColumnSelector(selectedTableList);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _parentForm.BackToServerSelector();
        }
        
    }
}
