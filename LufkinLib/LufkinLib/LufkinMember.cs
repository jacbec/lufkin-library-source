using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace LufkinLib
{
    public partial class LufkinMember : Form
    {
        #region Set DB variables
        private OleDbConnection connection;
        private DataSet dataSet = new DataSet();
        private OleDbCommand command = new OleDbCommand();
        private OleDbDataAdapter adapter;
        private DataRowCollection rowCollection;
        private DataTable table;
        #endregion

        public LufkinMember()
        {
            InitializeComponent();
        }

        private void LufkinMember_Load(object sender, EventArgs e)
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

            #region Load Books for Member
            if (Member.Username != null || Member.Username != "")
            {
                try
                {
                    //Set the command text to query DB with
                    command.CommandText = "SELECT * FROM Media WHERE [InPossesionOf] = @inPossesionOf";
                    command.Parameters.AddWithValue("@inPossesionOf", Member.CardNumber);

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
                        boxBooksCheckedOut.Text = "Books Checked Out";
                        
                        dgvBooksOut.DataSource = dataSet.Tables["Media"];
                        dgvBooksOut.Columns.Remove("ID");
                        dgvBooksOut.Columns.Remove("ISBN");
                        dgvBooksOut.Columns.Remove("Subject");
                        dgvBooksOut.Columns.Remove("Section");
                        dgvBooksOut.Columns.Remove("Unavailable");
                        dgvBooksOut.Columns.Remove("CheckedOutBy");
                        dgvBooksOut.Columns.Remove("CheckOutDate");
                        dgvBooksOut.Columns.Remove("CheckedInBy");
                        dgvBooksOut.Columns.Remove("CheckInDate");
                        dgvBooksOut.Columns.Remove("InPossesionOf");
                        dgvBooksOut.Columns.Remove("NextForBook");
                    }
                    else
                    {
                        boxBooksCheckedOut.Text = "You have no checked out books!";
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

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            if (Member.Username != null || Member.Username != "")
            {
                string msg = "";

                if (txtEditFirstName.Text != "")
                {
                    #region Edit First Name
                    try
                    {
                        //Set the command text to query DB with
                        command.CommandText = "UPDATE Members SET [FirstName] = @firstName WHERE [Username] = @username";
                        command.Parameters.AddWithValue("@firstName", txtEditFirstName.Text);
                        command.Parameters.AddWithValue("@username", Member.Username);

                        connection.Open();
                        command.Connection = connection;
                        command.ExecuteNonQuery();

                        txtEditFirstName.Text = "";

                        msg += "First Name Changed! \n";

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
                    #endregion
                }

                if (txtEditLastName.Text != "")
                {
                    #region Edit Last Name
                    try
                    {
                        //Set the command text to query DB with
                        command.CommandText = "UPDATE Members SET [LastName] = @lastName WHERE [Username] = @username";
                        command.Parameters.AddWithValue("@lastName", txtEditLastName.Text);
                        command.Parameters.AddWithValue("@username", Member.Username);

                        connection.Open();
                        command.Connection = connection;
                        command.ExecuteNonQuery();

                        txtEditLastName.Text = "";

                        msg += "Last Name Changed! \n";

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
                    #endregion
                }

                if (txtEditPassword.Text != "")
                {
                    #region Edit Password
                    try
                    {
                        //Set the command text to query DB with
                        command.CommandText = "UPDATE Members SET [Salt] = @salt, [Password] = @passwor WHERE [Username] = @username";

                        string salt = Encrypt.createSalt();
                        string hashedPassword = Encrypt.generateSHA256Hash(txtEditPassword.Text, salt);

                        command.Parameters.AddWithValue("@salt", salt);
                        command.Parameters.AddWithValue("@password", hashedPassword);
                        command.Parameters.AddWithValue("@username", Member.Username);

                        connection.Open();
                        command.Connection = connection;
                        command.ExecuteNonQuery();

                        txtEditPassword.Text = "";

                        msg += "Password Changed! \n";

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
                    #endregion
                }

                MessageBox.Show(String.Format(msg));
            }
            else
            {
                MessageBox.Show("You need to be a staff to edit this field!");
            }
        }

        private void btnRequestBook_Click(object sender, EventArgs e)
        {
            if (Member.Username != null || Member.Username != "")
            {
                if (txtRequestISBN.Text != "")
                {
                    #region Request Book 
                    try
                    {
                        //Set the command text to query DB with
                        command.CommandText = "INSERT INTO Request ([ISBN], [CardNumber]) VALUES (@iSBN, @cardNumber)";
                        command.Parameters.AddWithValue("@iSBN", Convert.ToInt32(txtRequestISBN.Text));
                        command.Parameters.AddWithValue("@cardNumber", Member.CardNumber);

                        connection.Open();
                        command.Connection = connection;
                        command.ExecuteNonQuery();

                        txtRequestISBN.Text = "";

                        connection.Close();

                        MessageBox.Show(String.Format("You have requested the book with {0} ISBN", txtRequestISBN.Text));
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
                    #endregion
                }
                else
                {
                    MessageBox.Show("ISBN is required to request a book!");
                }
            }
        }

        private void btnViewBooks_Click(object sender, EventArgs e)
        {
            if (Member.Username != null || Member.Username != "")
            {
                LufkinBooks.ViewBooks = "Member";

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
            else
            {
                MessageBox.Show("You need to be a member to view all books!");
            }
        }

        private void LufkinMember_OnFormClosed(object sender, EventArgs e)
        {
            #region Set Member Objects To Empty
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
