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
            this.label1 = new System.Windows.Forms.Label();
            this.employeeButton = new System.Windows.Forms.Button();
            this.productButton = new System.Windows.Forms.Button();
            this.storeButton = new System.Windows.Forms.Button();
            this.supplierButton = new System.Windows.Forms.Button();
            this.graphsButton = new System.Windows.Forms.Button();
            this.editTableButton = new System.Windows.Forms.Button();
            this.buttonBox = new System.Windows.Forms.GroupBox();
            this.editPrivLabelNo = new System.Windows.Forms.Label();
            this.editPrivLabelYes = new System.Windows.Forms.Label();
            this.graphPrivLabelYes = new System.Windows.Forms.Label();
            this.graphPrivLabelNo = new System.Windows.Forms.Label();
            this.supplierPrivLabelNo = new System.Windows.Forms.Label();
            this.supplierPrivLabelYes = new System.Windows.Forms.Label();
            this.storePrivLabelYes = new System.Windows.Forms.Label();
            this.productPrivLabelYes = new System.Windows.Forms.Label();
            this.storePrivLabelNo = new System.Windows.Forms.Label();
            this.employeePrivLabelYes = new System.Windows.Forms.Label();
            this.productPrivLabelNo = new System.Windows.Forms.Label();
            this.employeePrivLabelNo = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.noLabel = new System.Windows.Forms.Label();
            this.yesLabel = new System.Windows.Forms.Label();
            this.buttonBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(255, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database View";
            // 
            // employeeButton
            // 
            this.employeeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.employeeButton.Location = new System.Drawing.Point(13, 33);
            this.employeeButton.Name = "employeeButton";
            this.employeeButton.Size = new System.Drawing.Size(112, 32);
            this.employeeButton.TabIndex = 1;
            this.employeeButton.Text = "Employee";
            this.employeeButton.UseVisualStyleBackColor = true;
            // 
            // productButton
            // 
            this.productButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.productButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.productButton.Location = new System.Drawing.Point(13, 100);
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
            this.storeButton.Location = new System.Drawing.Point(12, 170);
            this.storeButton.Name = "storeButton";
            this.storeButton.Size = new System.Drawing.Size(112, 32);
            this.storeButton.TabIndex = 3;
            this.storeButton.Text = "Store";
            this.storeButton.UseVisualStyleBackColor = true;
            // 
            // supplierButton
            // 
            this.supplierButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.supplierButton.Location = new System.Drawing.Point(12, 248);
            this.supplierButton.Name = "supplierButton";
            this.supplierButton.Size = new System.Drawing.Size(112, 32);
            this.supplierButton.TabIndex = 4;
            this.supplierButton.Text = "Supplier";
            this.supplierButton.UseVisualStyleBackColor = true;
            // 
            // graphsButton
            // 
            this.graphsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.graphsButton.Location = new System.Drawing.Point(13, 318);
            this.graphsButton.Name = "graphsButton";
            this.graphsButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.graphsButton.Size = new System.Drawing.Size(112, 32);
            this.graphsButton.TabIndex = 5;
            this.graphsButton.Text = "Graphs";
            this.graphsButton.UseVisualStyleBackColor = true;
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
            // 
            // buttonBox
            // 
            this.buttonBox.Controls.Add(this.editPrivLabelNo);
            this.buttonBox.Controls.Add(this.editPrivLabelYes);
            this.buttonBox.Controls.Add(this.graphPrivLabelYes);
            this.buttonBox.Controls.Add(this.graphPrivLabelNo);
            this.buttonBox.Controls.Add(this.supplierPrivLabelNo);
            this.buttonBox.Controls.Add(this.supplierPrivLabelYes);
            this.buttonBox.Controls.Add(this.storePrivLabelYes);
            this.buttonBox.Controls.Add(this.productPrivLabelYes);
            this.buttonBox.Controls.Add(this.storePrivLabelNo);
            this.buttonBox.Controls.Add(this.employeePrivLabelYes);
            this.buttonBox.Controls.Add(this.productPrivLabelNo);
            this.buttonBox.Controls.Add(this.employeePrivLabelNo);
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
            // editPrivLabelNo
            // 
            this.editPrivLabelNo.AutoSize = true;
            this.editPrivLabelNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editPrivLabelNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.editPrivLabelNo.Location = new System.Drawing.Point(129, 391);
            this.editPrivLabelNo.Name = "editPrivLabelNo";
            this.editPrivLabelNo.Size = new System.Drawing.Size(16, 13);
            this.editPrivLabelNo.TabIndex = 21;
            this.editPrivLabelNo.Text = "N";
            this.editPrivLabelNo.Visible = false;
            // 
            // editPrivLabelYes
            // 
            this.editPrivLabelYes.AutoSize = true;
            this.editPrivLabelYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editPrivLabelYes.ForeColor = System.Drawing.Color.Green;
            this.editPrivLabelYes.Location = new System.Drawing.Point(131, 391);
            this.editPrivLabelYes.Name = "editPrivLabelYes";
            this.editPrivLabelYes.Size = new System.Drawing.Size(15, 13);
            this.editPrivLabelYes.TabIndex = 15;
            this.editPrivLabelYes.Text = "Y";
            this.editPrivLabelYes.Visible = false;
            // 
            // graphPrivLabelYes
            // 
            this.graphPrivLabelYes.AutoSize = true;
            this.graphPrivLabelYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphPrivLabelYes.ForeColor = System.Drawing.Color.Green;
            this.graphPrivLabelYes.Location = new System.Drawing.Point(129, 328);
            this.graphPrivLabelYes.Name = "graphPrivLabelYes";
            this.graphPrivLabelYes.Size = new System.Drawing.Size(15, 13);
            this.graphPrivLabelYes.TabIndex = 14;
            this.graphPrivLabelYes.Text = "Y";
            this.graphPrivLabelYes.Visible = false;
            // 
            // graphPrivLabelNo
            // 
            this.graphPrivLabelNo.AutoSize = true;
            this.graphPrivLabelNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphPrivLabelNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.graphPrivLabelNo.Location = new System.Drawing.Point(129, 328);
            this.graphPrivLabelNo.Name = "graphPrivLabelNo";
            this.graphPrivLabelNo.Size = new System.Drawing.Size(16, 13);
            this.graphPrivLabelNo.TabIndex = 20;
            this.graphPrivLabelNo.Text = "N";
            this.graphPrivLabelNo.Visible = false;
            // 
            // supplierPrivLabelNo
            // 
            this.supplierPrivLabelNo.AutoSize = true;
            this.supplierPrivLabelNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierPrivLabelNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.supplierPrivLabelNo.Location = new System.Drawing.Point(128, 258);
            this.supplierPrivLabelNo.Name = "supplierPrivLabelNo";
            this.supplierPrivLabelNo.Size = new System.Drawing.Size(16, 13);
            this.supplierPrivLabelNo.TabIndex = 18;
            this.supplierPrivLabelNo.Text = "N";
            this.supplierPrivLabelNo.Visible = false;
            // 
            // supplierPrivLabelYes
            // 
            this.supplierPrivLabelYes.AutoSize = true;
            this.supplierPrivLabelYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierPrivLabelYes.ForeColor = System.Drawing.Color.Green;
            this.supplierPrivLabelYes.Location = new System.Drawing.Point(129, 258);
            this.supplierPrivLabelYes.Name = "supplierPrivLabelYes";
            this.supplierPrivLabelYes.Size = new System.Drawing.Size(15, 13);
            this.supplierPrivLabelYes.TabIndex = 13;
            this.supplierPrivLabelYes.Text = "Y";
            this.supplierPrivLabelYes.Visible = false;
            // 
            // storePrivLabelYes
            // 
            this.storePrivLabelYes.AutoSize = true;
            this.storePrivLabelYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storePrivLabelYes.ForeColor = System.Drawing.Color.Green;
            this.storePrivLabelYes.Location = new System.Drawing.Point(129, 180);
            this.storePrivLabelYes.Name = "storePrivLabelYes";
            this.storePrivLabelYes.Size = new System.Drawing.Size(15, 13);
            this.storePrivLabelYes.TabIndex = 12;
            this.storePrivLabelYes.Text = "Y";
            this.storePrivLabelYes.Visible = false;
            // 
            // productPrivLabelYes
            // 
            this.productPrivLabelYes.AutoSize = true;
            this.productPrivLabelYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productPrivLabelYes.ForeColor = System.Drawing.Color.Green;
            this.productPrivLabelYes.Location = new System.Drawing.Point(129, 110);
            this.productPrivLabelYes.Name = "productPrivLabelYes";
            this.productPrivLabelYes.Size = new System.Drawing.Size(15, 13);
            this.productPrivLabelYes.TabIndex = 11;
            this.productPrivLabelYes.Text = "Y";
            this.productPrivLabelYes.Visible = false;
            this.productPrivLabelYes.Click += new System.EventHandler(this.productPrivLabelYes_Click);
            // 
            // storePrivLabelNo
            // 
            this.storePrivLabelNo.AutoSize = true;
            this.storePrivLabelNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storePrivLabelNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.storePrivLabelNo.Location = new System.Drawing.Point(130, 180);
            this.storePrivLabelNo.Name = "storePrivLabelNo";
            this.storePrivLabelNo.Size = new System.Drawing.Size(16, 13);
            this.storePrivLabelNo.TabIndex = 19;
            this.storePrivLabelNo.Text = "N";
            this.storePrivLabelNo.Visible = false;
            // 
            // employeePrivLabelYes
            // 
            this.employeePrivLabelYes.AutoSize = true;
            this.employeePrivLabelYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeePrivLabelYes.ForeColor = System.Drawing.Color.Green;
            this.employeePrivLabelYes.Location = new System.Drawing.Point(131, 43);
            this.employeePrivLabelYes.Name = "employeePrivLabelYes";
            this.employeePrivLabelYes.Size = new System.Drawing.Size(15, 13);
            this.employeePrivLabelYes.TabIndex = 10;
            this.employeePrivLabelYes.Text = "Y";
            this.employeePrivLabelYes.Visible = false;
            // 
            // productPrivLabelNo
            // 
            this.productPrivLabelNo.AutoSize = true;
            this.productPrivLabelNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productPrivLabelNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.productPrivLabelNo.Location = new System.Drawing.Point(129, 110);
            this.productPrivLabelNo.Name = "productPrivLabelNo";
            this.productPrivLabelNo.Size = new System.Drawing.Size(16, 13);
            this.productPrivLabelNo.TabIndex = 17;
            this.productPrivLabelNo.Text = "N";
            this.productPrivLabelNo.Visible = false;
            // 
            // employeePrivLabelNo
            // 
            this.employeePrivLabelNo.AutoSize = true;
            this.employeePrivLabelNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeePrivLabelNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.employeePrivLabelNo.Location = new System.Drawing.Point(130, 43);
            this.employeePrivLabelNo.Name = "employeePrivLabelNo";
            this.employeePrivLabelNo.Size = new System.Drawing.Size(16, 13);
            this.employeePrivLabelNo.TabIndex = 16;
            this.employeePrivLabelNo.Text = "N";
            this.employeePrivLabelNo.Visible = false;
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
            // noLabel
            // 
            this.noLabel.AutoSize = true;
            this.noLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.noLabel.Location = new System.Drawing.Point(181, 0);
            this.noLabel.Name = "noLabel";
            this.noLabel.Size = new System.Drawing.Size(16, 13);
            this.noLabel.TabIndex = 9;
            this.noLabel.Text = "N";
            this.noLabel.Visible = false;
            // 
            // yesLabel
            // 
            this.yesLabel.AutoSize = true;
            this.yesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesLabel.ForeColor = System.Drawing.Color.Green;
            this.yesLabel.Location = new System.Drawing.Point(169, 0);
            this.yesLabel.Name = "yesLabel";
            this.yesLabel.Size = new System.Drawing.Size(15, 13);
            this.yesLabel.TabIndex = 8;
            this.yesLabel.Text = "Y";
            this.yesLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBox);
            this.Controls.Add(this.yesLabel);
            this.Controls.Add(this.noLabel);
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button employeeButton;
        private System.Windows.Forms.Button productButton;
        private System.Windows.Forms.Button storeButton;
        private System.Windows.Forms.Button supplierButton;
        private System.Windows.Forms.Button graphsButton;
        private System.Windows.Forms.Button editTableButton;
        private System.Windows.Forms.GroupBox buttonBox;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label noLabel;
        private System.Windows.Forms.Label yesLabel;
        private System.Windows.Forms.Label editPrivLabelNo;
        private System.Windows.Forms.Label editPrivLabelYes;
        private System.Windows.Forms.Label graphPrivLabelYes;
        private System.Windows.Forms.Label graphPrivLabelNo;
        private System.Windows.Forms.Label supplierPrivLabelNo;
        private System.Windows.Forms.Label supplierPrivLabelYes;
        private System.Windows.Forms.Label storePrivLabelYes;
        private System.Windows.Forms.Label productPrivLabelYes;
        private System.Windows.Forms.Label storePrivLabelNo;
        private System.Windows.Forms.Label employeePrivLabelYes;
        private System.Windows.Forms.Label productPrivLabelNo;
        private System.Windows.Forms.Label employeePrivLabelNo;
    }
}

