namespace LufkinLib
{
    partial class LufkinMember
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.boxEditInfo = new System.Windows.Forms.GroupBox();
            this.txtEditPassword = new System.Windows.Forms.TextBox();
            this.lblEditPassword = new System.Windows.Forms.Label();
            this.btnEditInfo = new System.Windows.Forms.Button();
            this.txtEditLastName = new System.Windows.Forms.TextBox();
            this.txtEditFirstName = new System.Windows.Forms.TextBox();
            this.lblEditLastName = new System.Windows.Forms.Label();
            this.lblEditFirstName = new System.Windows.Forms.Label();
            this.boxRequestBook = new System.Windows.Forms.GroupBox();
            this.btnRequestBook = new System.Windows.Forms.Button();
            this.txtRequestISBN = new System.Windows.Forms.TextBox();
            this.lblRequestISBN = new System.Windows.Forms.Label();
            this.boxBooksCheckedOut = new System.Windows.Forms.GroupBox();
            this.dgvBooksOut = new System.Windows.Forms.DataGridView();
            this.btnViewBooks = new System.Windows.Forms.Button();
            this.boxEditInfo.SuspendLayout();
            this.boxRequestBook.SuspendLayout();
            this.boxBooksCheckedOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooksOut)).BeginInit();
            this.SuspendLayout();
            // 
            // boxEditInfo
            // 
            this.boxEditInfo.Controls.Add(this.txtEditPassword);
            this.boxEditInfo.Controls.Add(this.lblEditPassword);
            this.boxEditInfo.Controls.Add(this.btnEditInfo);
            this.boxEditInfo.Controls.Add(this.txtEditLastName);
            this.boxEditInfo.Controls.Add(this.txtEditFirstName);
            this.boxEditInfo.Controls.Add(this.lblEditLastName);
            this.boxEditInfo.Controls.Add(this.lblEditFirstName);
            this.boxEditInfo.Location = new System.Drawing.Point(12, 12);
            this.boxEditInfo.Name = "boxEditInfo";
            this.boxEditInfo.Size = new System.Drawing.Size(315, 235);
            this.boxEditInfo.TabIndex = 16;
            this.boxEditInfo.TabStop = false;
            this.boxEditInfo.Text = "Edit Info";
            // 
            // txtEditPassword
            // 
            this.txtEditPassword.Location = new System.Drawing.Point(103, 66);
            this.txtEditPassword.Name = "txtEditPassword";
            this.txtEditPassword.PasswordChar = '*';
            this.txtEditPassword.Size = new System.Drawing.Size(206, 20);
            this.txtEditPassword.TabIndex = 14;
            // 
            // lblEditPassword
            // 
            this.lblEditPassword.AutoSize = true;
            this.lblEditPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditPassword.Location = new System.Drawing.Point(6, 66);
            this.lblEditPassword.Name = "lblEditPassword";
            this.lblEditPassword.Size = new System.Drawing.Size(82, 20);
            this.lblEditPassword.TabIndex = 13;
            this.lblEditPassword.Text = "Password:";
            // 
            // btnEditInfo
            // 
            this.btnEditInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditInfo.Location = new System.Drawing.Point(228, 197);
            this.btnEditInfo.Name = "btnEditInfo";
            this.btnEditInfo.Size = new System.Drawing.Size(81, 29);
            this.btnEditInfo.TabIndex = 12;
            this.btnEditInfo.Text = "Edit Info";
            this.btnEditInfo.UseVisualStyleBackColor = true;
            this.btnEditInfo.Click += new System.EventHandler(this.btnEditInfo_Click);
            // 
            // txtEditLastName
            // 
            this.txtEditLastName.Location = new System.Drawing.Point(103, 40);
            this.txtEditLastName.Name = "txtEditLastName";
            this.txtEditLastName.Size = new System.Drawing.Size(206, 20);
            this.txtEditLastName.TabIndex = 7;
            // 
            // txtEditFirstName
            // 
            this.txtEditFirstName.Location = new System.Drawing.Point(103, 15);
            this.txtEditFirstName.Name = "txtEditFirstName";
            this.txtEditFirstName.Size = new System.Drawing.Size(206, 20);
            this.txtEditFirstName.TabIndex = 6;
            // 
            // lblEditLastName
            // 
            this.lblEditLastName.AutoSize = true;
            this.lblEditLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditLastName.Location = new System.Drawing.Point(6, 41);
            this.lblEditLastName.Name = "lblEditLastName";
            this.lblEditLastName.Size = new System.Drawing.Size(90, 20);
            this.lblEditLastName.TabIndex = 1;
            this.lblEditLastName.Text = "Last Name:";
            // 
            // lblEditFirstName
            // 
            this.lblEditFirstName.AutoSize = true;
            this.lblEditFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditFirstName.Location = new System.Drawing.Point(6, 16);
            this.lblEditFirstName.Name = "lblEditFirstName";
            this.lblEditFirstName.Size = new System.Drawing.Size(90, 20);
            this.lblEditFirstName.TabIndex = 0;
            this.lblEditFirstName.Text = "First Name:";
            // 
            // boxRequestBook
            // 
            this.boxRequestBook.Controls.Add(this.btnRequestBook);
            this.boxRequestBook.Controls.Add(this.txtRequestISBN);
            this.boxRequestBook.Controls.Add(this.lblRequestISBN);
            this.boxRequestBook.Location = new System.Drawing.Point(333, 12);
            this.boxRequestBook.Name = "boxRequestBook";
            this.boxRequestBook.Size = new System.Drawing.Size(315, 235);
            this.boxRequestBook.TabIndex = 32;
            this.boxRequestBook.TabStop = false;
            this.boxRequestBook.Text = "Request Book";
            // 
            // btnRequestBook
            // 
            this.btnRequestBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequestBook.Location = new System.Drawing.Point(188, 197);
            this.btnRequestBook.Name = "btnRequestBook";
            this.btnRequestBook.Size = new System.Drawing.Size(121, 29);
            this.btnRequestBook.TabIndex = 19;
            this.btnRequestBook.Text = "Request Book";
            this.btnRequestBook.UseVisualStyleBackColor = true;
            this.btnRequestBook.Click += new System.EventHandler(this.btnRequestBook_Click);
            // 
            // txtRequestISBN
            // 
            this.txtRequestISBN.Location = new System.Drawing.Point(103, 15);
            this.txtRequestISBN.Name = "txtRequestISBN";
            this.txtRequestISBN.Size = new System.Drawing.Size(206, 20);
            this.txtRequestISBN.TabIndex = 21;
            // 
            // lblRequestISBN
            // 
            this.lblRequestISBN.AutoSize = true;
            this.lblRequestISBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestISBN.Location = new System.Drawing.Point(6, 16);
            this.lblRequestISBN.Name = "lblRequestISBN";
            this.lblRequestISBN.Size = new System.Drawing.Size(51, 20);
            this.lblRequestISBN.TabIndex = 15;
            this.lblRequestISBN.Text = "ISBN:";
            // 
            // boxBooksCheckedOut
            // 
            this.boxBooksCheckedOut.Controls.Add(this.dgvBooksOut);
            this.boxBooksCheckedOut.Location = new System.Drawing.Point(654, 12);
            this.boxBooksCheckedOut.Name = "boxBooksCheckedOut";
            this.boxBooksCheckedOut.Size = new System.Drawing.Size(315, 235);
            this.boxBooksCheckedOut.TabIndex = 33;
            this.boxBooksCheckedOut.TabStop = false;
            // 
            // dgvBooksOut
            // 
            this.dgvBooksOut.AllowUserToAddRows = false;
            this.dgvBooksOut.AllowUserToDeleteRows = false;
            this.dgvBooksOut.AllowUserToOrderColumns = true;
            this.dgvBooksOut.AllowUserToResizeColumns = false;
            this.dgvBooksOut.AllowUserToResizeRows = false;
            this.dgvBooksOut.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBooksOut.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBooksOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooksOut.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBooksOut.Location = new System.Drawing.Point(6, 19);
            this.dgvBooksOut.Name = "dgvBooksOut";
            this.dgvBooksOut.Size = new System.Drawing.Size(303, 207);
            this.dgvBooksOut.TabIndex = 0;
            // 
            // btnViewBooks
            // 
            this.btnViewBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewBooks.Location = new System.Drawing.Point(12, 253);
            this.btnViewBooks.Name = "btnViewBooks";
            this.btnViewBooks.Size = new System.Drawing.Size(958, 37);
            this.btnViewBooks.TabIndex = 34;
            this.btnViewBooks.Text = "View All Books";
            this.btnViewBooks.UseVisualStyleBackColor = true;
            this.btnViewBooks.Click += new System.EventHandler(this.btnViewBooks_Click);
            // 
            // LufkinMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 302);
            this.Controls.Add(this.btnViewBooks);
            this.Controls.Add(this.boxBooksCheckedOut);
            this.Controls.Add(this.boxRequestBook);
            this.Controls.Add(this.boxEditInfo);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(998, 341);
            this.MinimumSize = new System.Drawing.Size(998, 341);
            this.Name = "LufkinMember";
            this.Text = "Lufkin Member";
            this.Load += new System.EventHandler(this.LufkinMember_Load);
            this.boxEditInfo.ResumeLayout(false);
            this.boxEditInfo.PerformLayout();
            this.boxRequestBook.ResumeLayout(false);
            this.boxRequestBook.PerformLayout();
            this.boxBooksCheckedOut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooksOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxEditInfo;
        private System.Windows.Forms.TextBox txtEditPassword;
        private System.Windows.Forms.Label lblEditPassword;
        private System.Windows.Forms.Button btnEditInfo;
        private System.Windows.Forms.TextBox txtEditLastName;
        private System.Windows.Forms.TextBox txtEditFirstName;
        private System.Windows.Forms.Label lblEditLastName;
        private System.Windows.Forms.Label lblEditFirstName;
        private System.Windows.Forms.GroupBox boxRequestBook;
        private System.Windows.Forms.Button btnRequestBook;
        private System.Windows.Forms.TextBox txtRequestISBN;
        private System.Windows.Forms.Label lblRequestISBN;
        private System.Windows.Forms.GroupBox boxBooksCheckedOut;
        private System.Windows.Forms.DataGridView dgvBooksOut;
        private System.Windows.Forms.Button btnViewBooks;
    }
}