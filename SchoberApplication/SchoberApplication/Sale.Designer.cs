namespace SchoberApplication
{
    partial class Sale
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
            this.itemsold = new System.Windows.Forms.Label();
            this.quantitysold = new System.Windows.Forms.Label();
            this.soldinstore = new System.Windows.Forms.Label();
            this.itemsolddrop = new System.Windows.Forms.ComboBox();
            this.saleinstoredrop = new System.Windows.Forms.ComboBox();
            this.soldquantitytxt = new System.Windows.Forms.TextBox();
            this.salesubmit = new System.Windows.Forms.Button();
            this.saleTitle = new System.Windows.Forms.Label();
            this.salemsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // itemsold
            // 
            this.itemsold.AutoSize = true;
            this.itemsold.Location = new System.Drawing.Point(66, 87);
            this.itemsold.Name = "itemsold";
            this.itemsold.Size = new System.Drawing.Size(49, 13);
            this.itemsold.TabIndex = 0;
            this.itemsold.Text = "Item sold";
            // 
            // quantitysold
            // 
            this.quantitysold.AutoSize = true;
            this.quantitysold.Location = new System.Drawing.Point(47, 114);
            this.quantitysold.Name = "quantitysold";
            this.quantitysold.Size = new System.Drawing.Size(68, 13);
            this.quantitysold.TabIndex = 1;
            this.quantitysold.Text = "Quantity sold";
            // 
            // soldinstore
            // 
            this.soldinstore.AutoSize = true;
            this.soldinstore.Location = new System.Drawing.Point(73, 140);
            this.soldinstore.Name = "soldinstore";
            this.soldinstore.Size = new System.Drawing.Size(42, 13);
            this.soldinstore.TabIndex = 2;
            this.soldinstore.Text = "In store";
            // 
            // itemsolddrop
            // 
            this.itemsolddrop.FormattingEnabled = true;
            this.itemsolddrop.Location = new System.Drawing.Point(121, 87);
            this.itemsolddrop.Name = "itemsolddrop";
            this.itemsolddrop.Size = new System.Drawing.Size(121, 21);
            this.itemsolddrop.TabIndex = 3;
            // 
            // saleinstoredrop
            // 
            this.saleinstoredrop.FormattingEnabled = true;
            this.saleinstoredrop.Location = new System.Drawing.Point(121, 140);
            this.saleinstoredrop.Name = "saleinstoredrop";
            this.saleinstoredrop.Size = new System.Drawing.Size(121, 21);
            this.saleinstoredrop.TabIndex = 4;
            // 
            // soldquantitytxt
            // 
            this.soldquantitytxt.Location = new System.Drawing.Point(121, 114);
            this.soldquantitytxt.Name = "soldquantitytxt";
            this.soldquantitytxt.Size = new System.Drawing.Size(100, 20);
            this.soldquantitytxt.TabIndex = 5;
            // 
            // salesubmit
            // 
            this.salesubmit.Location = new System.Drawing.Point(423, 140);
            this.salesubmit.Name = "salesubmit";
            this.salesubmit.Size = new System.Drawing.Size(75, 23);
            this.salesubmit.TabIndex = 6;
            this.salesubmit.Text = "Submit";
            this.salesubmit.UseVisualStyleBackColor = true;
            this.salesubmit.Click += new System.EventHandler(this.salesubmit_Click);
            // 
            // saleTitle
            // 
            this.saleTitle.AutoSize = true;
            this.saleTitle.Location = new System.Drawing.Point(242, 25);
            this.saleTitle.Name = "saleTitle";
            this.saleTitle.Size = new System.Drawing.Size(61, 13);
            this.saleTitle.TabIndex = 7;
            this.saleTitle.Text = "Sale details";
            // 
            // salemsg
            // 
            this.salemsg.AutoSize = true;
            this.salemsg.Location = new System.Drawing.Point(253, 178);
            this.salemsg.Name = "salemsg";
            this.salemsg.Size = new System.Drawing.Size(0, 13);
            this.salemsg.TabIndex = 8;
            // 
            // Sale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 410);
            this.Controls.Add(this.salemsg);
            this.Controls.Add(this.saleTitle);
            this.Controls.Add(this.salesubmit);
            this.Controls.Add(this.soldquantitytxt);
            this.Controls.Add(this.saleinstoredrop);
            this.Controls.Add(this.itemsolddrop);
            this.Controls.Add(this.soldinstore);
            this.Controls.Add(this.quantitysold);
            this.Controls.Add(this.itemsold);
            this.Name = "Sale";
            this.Text = "Sale";
            this.Load += new System.EventHandler(this.Sale_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label itemsold;
        private System.Windows.Forms.Label quantitysold;
        private System.Windows.Forms.Label soldinstore;
        private System.Windows.Forms.ComboBox itemsolddrop;
        private System.Windows.Forms.ComboBox saleinstoredrop;
        private System.Windows.Forms.TextBox soldquantitytxt;
        private System.Windows.Forms.Button salesubmit;
        private System.Windows.Forms.Label saleTitle;
        private System.Windows.Forms.Label salemsg;
    }
}