namespace SchoberApplication
{
    partial class Supplier
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
            this.suppTitle = new System.Windows.Forms.Label();
            this.suppname = new System.Windows.Forms.Label();
            this.suppnr = new System.Windows.Forms.Label();
            this.suppfname = new System.Windows.Forms.Label();
            this.supplname = new System.Windows.Forms.Label();
            this.suppemail = new System.Windows.Forms.Label();
            this.suppnametxt = new System.Windows.Forms.TextBox();
            this.suppnrtxt = new System.Windows.Forms.TextBox();
            this.suppfnametxt = new System.Windows.Forms.TextBox();
            this.supplnametxt = new System.Windows.Forms.TextBox();
            this.suppemailtxt = new System.Windows.Forms.TextBox();
            this.suppSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // suppTitle
            // 
            this.suppTitle.AutoSize = true;
            this.suppTitle.Location = new System.Drawing.Point(322, 27);
            this.suppTitle.Name = "suppTitle";
            this.suppTitle.Size = new System.Drawing.Size(78, 13);
            this.suppTitle.TabIndex = 36;
            this.suppTitle.Text = "Supplier details";
            // 
            // suppname
            // 
            this.suppname.AutoSize = true;
            this.suppname.Location = new System.Drawing.Point(159, 62);
            this.suppname.Name = "suppname";
            this.suppname.Size = new System.Drawing.Size(35, 13);
            this.suppname.TabIndex = 37;
            this.suppname.Text = "Name";
            // 
            // suppnr
            // 
            this.suppnr.AutoSize = true;
            this.suppnr.Location = new System.Drawing.Point(135, 88);
            this.suppnr.Name = "suppnr";
            this.suppnr.Size = new System.Drawing.Size(59, 13);
            this.suppnr.TabIndex = 38;
            this.suppnr.Text = "Contact nr.";
            // 
            // suppfname
            // 
            this.suppfname.AutoSize = true;
            this.suppfname.Location = new System.Drawing.Point(116, 114);
            this.suppfname.Name = "suppfname";
            this.suppfname.Size = new System.Drawing.Size(78, 13);
            this.suppfname.TabIndex = 39;
            this.suppfname.Text = "Rep. first name";
            // 
            // supplname
            // 
            this.supplname.AutoSize = true;
            this.supplname.Location = new System.Drawing.Point(97, 140);
            this.supplname.Name = "supplname";
            this.supplname.Size = new System.Drawing.Size(97, 13);
            this.supplname.TabIndex = 40;
            this.supplname.Text = "Rep. second name";
            // 
            // suppemail
            // 
            this.suppemail.AutoSize = true;
            this.suppemail.Location = new System.Drawing.Point(162, 166);
            this.suppemail.Name = "suppemail";
            this.suppemail.Size = new System.Drawing.Size(32, 13);
            this.suppemail.TabIndex = 41;
            this.suppemail.Text = "Email";
            // 
            // suppnametxt
            // 
            this.suppnametxt.Location = new System.Drawing.Point(200, 62);
            this.suppnametxt.Name = "suppnametxt";
            this.suppnametxt.Size = new System.Drawing.Size(100, 20);
            this.suppnametxt.TabIndex = 42;
            // 
            // suppnrtxt
            // 
            this.suppnrtxt.Location = new System.Drawing.Point(200, 88);
            this.suppnrtxt.Name = "suppnrtxt";
            this.suppnrtxt.Size = new System.Drawing.Size(100, 20);
            this.suppnrtxt.TabIndex = 43;
            // 
            // suppfnametxt
            // 
            this.suppfnametxt.Location = new System.Drawing.Point(200, 114);
            this.suppfnametxt.Name = "suppfnametxt";
            this.suppfnametxt.Size = new System.Drawing.Size(100, 20);
            this.suppfnametxt.TabIndex = 44;
            // 
            // supplnametxt
            // 
            this.supplnametxt.Location = new System.Drawing.Point(200, 140);
            this.supplnametxt.Name = "supplnametxt";
            this.supplnametxt.Size = new System.Drawing.Size(100, 20);
            this.supplnametxt.TabIndex = 45;
            // 
            // suppemailtxt
            // 
            this.suppemailtxt.Location = new System.Drawing.Point(200, 166);
            this.suppemailtxt.Name = "suppemailtxt";
            this.suppemailtxt.Size = new System.Drawing.Size(100, 20);
            this.suppemailtxt.TabIndex = 46;
            // 
            // suppSubmit
            // 
            this.suppSubmit.Location = new System.Drawing.Point(472, 166);
            this.suppSubmit.Name = "suppSubmit";
            this.suppSubmit.Size = new System.Drawing.Size(75, 23);
            this.suppSubmit.TabIndex = 47;
            this.suppSubmit.Text = "Submit";
            this.suppSubmit.UseVisualStyleBackColor = true;
            // 
            // Supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 585);
            this.Controls.Add(this.suppSubmit);
            this.Controls.Add(this.suppemailtxt);
            this.Controls.Add(this.supplnametxt);
            this.Controls.Add(this.suppfnametxt);
            this.Controls.Add(this.suppnrtxt);
            this.Controls.Add(this.suppnametxt);
            this.Controls.Add(this.suppemail);
            this.Controls.Add(this.supplname);
            this.Controls.Add(this.suppfname);
            this.Controls.Add(this.suppnr);
            this.Controls.Add(this.suppname);
            this.Controls.Add(this.suppTitle);
            this.Name = "Supplier";
            this.Text = "Supplier";
            this.Load += new System.EventHandler(this.Supplier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label suppTitle;
        private System.Windows.Forms.Label suppname;
        private System.Windows.Forms.Label suppnr;
        private System.Windows.Forms.Label suppfname;
        private System.Windows.Forms.Label supplname;
        private System.Windows.Forms.Label suppemail;
        private System.Windows.Forms.TextBox suppnametxt;
        private System.Windows.Forms.TextBox suppnrtxt;
        private System.Windows.Forms.TextBox suppfnametxt;
        private System.Windows.Forms.TextBox supplnametxt;
        private System.Windows.Forms.TextBox suppemailtxt;
        private System.Windows.Forms.Button suppSubmit;
    }
}