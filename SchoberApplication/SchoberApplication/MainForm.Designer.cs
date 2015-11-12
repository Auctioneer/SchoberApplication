namespace SchoberApplication
{
    partial class MainForm
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
            this.employeeButton = new System.Windows.Forms.Button();
            this.productButton = new System.Windows.Forms.Button();
            this.storeButton = new System.Windows.Forms.Button();
            this.supplierButton = new System.Windows.Forms.Button();
            this.graphsButton = new System.Windows.Forms.Button();
            this.editTableButton = new System.Windows.Forms.Button();
            this.buttonBox = new System.Windows.Forms.GroupBox();
            this.logoutButton = new System.Windows.Forms.Button();
            this.buttonBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // employeeButton
            // 
            this.employeeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.employeeButton.Location = new System.Drawing.Point(13, 24);
            this.employeeButton.Name = "employeeButton";
            this.employeeButton.Size = new System.Drawing.Size(112, 32);
            this.employeeButton.TabIndex = 1;
            this.employeeButton.Text = "Employee";
            this.employeeButton.UseVisualStyleBackColor = true;
            this.employeeButton.Click += new System.EventHandler(this.employeeButton_Click);
            // 
            // productButton
            // 
            this.productButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.productButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.productButton.Location = new System.Drawing.Point(13, 76);
            this.productButton.Name = "productButton";
            this.productButton.Size = new System.Drawing.Size(112, 32);
            this.productButton.TabIndex = 2;
            this.productButton.Text = "Product";
            this.productButton.UseVisualStyleBackColor = true;
            this.productButton.Click += new System.EventHandler(this.productButton_Click);
            // 
            // storeButton
            // 
            this.storeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.storeButton.Location = new System.Drawing.Point(13, 126);
            this.storeButton.Name = "storeButton";
            this.storeButton.Size = new System.Drawing.Size(112, 32);
            this.storeButton.TabIndex = 3;
            this.storeButton.Text = "Store";
            this.storeButton.UseVisualStyleBackColor = true;
            this.storeButton.Click += new System.EventHandler(this.storeButton_Click);
            // 
            // supplierButton
            // 
            this.supplierButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.supplierButton.Location = new System.Drawing.Point(13, 180);
            this.supplierButton.Name = "supplierButton";
            this.supplierButton.Size = new System.Drawing.Size(112, 32);
            this.supplierButton.TabIndex = 4;
            this.supplierButton.Text = "Supplier";
            this.supplierButton.UseVisualStyleBackColor = true;
            this.supplierButton.Click += new System.EventHandler(this.supplierButton_Click);
            // 
            // graphsButton
            // 
            this.graphsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.graphsButton.Location = new System.Drawing.Point(13, 239);
            this.graphsButton.Name = "graphsButton";
            this.graphsButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.graphsButton.Size = new System.Drawing.Size(112, 32);
            this.graphsButton.TabIndex = 5;
            this.graphsButton.Text = "Graphs";
            this.graphsButton.UseVisualStyleBackColor = true;
            this.graphsButton.Click += new System.EventHandler(this.graphsButton_Click);
            // 
            // editTableButton
            // 
            this.editTableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editTableButton.Location = new System.Drawing.Point(13, 381);
            this.editTableButton.Name = "editTableButton";
            this.editTableButton.Size = new System.Drawing.Size(112, 32);
            this.editTableButton.TabIndex = 6;
            this.editTableButton.Text = "Edit Table";
            this.editTableButton.UseVisualStyleBackColor = true;
            this.editTableButton.Click += new System.EventHandler(this.editTableButton_Click);
            // 
            // buttonBox
            // 
            this.buttonBox.Controls.Add(this.logoutButton);
            this.buttonBox.Controls.Add(this.editTableButton);
            this.buttonBox.Controls.Add(this.employeeButton);
            this.buttonBox.Controls.Add(this.graphsButton);
            this.buttonBox.Controls.Add(this.productButton);
            this.buttonBox.Controls.Add(this.supplierButton);
            this.buttonBox.Controls.Add(this.storeButton);
            this.buttonBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonBox.Location = new System.Drawing.Point(0, 0);
            this.buttonBox.Name = "buttonBox";
            this.buttonBox.Size = new System.Drawing.Size(150, 561);
            this.buttonBox.TabIndex = 7;
            this.buttonBox.TabStop = false;
           
            // 
            // logoutButton
            // 
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.Location = new System.Drawing.Point(13, 494);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(112, 32);
            this.logoutButton.TabIndex = 7;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
           
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.buttonBox);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.buttonBox.ResumeLayout(false);
            this.buttonBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button employeeButton;
        private System.Windows.Forms.Button productButton;
        private System.Windows.Forms.Button storeButton;
        private System.Windows.Forms.Button supplierButton;
        private System.Windows.Forms.Button graphsButton;
        private System.Windows.Forms.Button editTableButton;
        private System.Windows.Forms.GroupBox buttonBox;
        private System.Windows.Forms.Button logoutButton;
    }
}

