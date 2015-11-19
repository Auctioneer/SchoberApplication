namespace SchoberApplication
{
    partial class Tables
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
            this.comboBoxSelectTable = new System.Windows.Forms.ComboBox();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.btnGetTable = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSelectTable
            // 
            this.comboBoxSelectTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectTable.FormattingEnabled = true;
            this.comboBoxSelectTable.Items.AddRange(new object[] {
            "Select a table...",
            "Addresses",
            "Products",
            "Employees",
            "Stores",
            "Jobs",
            "Sales"});
            this.comboBoxSelectTable.Location = new System.Drawing.Point(152, 33);
            this.comboBoxSelectTable.Name = "comboBoxSelectTable";
            this.comboBoxSelectTable.Size = new System.Drawing.Size(264, 21);
            this.comboBoxSelectTable.TabIndex = 0;
            // 
            // dgvTable
            // 
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Location = new System.Drawing.Point(25, 79);
            this.dgvTable.MultiSelect = false;
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.Size = new System.Drawing.Size(597, 254);
            this.dgvTable.TabIndex = 1;
            // 
            // btnGetTable
            // 
            this.btnGetTable.Location = new System.Drawing.Point(423, 33);
            this.btnGetTable.Name = "btnGetTable";
            this.btnGetTable.Size = new System.Drawing.Size(75, 23);
            this.btnGetTable.TabIndex = 2;
            this.btnGetTable.Text = "Load Table";
            this.btnGetTable.UseVisualStyleBackColor = true;
            this.btnGetTable.Click += new System.EventHandler(this.btnGetTable_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(216, 350);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(164, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update Table";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(423, 350);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete Selected Row";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 475);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnGetTable);
            this.Controls.Add(this.dgvTable);
            this.Controls.Add(this.comboBoxSelectTable);
            this.Name = "Tables";
            this.Text = "Tables";
            this.Load += new System.EventHandler(this.Tables_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSelectTable;
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.Button btnGetTable;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;

    }
}