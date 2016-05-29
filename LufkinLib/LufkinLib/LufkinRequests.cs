using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace LufkinLib
{
    public partial class LufkinRequests : Form
    {
        public static string ViewRequests { get; set; }

        #region Set DB variables
        private OleDbConnection connection;
        private DataSet dataSet = new DataSet();
        private OleDbCommand command = new OleDbCommand();
        private OleDbDataAdapter adapter;
        private DataRowCollection rowCollection;
        private DataTable table;
        #endregion

        public LufkinRequests()
        {
            InitializeComponent();
        }

        private void LufkinRequests_Load(object sender, EventArgs e)
        {
            #region Connect to DB
            try
            {
                connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\LufkinLib.V2.accdb; Persist Security Info = False;";
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error: Failed to create a database connection. \n{0}", ex.Message));
                return;
            }
            #endregion

            #region Load Requests for Staff
            if (LufkinRequests.ViewRequests == "Staff")
            {
                try
                {
                    //Set the command text to query DB with
                    command.CommandText = "SELECT * FROM Request";

                    dataSet = new DataSet();

                    connection.Open();
                    command.Connection = connection;

                    adapter = new OleDbDataAdapter(command);
                    adapter.Fill(dataSet, "Request");

                    rowCollection = dataSet.Tables["Request"].Rows;
                    table = dataSet.Tables["Request"];


                    int count = table.Rows.Count;
                    if (count >= 1)
                    {
                        dgvRequests.DataSource = dataSet.Tables["Request"];
                    }
                    else
                    {
                        MessageBox.Show("No requests found!");
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex));
                    return;
                }
                finally
                {
                    if (connection != null) connection.Close();
                }
            }
            #endregion 
        }

        private void LufkinRequests_OnFormClosed(object sender, EventArgs e)
        {
            LufkinRequests.ViewRequests = "";
        }
    }
}
