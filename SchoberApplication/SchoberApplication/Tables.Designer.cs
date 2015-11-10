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
            this.dgvAddress = new System.Windows.Forms.DataGridView();
            this.btnGetTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSelectTable
            // 
            this.comboBoxSelectTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectTable.FormattingEnabled = true;
            this.comboBoxSelectTable.Items.AddRange(new object[] {
            "Select a table...",
            "Addresses",
            "Employees",
            "Stores",
            "Products"});
            this.comboBoxSelectTable.Location = new System.Drawing.Point(227, 33);
            this.comboBoxSelectTable.Name = "comboBoxSelectTable";
            this.comboBoxSelectTable.Size = new System.Drawing.Size(264, 21);
            this.comboBoxSelectTable.TabIndex = 0;
            // 
            // dgvAddress
            // 
            this.dgvAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddress.Location = new System.Drawing.Point(64, 79);
            this.dgvAddress.Name = "dgvAddress";
            this.dgvAddress.Size = new System.Drawing.Size(574, 254);
            this.dgvAddress.TabIndex = 1;
            // 
            // btnGetTable
            // 
            this.btnGetTable.Location = new System.Drawing.Point(498, 33);
            this.btnGetTable.Name = "btnGetTable";
            this.btnGetTable.Size = new System.Drawing.Size(75, 23);
            this.btnGetTable.TabIndex = 2;
            this.btnGetTable.Text = "Load Table";
            this.btnGetTable.UseVisualStyleBackColor = true;
            this.btnGetTable.Click += new System.EventHandler(this.btnGetTable_Click);
            // 
            // Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 475);
            this.Controls.Add(this.btnGetTable);
            this.Controls.Add(this.dgvAddress);
            this.Controls.Add(this.comboBoxSelectTable);
            this.Name = "Tables";
            this.Text = "Tables";
            this.Load += new System.EventHandler(this.Tables_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSelectTable;
        private System.Windows.Forms.DataGridView dgvAddress;
        private System.Windows.Forms.Button btnGetTable;

    }
}