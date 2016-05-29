using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace LufkinLib
{
    public partial class LufkinStaff : Form
    {
        #region Set DB variables
        private OleDbConnection connection;
        private DataSet dataSet = new DataSet();
        private OleDbCommand command = new OleDbCommand();
        private OleDbDataAdapter adapter;
        private DataRowCollection rowCollection;
        private DataTable table;
        #endregion

        public LufkinStaff()
        {
            InitializeComponent();
        }

        private void LufkinStaff_Load(object sender, EventArgs e)
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

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            if (Staff.Position != null || Staff.Position != "")
            {
                if (txtMemberFirstName.Text != "" && txtMemberLastName.Text != "" && txtMemberCity.Text != "" && txtMemberStreet.Text != "" && txtMemberZip.Text != "" && txtMemberState.Text != "" && txtMemberPassword.Text != "")
                {
                    int cardNumber = 0;

                    #region Get the last CardNumber
                    try
                    {
                        //Set the command text to query DB with
                        command.CommandText = "SELECT * FROM Members";

                        dataSet = new DataSet();

                        connection.Open();
                        command.Connection = connection;

                        adapter = new OleDbDataAdapter(command);
                        adapter.Fill(dataSet, "Members");

                        //Start our check for CardNumber
                        rowCollection = dataSet.Tables["Members"].Rows;
                        table = dataSet.Tables["Members"];

                        int count = table.Rows.Count;
                        if (count >= 1)
                        {
                            //Loop through data to get last CardNumber
                            foreach (DataRow dataRow in rowCollection)
                            {
                                cardNumber = (int)dataRow[0];
                            }

                            cardNumber++;

                            connection.Close();
                        }
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

                    string username = null;

                    #region Set Username
                    try
                    {
                        bool end = false;
                        int i = 1;

                        //Loop until we get end = true
                        while (end == false)
                        {
                            //Set the username
                            username = txtMemberFirstName.Text.Substring(0, 1) + txtMemberLastName.Text.Substring(0, 3) + i;

                            //Set the command text to query DB with
                            command.CommandText = String.Format("SELECT [Username] FROM Members WHERE [Username] = '{0}'", username);

                            dataSet = new DataSet();

                            connection.Open();
                            command.Connection = connection;

                            adapter = new OleDbDataAdapter(command);
                            adapter.Fill(dataSet, "Members");

                            //Start our check if username already exists
                            rowCollection = dataSet.Tables["Members"].Rows;
                            table = dataSet.Tables["Members"];

                            int count = table.Rows.Count;
                            if (count >= 1)
                            {
                                end = false;
                                i++;
                            }
                            else
                            {
                                end = true;
                            }
                        }
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

                    #region Set Member Password
                    string salt = Encrypt.createSalt();
                    string hashedPassword = Encrypt.generateSHA256Hash(txtMemberPassword.Text, salt);
                    #endregion

                    #region Insert the Member
                    try
                    {
                        //Set the command text to query DB with
                        command.CommandText = "INSERT INTO Members ([CardNumber], [FirstName], [LastName], [Username], [City], [Street], [Zip], [State], [Salt], [Password]) VALUES (@cardNumber, @firstName, @lastName, @username, @city, @street, @zip, @state, @salt, @password)";
                        command.Parameters.AddWithValue("@cardNumber", cardNumber);
                        command.Parameters.AddWithValue("@firstName", txtMemberFirstName.Text);
                        command.Parameters.AddWithValue("@lastName", txtMemberLastName.Text);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@city", txtMemberCity.Text);
                        command.Parameters.AddWithValue("@street", txtMemberStreet.Text);
                        command.Parameters.AddWithValue("@zip", Convert.ToInt32(txtMemberZip.Text));
                        command.Parameters.AddWithValue("@state", txtMemberState.Text);
                        command.Parameters.AddWithValue("@salt", salt);
                        command.Parameters.AddWithValue("@password", hashedPassword);

                        connection.Open();
                        command.Connection = connection;
                        command.ExecuteNonQuery();

                        txtMemberFirstName.Text = "";
                        txtMemberLastName.Text = "";
                        txtMemberCity.Text = "";
                        txtMemberStreet.Text = "";
                        txtMemberZip.Text = "";
                        txtMemberState.Text = "";
                        txtMemberPassword.Text = "";

                        MessageBox.Show(String.Format("Member {0} added!", username));

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
                else
                {
                    MessageBox.Show("All member fields are require to add a member!");
                }
            }
            else
            {
                MessageBox.Show("You need to be a staff to edit this field!");
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            if (Staff.Position != null || Staff.Position != "")
            {
                if (txtAddISBN.Text != "" && txtAddTitle.Text != "" && txtAddAuthor.Text != "" && txtAddSubject.Text != "" && txtAddSection.Text != "" && txtAddMediaType.Text != "")
                {
                    #region Insert the Book
                    try
                    {
                        //Set the command text to query DB with
                        command.CommandText = "INSERT INTO Media ([ISBN], [Title], [Author], [Subject], [Section], [Unavailable], [Fiction], [MediaType]) VALUES (@iSBN, @title, @author, @subject, @section, @unavailable, @fiction, @mediaType)";
                        command.Parameters.AddWithValue("@iSBN", Convert.ToInt32(txtAddISBN.Text));
                        command.Parameters.AddWithValue("@title", txtAddISBN.Text);
                        command.Parameters.AddWithValue("@author", txtAddAuthor.Text);
                        command.Parameters.AddWithValue("@subject", txtAddSubject.Text);
                        command.Parameters.AddWithValue("@section", txtAddSection.Text);
                        command.Parameters.AddWithValue("@unavailable", false);
                        command.Parameters.AddWithValue("@fiction", chkAddFiction.Checked);
                        command.Parameters.AddWithValue("@mediaType", txtAddMediaType.Text);

                        connection.Open();
                        command.Connection = connection;
                        command.ExecuteNonQuery();

                        txtAddISBN.Text = "";
                        txtAddISBN.Text = "";
                        txtAddAuthor.Text = "";
                        txtAddSubject.Text = "";
                        txtAddSection.Text = "";
                        chkAddFiction.Checked = false;
                        txtAddMediaType.Text = "";

                        MessageBox.Show(String.Format("Book with {0} ISBN added!", txtAddISBN.Text));

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
                else
                {
                    MessageBox.Show("All book fields are require to add a book!");
                }
            }
            else
            {
                MessageBox.Show("You need to be a staff to edit this field!");
            }
        }

        private void btnCheckOutBook_Click(object sender, EventArgs e)
        {
            if (Staff.Position != null || Staff.Position != "")
            { 
                if (txtCheckOutISBN.Text != "" && txtCheckOutCardNumber.Text != "")
                {                
                    #region Check Out Book
                    try
                    {
                        //Set the command text to query DB with
                        command.CommandText = "UPDATE Media SET [Unavailable] = true, [CheckedOutBy] = @checkedOutBy, [CheckOutDate] = @checkOutDate, [CheckedInBy] = @checkedInBy, [CheckInDate] = @checkInDate, [InPossesionOf] = @inPossesionOf WHERE [ISBN] = @iSBN";
                        command.Parameters.AddWithValue("@checkedOutBy", Staff.Username);
                        command.Parameters.AddWithValue("@checkOutDate", DateTime.Today.ToString("MM/dd/yyyy"));
                        command.Parameters.AddWithValue("@checkedInBy", DBNull.Value);
                        command.Parameters.AddWithValue("@checkInDate", DBNull.Value);
                        command.Parameters.AddWithValue("@inPossesionOf", Convert.ToInt32(txtCheckOutCardNumber.Text));
                        command.Parameters.AddWithValue("@iSBN", Convert.ToInt32(txtCheckOutISBN.Text));

                        connection.Open();
                        command.Connection = connection;
                        command.ExecuteNonQuery();

                        txtCheckOutISBN.Text = "";
                        txtCheckOutCardNumber.Text = "";

                        MessageBox.Show(String.Format("Book with {0} ISBN Checked Out!", txtCheckOutISBN.Text));

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
                else
                {
                    MessageBox.Show("All fields are require to check out a book!");
                }
            }
            else
            {
                MessageBox.Show("You need to be a staff to edit this field!");
            }
        }

        private void btnCheckInBook_Click(object sender, EventArgs e)
        {
            if (Staff.Position != null || Staff.Position != "")
            { 
                if (txtCheckInISBN.Text != "")
                {
                    #region Check In Book
                    try
                    {
                        //Set the command text to query DB with
                        command.CommandText = "UPDATE Media SET [Unavailable] = false, [CheckedOutBy] = @checkedOutBy, [CheckOutDate] = @checkOutDate, [CheckedInBy] = @checkedInBy, [CheckInDate] = @checkInDate, [InPossesionOf] = @inPossesionOf WHERE [ISBN] = @iSBN";
                        command.Parameters.AddWithValue("@checkedOutBy", DBNull.Value);
                        command.Parameters.AddWithValue("@checkOutDate", DBNull.Value);
                        command.Parameters.AddWithValue("@checkedInBy", Staff.Username);
                        command.Parameters.AddWithValue("@checkInDate", DateTime.Today.ToString("MM/dd/yyyy"));
                        command.Parameters.AddWithValue("@inPossesionOf", DBNull.Value);
                        command.Parameters.AddWithValue("@iSBN", Convert.ToInt32(txtCheckInISBN.Text));

                        connection.Open();
                        command.Connection = connection;
                        command.ExecuteNonQuery();

                        MessageBox.Show(String.Format("Book with {0} ISBN Checked In!", txtCheckInISBN.Text));

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

                    txtCheckInISBN.Text = "";
                }
                else
                {
                    MessageBox.Show("All fields are require to check in a book!");
                }
            }
            else
            {
                MessageBox.Show("You need to be a staff to edit this field!");
            }
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            if (Staff.Position != null || Staff.Position != "")
            { 
                string msg = "";

                if (txtEditFirstName.Text != "")
                {
                    #region Edit First Name
                    try
                    {
                        //Set the command text to query DB with
                        command.CommandText = "UPDATE Staff SET [FirstName] = @firstName WHERE [Username] = @username";
                        command.Parameters.AddWithValue("@firstName", txtEditFirstName.Text);
                        command.Parameters.AddWithValue("@username", Staff.Username);

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
                        command.CommandText = "UPDATE Staff SET [LastName] = @lastName WHERE [Username] = @username";
                        command.Parameters.AddWithValue("@lastName", txtEditLastName.Text);
                        command.Parameters.AddWithValue("@username", Staff.Username);

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
                        command.CommandText = "UPDATE Staff SET [Salt] = @salt, [Password] = @passwor WHERE [Username] = @username";

                        string salt = Encrypt.createSalt();
                        string hashedPassword = Encrypt.generateSHA256Hash(txtEditPassword.Text, salt);

                        command.Parameters.AddWithValue("@salt", salt);
                        command.Parameters.AddWithValue("@password", hashedPassword);
                        command.Parameters.AddWithValue("@username", Staff.Username);

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

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            if (Staff.Position == "Head Librarian")
            { 
                if (txtStaffFirstName.Text != "" && txtStaffLastName.Text != "" && txtStaffPosition.Text != "" && txtMemberPassword.Text != "")
                {
                    int staffID = 0;

                    #region Get the last StaffID
                    try
                    {
                        //Set the command text to query DB with
                        command.CommandText = "SELECT * FROM Staff";

                        dataSet = new DataSet();

                        connection.Open();
                        command.Connection = connection;

                        adapter = new OleDbDataAdapter(command);
                        adapter.Fill(dataSet, "Staff");

                        //Start our check for CardNumber
                        rowCollection = dataSet.Tables["Staff"].Rows;
                        table = dataSet.Tables["Staff"];

                        int count = table.Rows.Count;
                        if (count >= 1)
                        {
                            //Loop through data to get last CardNumber
                            foreach (DataRow dataRow in rowCollection)
                            {
                                staffID = (int)dataRow[0];
                            }

                            staffID++;

                            connection.Close();
                        }
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

                    string username = null;

                    #region Set Username
                    try
                    {
                        bool end = false;
                        int i = 1;

                        //Loop until we get end = true
                        while (end == false)
                        {
                            //Set the username
                            username = txtStaffFirstName.Text.Substring(0, 1) + txtStaffLastName.Text.Substring(0, 3) + i;

                            //Set the command text to query DB with
                            command.CommandText = String.Format("SELECT [Username] FROM Staff WHERE [Username] = '{0}'", username);

                            dataSet = new DataSet();

                            connection.Open();
                            command.Connection = connection;

                            adapter = new OleDbDataAdapter(command);
                            adapter.Fill(dataSet, "Members");

                            //Start our check if username already exists
                            rowCollection = dataSet.Tables["Members"].Rows;
                            table = dataSet.Tables["Members"];

                            int count = table.Rows.Count;
                            if (count >= 1)
                            {
                                end = false;
                                i++;
                            }
                            else
                            {
                                end = true;
                            }
                        }
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

                    #region Set Staff Password
                    string salt = Encrypt.createSalt();
                    string hashedPassword = Encrypt.generateSHA256Hash(txtStaffPassword.Text, salt);
                    #endregion

                    #region Insert the Staff
                    try
                    {
                        //Set the command text to query DB with
                        command.CommandText = "INSERT INTO Staff ([StaffID], [FirstName], [LastName], [Username], [Position], [Salt], [Password]) VALUES (@taffID, @firstName, @lastName, @username, @position, @salt, @password)";
                        command.Parameters.AddWithValue("@staffID", staffID);
                        command.Parameters.AddWithValue("@firstName", txtStaffFirstName.Text);
                        command.Parameters.AddWithValue("@lastName", txtStaffLastName.Text);
                        command.Parameters.AddWithValue("@position", txtStaffPosition.Text);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@salt", salt);
                        command.Parameters.AddWithValue("@password", hashedPassword);

                        connection.Open();
                        command.Connection = connection;
                        command.ExecuteNonQuery();

                        txtStaffFirstName.Text = "";
                        txtStaffLastName.Text = "";
                        txtStaffPosition.Text = "";
                        txtStaffPassword.Text = "";

                        MessageBox.Show(String.Format("Staff {0} added!", username));

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
                else
                {
                    MessageBox.Show("All member fields are require to add a member!");
                }
            }
            else
            {
                MessageBox.Show("You need to be a head librarian to edit this field!");
            }
        }

        private void btnChangePosition_Click(object sender, EventArgs e)
        {
            if (Staff.Position == "Head Librarian")
            { 
                if (txtPositionUsername.Text != "" && txtPositionPosition.Text != "")
                {
                    #region Edit Position
                    try
                    {
                        //Set the command text to query DB with
                        command.CommandText = "UPDATE Staff SET [Position] = @position WHERE [Username] = @username";
                        command.Parameters.AddWithValue("@position", txtPositionPosition.Text);
                        command.Parameters.AddWithValue("@username", txtPositionUsername.Text);

                        connection.Open();
                        command.Connection = connection;
                        command.ExecuteNonQuery();

                        txtPositionUsername.Text = "";
                        txtPositionPosition.Text = "";

                        MessageBox.Show(String.Format("Staff {0} position wasChanged!", txtPositionUsername.Text));

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
                else
                {
                    MessageBox.Show("All position fields are require to change staff position!");
                }
            }
            else
            {
                MessageBox.Show("You need to be a head librarian to edit this field!");
            }
        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            if (Staff.Position == "Head Librarian")
            { 
                if (txtEditISBN.Text != "")
                {
                    string msg = "";

                    if(txtEditTitle.Text != "")
                    {
                        #region Ubdate Book Title
                        try
                        {
                            //Set the command text to query DB with
                            command.CommandText = "UPDATE Media SET [Title] = @title WHERE [ISBN] = @iSBN";
                            command.Parameters.AddWithValue("@title", txtEditTitle.Text);
                            command.Parameters.AddWithValue("@iSBN", Convert.ToInt32(txtEditISBN.Text));

                            connection.Open();
                            command.Connection = connection;
                            command.ExecuteNonQuery();

                            txtEditTitle.Text = "";

                            msg += "Title updated! \n";

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

                    if (txtEditAuthor.Text != "")
                    {
                        #region Ubdate Book Author
                        try
                        {
                            //Set the command text to query DB with
                            command.CommandText = "UPDATE Media SET [Author] = @author WHERE [ISBN] = @iSBN";
                            command.Parameters.AddWithValue("@author", txtEditAuthor.Text);
                            command.Parameters.AddWithValue("@iSBN", Convert.ToInt32(txtEditISBN.Text));

                            connection.Open();
                            command.Connection = connection;
                            command.ExecuteNonQuery();

                            txtEditAuthor.Text = "";

                            msg += "Author updated! \n";

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

                    if (txtEditSubject.Text != "")
                    {
                        #region Ubdate Book Subject
                        try
                        {
                            //Set the command text to query DB with
                            command.CommandText = "UPDATE Media SET [Subject] = @subject WHERE [ISBN] = @iSBN";
                            command.Parameters.AddWithValue("@subject", txtEditSubject.Text);
                            command.Parameters.AddWithValue("@iSBN", Convert.ToInt32(txtEditISBN.Text));

                            connection.Open();
                            command.Connection = connection;
                            command.ExecuteNonQuery();

                            txtEditSubject.Text = "";

                            msg += "Subject updated! \n";

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

                    if (txtEditSection.Text != "")
                    {
                        #region Ubdate Book Title
                        try
                        {
                            //Set the command text to query DB with
                            command.CommandText = "UPDATE Media SET [Section] = @section WHERE [ISBN] = @iSBN";
                            command.Parameters.AddWithValue("@section", txtEditSection.Text);
                            command.Parameters.AddWithValue("@iSBN", Convert.ToInt32(txtEditISBN.Text));

                            connection.Open();
                            command.Connection = connection;
                            command.ExecuteNonQuery();

                            txtEditSection.Text = "";

                            msg += "Section updated! \n";

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

                    if (chkEditFiction.Checked)
                    {
                        #region Ubdate Book Fiction
                        try
                        {
                            //Set the command text to query DB with
                            command.CommandText = "UPDATE Media SET [Fiction] = @fiction WHERE [ISBN] = @iSBN";
                            command.Parameters.AddWithValue("@fiction", chkEditFiction.Checked);
                            command.Parameters.AddWithValue("@iSBN", Convert.ToInt32(txtEditISBN.Text));

                            connection.Open();
                            command.Connection = connection;
                            command.ExecuteNonQuery();

                            chkEditFiction.Checked = false;

                            msg += "Fiction updated! \n";

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

                    if (txtEditMediaType.Text != "")
                    {
                        #region Ubdate Book Media Type
                        try
                        {
                            //Set the command text to query DB with
                            command.CommandText = "UPDATE Media SET [MediaType] = @mediaType WHERE [ISBN] = @iSBN";
                            command.Parameters.AddWithValue("@mediaType", txtEditMediaType.Text);
                            command.Parameters.AddWithValue("@iSBN", Convert.ToInt32(txtEditISBN.Text));

                            connection.Open();
                            command.Connection = connection;
                            command.ExecuteNonQuery();

                            txtEditMediaType.Text = "";

                            msg += "Media Type updated! \n";

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

                    txtEditISBN.Text = "";
                    MessageBox.Show(String.Format(msg));
                }
                else
                {
                    MessageBox.Show("Book ISBN is required to edit book!");
                }
            }
            else
            {
                MessageBox.Show("You need to be a head librarian to edit this field!");
            }
        }

        private void btnRemoveBook_Click(object sender, EventArgs e)
        {
            if (Staff.Position == "Head Librarian")
            { 
                if (txtRemoveISBN.Text != "")
                {
                    #region Delete Book 
                    try
                    {
                        //Set the command text to query DB with
                        command.CommandText = "DELETE FROM Media WHERE [ISBN] = @iSBN";
                        command.Parameters.AddWithValue("@iSBN", Convert.ToInt32(txtEditISBN.Text));

                        connection.Open();
                        command.Connection = connection;
                        command.ExecuteNonQuery();

                        txtRemoveISBN.Text = "";

                        connection.Close();

                        MessageBox.Show(String.Format("Book with {0} ISBN deleted!", txtRemoveISBN.Text));
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
            }
            else
            {
                MessageBox.Show("You need to be a head librarian to edit this field!");
            }
        }

        private void btnViewBooks_Click(object sender, EventArgs e)
        {
            if (Staff.Position != null || Staff.Position != "")
            {
                LufkinBooks.ViewBooks = "Staff";

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
                MessageBox.Show("You need to be a staff to view all books!");
            }
        }

        private void bntViewRequests_Click(object sender, EventArgs e)
        {
            if (Staff.Position != null || Staff.Position != "")
            {
                LufkinRequests.ViewRequests = "Staff";

                #region Load Book Form
                //Make second form
                LufkinRequests lufkinRequests = new LufkinRequests();

                //Set second form's start position as same as parent form
                lufkinRequests.StartPosition = FormStartPosition.Manual;
                lufkinRequests.Location = new Point(this.Location.X, this.Location.Y);

                //Open second dialog
                lufkinRequests.ShowDialog();

                //Set parent form's visible to true
                this.Visible = true;
                #endregion
            }
            else
            {
                MessageBox.Show("You need to be a staff to view all requests!");
            }
        }

        private void LufkinStaff_OnFormClosed(object sender, EventArgs e)
        {
            #region Set Staff Objects To Empty
            Staff.ID = Convert.ToInt32(null);
            Staff.FirstName = "";
            Staff.LastName = "";
            Staff.Username = "";
            Staff.Position = "";
            #endregion
        }
    }
}
