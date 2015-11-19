namespace SchoberApplication
{
    partial class Password
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
            this.newpswtxt = new System.Windows.Forms.TextBox();
            this.newpswrepeattxt = new System.Windows.Forms.TextBox();
            this.newpsw = new System.Windows.Forms.Label();
            this.newpswrepeat = new System.Windows.Forms.Label();
            this.pswTitle = new System.Windows.Forms.Label();
            this.pswsubmit = new System.Windows.Forms.Button();
            this.pswmsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newpswtxt
            // 
            this.newpswtxt.Location = new System.Drawing.Point(157, 74);
            this.newpswtxt.Name = "newpswtxt";
            this.newpswtxt.Size = new System.Drawing.Size(100, 20);
            this.newpswtxt.TabIndex = 0;
            // 
            // newpswrepeattxt
            // 
            this.newpswrepeattxt.Location = new System.Drawing.Point(157, 100);
            this.newpswrepeattxt.Name = "newpswrepeattxt";
            this.newpswrepeattxt.Size = new System.Drawing.Size(100, 20);
            this.newpswrepeattxt.TabIndex = 1;
            // 
            // newpsw
            // 
            this.newpsw.AutoSize = true;
            this.newpsw.Location = new System.Drawing.Point(74, 74);
            this.newpsw.Name = "newpsw";
            this.newpsw.Size = new System.Drawing.Size(77, 13);
            this.newpsw.TabIndex = 2;
            this.newpsw.Text = "New password";
            // 
            // newpswrepeat
            // 
            this.newpswrepeat.AutoSize = true;
            this.newpswrepeat.Location = new System.Drawing.Point(38, 100);
            this.newpswrepeat.Name = "newpswrepeat";
            this.newpswrepeat.Size = new System.Drawing.Size(113, 13);
            this.newpswrepeat.TabIndex = 3;
            this.newpswrepeat.Text = "Repeat new password";
            // 
            // pswTitle
            // 
            this.pswTitle.AutoSize = true;
            this.pswTitle.Location = new System.Drawing.Point(110, 22);
            this.pswTitle.Name = "pswTitle";
            this.pswTitle.Size = new System.Drawing.Size(160, 13);
            this.pswTitle.TabIndex = 4;
            this.pswTitle.Text = "Please enter your new password";
            // 
            // pswsubmit
            // 
            this.pswsubmit.Location = new System.Drawing.Point(258, 164);
            this.pswsubmit.Name = "pswsubmit";
            this.pswsubmit.Size = new System.Drawing.Size(58, 27);
            this.pswsubmit.TabIndex = 5;
            this.pswsubmit.Text = "Submit";
            this.pswsubmit.UseVisualStyleBackColor = true;
            this.pswsubmit.Click += new System.EventHandler(this.pswsubmit_Click);
            // 
            // pswmsg
            // 
            this.pswmsg.AutoSize = true;
            this.pswmsg.Location = new System.Drawing.Point(47, 172);
            this.pswmsg.Name = "pswmsg";
            this.pswmsg.Size = new System.Drawing.Size(0, 13);
            this.pswmsg.TabIndex = 6;
            // 
            // Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 259);
            this.Controls.Add(this.pswmsg);
            this.Controls.Add(this.pswsubmit);
            this.Controls.Add(this.pswTitle);
            this.Controls.Add(this.newpswrepeat);
            this.Controls.Add(this.newpsw);
            this.Controls.Add(this.newpswrepeattxt);
            this.Controls.Add(this.newpswtxt);
            this.Name = "Password";
            this.Text = "Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox newpswtxt;
        private System.Windows.Forms.TextBox newpswrepeattxt;
        private System.Windows.Forms.Label newpsw;
        private System.Windows.Forms.Label newpswrepeat;
        private System.Windows.Forms.Label pswTitle;
        private System.Windows.Forms.Button pswsubmit;
        private System.Windows.Forms.Label pswmsg;
    }
}