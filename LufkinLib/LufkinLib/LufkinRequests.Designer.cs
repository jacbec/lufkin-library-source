namespace LufkinLib
{
    partial class LufkinRequests
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
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRequests
            // 
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.AllowUserToResizeColumns = false;
            this.dgvRequests.AllowUserToResizeRows = false;
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRequests.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRequests.Location = new System.Drawing.Point(12, 12);
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.Size = new System.Drawing.Size(246, 496);
            this.dgvRequests.TabIndex = 0;
            // 
            // LufkinRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 520);
            this.Controls.Add(this.dgvRequests);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(288, 559);
            this.MinimumSize = new System.Drawing.Size(288, 559);
            this.Name = "LufkinRequests";
            this.Text = "Lufkin Requests";
            this.Load += new System.EventHandler(this.LufkinRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRequests;
    }
}