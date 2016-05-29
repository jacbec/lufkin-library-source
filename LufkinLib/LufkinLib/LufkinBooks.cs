using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace LufkinLib
{
    public partial class LufkinBooks : Form
    {
        public static string ViewBooks { get; set; }

        #region Set DB variables
        private OleDbConnection connection;
        private DataSet dataSet = new DataSet();
        private OleDbCommand command = new OleDbCommand();
        private OleDbDataAdapter adapter;
        private DataRowCollection rowCollection;
        private DataTable table;
        #endregion

        public LufkinBooks()
        {
            InitializeComponent();
        }

        private void LufkinBooks_Load(object sender, EventArgs e)
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

            #region Load Books for Staff
            if (LufkinBooks.ViewBooks == "Staff")
            {
                try
                {
                    //Set the command text to query DB with
                    command.CommandText = "SELECT * FROM Media";

                    dataSet = new DataSet();

                    connection.Open();
                    command.Connection = connection;

                    adapter = new OleDbDataAdapter(command);
                    adapter.Fill(dataSet, "Media");
                    
                    rowCollection = dataSet.Tables["Media"].Rows;
                    table = dataSet.Tables["Media"];


                    int count = table.Rows.Count;
                    if (count >= 1)
                    {
                        dgvBooks.DataSource = dataSet.Tables["Media"];
                    }
                    else
                    {
                        MessageBox.Show("No books found!");
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

            #region Load Books for Member
            if (LufkinBooks.ViewBooks == "Member")
            {
                try
                {
                    //Set the command text to query DB with
                    command.CommandText = "SELECT * FROM Media";

                    dataSet = new DataSet();

                    connection.Open();
                    command.Connection = connection;

                    adapter = new OleDbDataAdapter(command);
                    adapter.Fill(dataSet, "Media");

                    rowCollection = dataSet.Tables["Media"].Rows;
                    table = dataSet.Tables["Media"];


                    int count = table.Rows.Count;
                    if (count >= 1)
                    {
                        dgvBooks.DataSource = dataSet.Tables["Media"];
                        dgvBooks.Columns.Remove("ID");
                        dgvBooks.Columns.Remove("CheckedOutBy");
                        dgvBooks.Columns.Remove("CheckOutDate");
                        dgvBooks.Columns.Remove("CheckedInBy");
                        dgvBooks.Columns.Remove("CheckInDate");
                        dgvBooks.Columns.Remove("InPossesionOf");
                        dgvBooks.Columns.Remove("NextForBook");
                    }
                    else
                    {
                        MessageBox.Show("No books found!");
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

            #region Load Books for Anyone
            if (LufkinBooks.ViewBooks == "Anyone")
            {
                try
                {
                    //Set the command text to query DB with
                    command.CommandText = "SELECT * FROM Media";

                    dataSet = new DataSet();

                    connection.Open();
                    command.Connection = connection;

                    adapter = new OleDbDataAdapter(command);
                    adapter.Fill(dataSet, "Media");

                    rowCollection = dataSet.Tables["Media"].Rows;
                    table = dataSet.Tables["Media"];

                    int count = table.Rows.Count;
                    if (count >= 1)
                    {
                        dgvBooks.DataSource = dataSet.Tables["Media"];
                        dgvBooks.Columns.Remove("ID");
                        dgvBooks.Columns.Remove("ISBN");
                        dgvBooks.Columns.Remove("Section");
                        dgvBooks.Columns.Remove("Unavailable");
                        dgvBooks.Columns.Remove("CheckedOutBy");
                        dgvBooks.Columns.Remove("CheckOutDate");
                        dgvBooks.Columns.Remove("CheckedInBy");
                        dgvBooks.Columns.Remove("CheckInDate");
                        dgvBooks.Columns.Remove("InPossesionOf");
                        dgvBooks.Columns.Remove("NextForBook");
                    }
                    else
                    {
                        MessageBox.Show("No books found!");
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

        private void LufkinBooks_OnFormClosed(object sender, EventArgs e)
        {
            LufkinBooks.ViewBooks = "";
        }
    }
}
