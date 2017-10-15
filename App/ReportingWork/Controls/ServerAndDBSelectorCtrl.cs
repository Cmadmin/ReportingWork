using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Enums;
using System.Configuration;

namespace ReportingWork.Controls
{
    public partial class ServerAndDbSelectorCtrl : UserControl
    {
        private bool _connectionInitialized = false;
        private readonly Form1 _parentForm;
        private SqlConnection _connection;
        private ConnectionStringMode _connectionMode = ConnectionStringMode.Unknown;

        public SqlConnection DbConnection
        {
            get
            {
                if (_connection != null && !string.IsNullOrEmpty(_connection.ConnectionString)) return _connection;

                var connectionString = rdConnString.Checked?
                    txtConnectionString.Text :
                    CreateConnectionString(txtServerName.Text, txtCatalogue.Text, integratedSecurity: true,
                    userName: txtUserName.Text, password: txtPassword.Text);

                _connection = CreateConnection(connectionString);

                return _connection;
            }
        }

        public ServerAndDbSelectorCtrl(Form1 formParent)
        {
            InitializeComponent();
            ToggleConnectionStringBuilder(false);
            _parentForm = formParent;
            //set default connectionstring for testing
            txtConnectionString.Text = ConfigurationManager.AppSettings["DefaultConnString"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!EntriesValid())
            {
                MessageBox.Show("Invalid entries for the connection string!");
                return;
            }

            _parentForm.CreateQueryFunction();//we need to update this component for db
            _parentForm.LoadTableSelector(DbConnection);
        }

        private SqlConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        private string CreateConnectionString(string server, string databaseName, bool multipleResultSet = false,
            bool persistSecurityInfo = true,  bool integratedSecurity = false, string userName = "", string password = "")
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = server, // server address
                InitialCatalog = databaseName, // database name
                IntegratedSecurity = integratedSecurity, // server auth(false)/win auth(true)
                MultipleActiveResultSets = multipleResultSet, // activate/deactivate MARS
                PersistSecurityInfo = persistSecurityInfo, // hide login credentials
                UserID = userName, // user name
                Password = password // password
            };
            return builder.ConnectionString;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ToggleConnectionStringBuilder(false);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ToggleConnectionStringBuilder(true);
        }

        private void ToggleConnectionStringBuilder(bool enable)
        {
            rdConnString.Checked = !enable;
            rdConnStringWizard.Checked = enable;
            _connectionMode = ConnectionStringMode.FullString;

            txtServerName.Enabled = 
                txtCatalogue.Enabled =
                txtPassword.Enabled =
                txtUserName.Enabled =
                ckActiveResults.Enabled =
                ckIntegratedSecurity.Enabled =
                ckPersistSecurityInfo.Enabled = enable;
            txtConnectionString.Enabled = !enable;
        }

        private bool EntriesValid()
        {
            if ((_connectionMode == ConnectionStringMode.Unknown)
                ||
                    (_connectionMode == ConnectionStringMode.FullString && string.IsNullOrEmpty(txtConnectionString.Text))
                )
                return false;

            if (_connectionMode == ConnectionStringMode.Manual)
            {
                if (string.IsNullOrEmpty(txtServerName.Text) || string.IsNullOrEmpty(txtCatalogue.Text))
                    return false;

                if (!ckIntegratedSecurity.Checked && (string.IsNullOrEmpty(txtUserName.Text) ||
                                                      string.IsNullOrEmpty(txtPassword.Text)))
                    return false;
            }

            return true;
        }

    }
}
