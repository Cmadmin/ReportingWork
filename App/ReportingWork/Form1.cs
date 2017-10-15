using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Common.Implementation;
using Common.Infrastructure;
using ReportingWork.Controls;
using System.Collections.Generic;
using Common.Model;
using ReportingWork.Data.Infrastructure;
using ReportingWork.Data.Implementation;

namespace ReportingWork
{
    public partial class Form1 : Form
    {
        private readonly ILogger _logger;
        private readonly string _logFileName = DateTime.Now.ToString("yyyy MMMM dd") + ".txt";
        private SqlConnection _connection;
        private ServerAndDbSelectorCtrl _serverSelector;
        private TableSelectorCtrl _tableSelector;
        private ColumnSelector _columnSelector;

        public IQueryFunctions QueryFunction;
        public SqlConnection DbConnection => _serverSelector.DbConnection;
        public ILogger Logger => new SimpleFileLogger(_logFileName);
        
        public Form1()
        {
            _logger = new SimpleFileLogger(_logFileName);           
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _serverSelector = new ServerAndDbSelectorCtrl(this);
            Controls.Add(_serverSelector);
            //we need connection string for this. And it is only build in serveranddbselector
            
        }

        public void CreateQueryFunction()
        {
            QueryFunction = new QueryFunctions(DbConnection.ConnectionString, _logger);
        }
        public void LoadTableSelector(SqlConnection connection)
        {
            _connection = connection;
            _tableSelector = new TableSelectorCtrl(this);
            _serverSelector.Hide();
            Controls.Add(_tableSelector);
        }
        
        public void LoadColumnSelector(List<string> selectedItems)
        {
            _columnSelector = new ColumnSelector(this, selectedItems);
            _tableSelector.Hide();
            Controls.Add(_columnSelector);
        }

        public void BackToServerSelector()
        {
            _serverSelector.Show();
            _tableSelector.Hide();
        }
    }
}
