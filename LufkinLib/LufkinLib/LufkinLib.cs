using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace LufkinLib
{
    public partial class LufkinLib : Form
    {
        #region Set variables
        private OleDbConnection connection;
        private DataSet dataSet = new DataSet();
        private OleDbCommand command = new OleDbCommand();
        private OleDbDataAdapter adapter;
        private  DataRowCollection rowCollection;
        private DataTable table;

        private string salt = null;
        private string password = null;
        private string hashedPassword = null;
        #endregion

        public LufkinLib()
        {
            InitializeComponent();
        }

        private void LufkinLib_Load(object sender, EventArgs e)
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
        }

        private void btnStaffLogin_Click(object sender, EventArgs e)
        {
            if (txtStaffUsername.Text != "" && txtStaffPassword.Text != "")
            { 
                #region Log Staff in
                try
                {
                    //Set the command text to query DB with
                    command.CommandText = string.Format("SELECT * FROM Staff WHERE [Username] = '{0}'", txtStaffUsername.Text);

                    dataSet = new DataSet();

                    connection.Open();
                    command.Connection = connection;

                    adapter = new OleDbDataAdapter(command);
                    adapter.Fill(dataSet, "Staff");

                    //Start our check of password
                    rowCollection = dataSet.Tables["Staff"].Rows;
                    table = dataSet.Tables["Staff"];

                    int count = table.Rows.Count;
                    if (count == 1)
                    {
                        //Loop the data set for salt and password
                        foreach (DataRow dataRow in rowCollection)
                        {
                            salt = (string)dataRow["Salt"];
                            password = (string)dataRow["Password"];
                            hashedPassword = Encrypt.generateSHA256Hash(txtStaffPassword.Text, salt);

                            if (hashedPassword == password)
                            {
                                Staff.ID = (int)dataRow["StaffId"];
                                Staff.FirstName = (string)dataRow["FirstName"];
                                Staff.LastName = (string)dataRow["LastName"];
                                Staff.Username = (string)dataRow["Username"];
                                Staff.Position = (string)dataRow["Position"];

                                txtStaffUsername.Text = "";
                                txtStaffPassword.Text = "";

                                //Make second form
                                LufkinStaff lufkinStaff = new LufkinStaff();

                                //Set second form's start position as same as parent form
                                lufkinStaff.StartPosition = FormStartPosition.Manual;
                                lufkinStaff.Location = new Point(this.Location.X, this.Location.Y);

                                //Set parent form's visible to false
                                this.Visible = false;

                                //Open second dialog
                                lufkinStaff.ShowDialog();

                                //Set parent form's visible to true
                                this.Visible = true;

                                connection.Close();
                            }
                            else
                            {
                                MessageBox.Show("Username or password is incorrect!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message));
                    return;
                }
                finally
                {
                    if(connection != null) connection.Close();
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Username and password are required!");
            }
        }

        private void btnMemberLogin_Click(object sender, EventArgs e)
        {
            if (txtMemberUsername.Text != "" && txtMemberPassword.Text != "")
            {
              #region Log Member in
                try
                {
                    //Set the command text to query DB with
                    command.CommandText = string.Format("SELECT * FROM Members WHERE [Username] = '{0}'", txtMemberUsername.Text);

                    dataSet = new DataSet();

                    connection.Open();
                    command.Connection = connection;

                    adapter = new OleDbDataAdapter(command);
                    adapter.Fill(dataSet, "Members");

                    //Start our check of password
                    rowCollection = dataSet.Tables["Members"].Rows;
                    table = dataSet.Tables["Members"];

                    int count = table.Rows.Count;
                    if (count == 1)
                    {
                        //Loop the data set for salt and password
                        foreach (DataRow dataRow in rowCollection)
                        {
                            salt = (string)dataRow["Salt"];
                            password = (string)dataRow["Password"];
                            hashedPassword = Encrypt.generateSHA256Hash(txtMemberPassword.Text, salt);

                            if (hashedPassword == password)
                            {
                                Member.CardNumber = (int)dataRow["CardNumber"];
                                Member.FirstName = (string)dataRow["FirstName"];
                                Member.LastName = (string)dataRow["LastName"];
                                Member.Username = (string)dataRow["Username"];
                                Member.City = (string)dataRow["City"];
                                Member.Street = (string)dataRow["Street"];
                                Member.Zip = (int)dataRow["Zip"];
                                Member.State = (string)dataRow["State"];

                                txtMemberUsername.Text = "";
                                txtMemberPassword.Text = "";

                                //Make second form
                                LufkinMember lufkinMember = new LufkinMember();

                                //Set second form's start position as same as parent form
                                lufkinMember.StartPosition = FormStartPosition.Manual;
                                lufkinMember.Location = new Point(this.Location.X, this.Location.Y);

                                //Set parent form's visible to false
                                this.Visible = false;

                                //Open second dialog
                                lufkinMember.ShowDialog();

                                //Set parent form's visible to true
                                this.Visible = true;

                                connection.Close();
                            }
                            else
                            {
                                MessageBox.Show("Username or password is incorrect!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message));
                    return;
                }
                finally
                {
                    if (connection != null) connection.Close();
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Username and password are required!");
            }
        }

        private void btnViewBooks_Click(object sender, EventArgs e)
        {
            LufkinBooks.ViewBooks = "Anyone";

            #region Load Book Form
            //Make second form
            LufkinBooks lufkinBooks = new LufkinBooks();

            //Set second form's start position as same as parent form
            lufkinBooks.StartPosition = FormStartPosition.Manual;
            lufkinBooks.Location = new Point(this.Location.X, this.Location.Y);

            //Open second dialog
            lufkinBooks.ShowDialog();

            //Set parent form's visible to true
            this.Visible = true;
            #endregion
        }

        private void LufkinLib_OnFormClosed(object sender, EventArgs e)
        {
            #region Set Objects To Empty
            Staff.ID = Convert.ToInt32(null);
            Staff.FirstName = "";
            Staff.LastName = "";
            Staff.Username = "";
            Staff.Position = "";

            Member.CardNumber = Convert.ToInt32("");
            Member.FirstName = "";
            Member.LastName = "";
            Member.Username = "";
            Member.City = "";
            Member.Street = "";
            Member.Zip = Convert.ToInt32("");
            Member.State = "";
            #endregion
        }
    }
}
