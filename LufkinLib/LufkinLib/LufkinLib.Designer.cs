namespace LufkinLib
{
    partial class LufkinLib
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
            this.boxMemberLogin = new System.Windows.Forms.GroupBox();
            this.btnMemberLogin = new System.Windows.Forms.Button();
            this.txtMemberPassword = new System.Windows.Forms.TextBox();
            this.txtMemberUsername = new System.Windows.Forms.TextBox();
            this.lblMemberPassword = new System.Windows.Forms.Label();
            this.lblMemberUsername = new System.Windows.Forms.Label();
            this.boxStaffLogin = new System.Windows.Forms.GroupBox();
            this.btnStaffLogin = new System.Windows.Forms.Button();
            this.txtStaffPassword = new System.Windows.Forms.TextBox();
            this.txtStaffUsername = new System.Windows.Forms.TextBox();
            this.lblStaffPassword = new System.Windows.Forms.Label();
            this.lblStaffUsername = new System.Windows.Forms.Label();
            this.btnViewBooks = new System.Windows.Forms.Button();
            this.boxMemberLogin.SuspendLayout();
            this.boxStaffLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxMemberLogin
            // 
            this.boxMemberLogin.Controls.Add(this.btnMemberLogin);
            this.boxMemberLogin.Controls.Add(this.txtMemberPassword);
            this.boxMemberLogin.Controls.Add(this.txtMemberUsername);
            this.boxMemberLogin.Controls.Add(this.lblMemberPassword);
            this.boxMemberLogin.Controls.Add(this.lblMemberUsername);
            this.boxMemberLogin.Location = new System.Drawing.Point(332, 18);
            this.boxMemberLogin.Name = "boxMemberLogin";
            this.boxMemberLogin.Size = new System.Drawing.Size(315, 175);
            this.boxMemberLogin.TabIndex = 3;
            this.boxMemberLogin.TabStop = false;
            this.boxMemberLogin.Text = "Member Login";
            // 
            // btnMemberLogin
            // 
            this.btnMemberLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberLogin.Location = new System.Drawing.Point(221, 139);
            this.btnMemberLogin.Name = "btnMemberLogin";
            this.btnMemberLogin.Size = new System.Drawing.Size(75, 29);
            this.btnMemberLogin.TabIndex = 5;
            this.btnMemberLogin.Text = "Login";
            this.btnMemberLogin.UseVisualStyleBackColor = true;
            this.btnMemberLogin.Click += new System.EventHandler(this.btnMemberLogin_Click);
            // 
            // txtMemberPassword
            // 
            this.txtMemberPassword.AcceptsReturn = true;
            this.txtMemberPassword.Location = new System.Drawing.Point(96, 84);
            this.txtMemberPassword.Name = "txtMemberPassword";
            this.txtMemberPassword.PasswordChar = '*';
            this.txtMemberPassword.Size = new System.Drawing.Size(200, 20);
            this.txtMemberPassword.TabIndex = 3;
            // 
            // txtMemberUsername
            // 
            this.txtMemberUsername.Location = new System.Drawing.Point(96, 25);
            this.txtMemberUsername.Name = "txtMemberUsername";
            this.txtMemberUsername.Size = new System.Drawing.Size(200, 20);
            this.txtMemberUsername.TabIndex = 2;
            // 
            // lblMemberPassword
            // 
            this.lblMemberPassword.AutoSize = true;
            this.lblMemberPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberPassword.Location = new System.Drawing.Point(6, 84);
            this.lblMemberPassword.Name = "lblMemberPassword";
            this.lblMemberPassword.Size = new System.Drawing.Size(82, 20);
            this.lblMemberPassword.TabIndex = 1;
            this.lblMemberPassword.Text = "Password:";
            // 
            // lblMemberUsername
            // 
            this.lblMemberUsername.AutoSize = true;
            this.lblMemberUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberUsername.Location = new System.Drawing.Point(6, 25);
            this.lblMemberUsername.Name = "lblMemberUsername";
            this.lblMemberUsername.Size = new System.Drawing.Size(87, 20);
            this.lblMemberUsername.TabIndex = 0;
            this.lblMemberUsername.Text = "Username:";
            // 
            // boxStaffLogin
            // 
            this.boxStaffLogin.Controls.Add(this.btnStaffLogin);
            this.boxStaffLogin.Controls.Add(this.txtStaffPassword);
            this.boxStaffLogin.Controls.Add(this.txtStaffUsername);
            this.boxStaffLogin.Controls.Add(this.lblStaffPassword);
            this.boxStaffLogin.Controls.Add(this.lblStaffUsername);
            this.boxStaffLogin.Location = new System.Drawing.Point(11, 18);
            this.boxStaffLogin.Name = "boxStaffLogin";
            this.boxStaffLogin.Size = new System.Drawing.Size(315, 175);
            this.boxStaffLogin.TabIndex = 2;
            this.boxStaffLogin.TabStop = false;
            this.boxStaffLogin.Text = "Staff Login";
            // 
            // btnStaffLogin
            // 
            this.btnStaffLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaffLogin.Location = new System.Drawing.Point(220, 139);
            this.btnStaffLogin.Name = "btnStaffLogin";
            this.btnStaffLogin.Size = new System.Drawing.Size(75, 29);
            this.btnStaffLogin.TabIndex = 4;
            this.btnStaffLogin.Text = "Login";
            this.btnStaffLogin.UseVisualStyleBackColor = true;
            this.btnStaffLogin.Click += new System.EventHandler(this.btnStaffLogin_Click);
            // 
            // txtStaffPassword
            // 
            this.txtStaffPassword.AcceptsReturn = true;
            this.txtStaffPassword.Location = new System.Drawing.Point(95, 84);
            this.txtStaffPassword.Name = "txtStaffPassword";
            this.txtStaffPassword.PasswordChar = '*';
            this.txtStaffPassword.Size = new System.Drawing.Size(200, 20);
            this.txtStaffPassword.TabIndex = 3;
            // 
            // txtStaffUsername
            // 
            this.txtStaffUsername.Location = new System.Drawing.Point(95, 38);
            this.txtStaffUsername.Name = "txtStaffUsername";
            this.txtStaffUsername.Size = new System.Drawing.Size(200, 20);
            this.txtStaffUsername.TabIndex = 2;
            // 
            // lblStaffPassword
            // 
            this.lblStaffPassword.AutoSize = true;
            this.lblStaffPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffPassword.Location = new System.Drawing.Point(6, 84);
            this.lblStaffPassword.Name = "lblStaffPassword";
            this.lblStaffPassword.Size = new System.Drawing.Size(82, 20);
            this.lblStaffPassword.TabIndex = 1;
            this.lblStaffPassword.Text = "Password:";
            // 
            // lblStaffUsername
            // 
            this.lblStaffUsername.AutoSize = true;
            this.lblStaffUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffUsername.Location = new System.Drawing.Point(6, 38);
            this.lblStaffUsername.Name = "lblStaffUsername";
            this.lblStaffUsername.Size = new System.Drawing.Size(87, 20);
            this.lblStaffUsername.TabIndex = 0;
            this.lblStaffUsername.Text = "Username:";
            // 
            // btnViewBooks
            // 
            this.btnViewBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewBooks.Location = new System.Drawing.Point(12, 199);
            this.btnViewBooks.Name = "btnViewBooks";
            this.btnViewBooks.Size = new System.Drawing.Size(635, 37);
            this.btnViewBooks.TabIndex = 7;
            this.btnViewBooks.Text = "View All Books";
            this.btnViewBooks.UseVisualStyleBackColor = true;
            this.btnViewBooks.Click += new System.EventHandler(this.btnViewBooks_Click);
            // 
            // LufkinLib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 246);
            this.Controls.Add(this.btnViewBooks);
            this.Controls.Add(this.boxMemberLogin);
            this.Controls.Add(this.boxStaffLogin);
            this.MaximizeBox = false;
            this.Name = "LufkinLib";
            this.Text = "Lufkin Library";
            this.Load += new System.EventHandler(this.LufkinLib_Load);
            this.boxMemberLogin.ResumeLayout(false);
            this.boxMemberLogin.PerformLayout();
            this.boxStaffLogin.ResumeLayout(false);
            this.boxStaffLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox boxMemberLogin;
        private System.Windows.Forms.Button btnMemberLogin;
        private System.Windows.Forms.TextBox txtMemberPassword;
        private System.Windows.Forms.TextBox txtMemberUsername;
        private System.Windows.Forms.Label lblMemberPassword;
        private System.Windows.Forms.Label lblMemberUsername;
        private System.Windows.Forms.GroupBox boxStaffLogin;
        private System.Windows.Forms.Button btnStaffLogin;
        private System.Windows.Forms.TextBox txtStaffPassword;
        private System.Windows.Forms.TextBox txtStaffUsername;
        private System.Windows.Forms.Label lblStaffPassword;
        private System.Windows.Forms.Label lblStaffUsername;
        private System.Windows.Forms.Button btnViewBooks;
    }
}

