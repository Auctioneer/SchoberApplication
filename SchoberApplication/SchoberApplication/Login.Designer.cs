using System.Drawing;
namespace SchoberApplication
{
    partial class Login
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

            Image view = Image.FromFile(@"login.jpg");
            this.BackgroundImage = view;

            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cTextUsername = new ChreneLib.Controls.TextBoxes.CTextBox();
            this.cTextPassword = new ChreneLib.Controls.TextBoxes.CTextBox();
            this.signinButton = new System.Windows.Forms.Button();
            this.helpMissingUsernameLabel = new System.Windows.Forms.Label();
            this.helpMissingPasswordLabel = new System.Windows.Forms.Label();
            this.incorrectUsernameLabel = new System.Windows.Forms.Label();
            this.incorrectPasswordLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // cTextUsername
            // 
            this.cTextUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.32F);
            this.cTextUsername.Location = new System.Drawing.Point(235, 230);
            this.cTextUsername.Name = "cTextUsername";
            this.cTextUsername.Size = new System.Drawing.Size(150, 20);
            this.cTextUsername.TabIndex = 5;
            this.cTextUsername.WaterMark = "Username";
            this.cTextUsername.WaterMarkActiveForeColor = System.Drawing.Color.Gray;
            this.cTextUsername.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cTextUsername.WaterMarkForeColor = System.Drawing.Color.LightGray;
            // 
            // cTextPassword
            // 
            this.cTextPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.32F);
            this.cTextPassword.Location = new System.Drawing.Point(235, 256);
            this.cTextPassword.Name = "cTextPassword";
            this.cTextPassword.Size = new System.Drawing.Size(150, 20);
            this.cTextPassword.TabIndex = 6;
            this.cTextPassword.WaterMark = "Password";
            this.cTextPassword.PasswordChar = '*';
            this.cTextPassword.WaterMarkActiveForeColor = System.Drawing.Color.Gray;
            this.cTextPassword.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cTextPassword.WaterMarkForeColor = System.Drawing.Color.LightGray;
            // 
            // signinButton
            // 
            this.signinButton.Location = new System.Drawing.Point(256, 295);
            this.signinButton.Name = "signinButton";
            this.signinButton.Size = new System.Drawing.Size(92, 24);
            this.signinButton.TabIndex = 7;
            this.signinButton.Text = "Sign In";
            this.signinButton.UseVisualStyleBackColor = true;
            this.signinButton.Click += new System.EventHandler(this.signinButton_Click);
            // 
            // helpMissingUsernameLabel
            // 
            this.helpMissingUsernameLabel.AutoSize = true;
            this.helpMissingUsernameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpMissingUsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.helpMissingUsernameLabel.ForeColor = System.Drawing.Color.Red;
            this.helpMissingUsernameLabel.Location = new System.Drawing.Point(150, 326);
            this.helpMissingUsernameLabel.Name = "helpMissingUsernameLabel";
            this.helpMissingUsernameLabel.Size = new System.Drawing.Size(413, 39);
            this.helpMissingUsernameLabel.TabIndex = 8;
            this.helpMissingUsernameLabel.Text = "Please Enter Your Username";
            this.helpMissingUsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.helpMissingUsernameLabel.Visible = false;
            // 
            // helpMissingPasswordLabel
            // 
            this.helpMissingPasswordLabel.AutoSize = true;
            this.helpMissingPasswordLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpMissingPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.helpMissingPasswordLabel.ForeColor = System.Drawing.Color.Red;
            this.helpMissingPasswordLabel.Location = new System.Drawing.Point(150, 326);
            this.helpMissingPasswordLabel.Name = "helpMissingPasswordLabel";
            this.helpMissingPasswordLabel.Size = new System.Drawing.Size(405, 39);
            this.helpMissingPasswordLabel.TabIndex = 9;
            this.helpMissingPasswordLabel.Text = "Please Enter Your Password";
            this.helpMissingPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.helpMissingPasswordLabel.Visible = false;
            // 
            // incorrectUsernameLabel
            // 
            this.incorrectUsernameLabel.AutoSize = true;
            this.incorrectUsernameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.incorrectUsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.incorrectUsernameLabel.ForeColor = System.Drawing.Color.Red;
            this.incorrectUsernameLabel.Location = new System.Drawing.Point(150, 326);
            this.incorrectUsernameLabel.Name = "incorrectUsernameLabel";
            this.incorrectUsernameLabel.Size = new System.Drawing.Size(405, 39);
            this.incorrectUsernameLabel.TabIndex = 9;
            this.incorrectUsernameLabel.Text = "Incorrect Username. Try Again.";
            this.incorrectUsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.incorrectUsernameLabel.Visible = false;
            // 
            // incorrectPasswordLabel
            // 
            this.incorrectPasswordLabel.AutoSize = true;
            this.incorrectPasswordLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.incorrectPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.incorrectPasswordLabel.ForeColor = System.Drawing.Color.Red;
            this.incorrectPasswordLabel.Location = new System.Drawing.Point(150, 326);
            this.incorrectPasswordLabel.Name = "incorrectPasswordLabel";
            this.incorrectPasswordLabel.Size = new System.Drawing.Size(405, 39);
            this.incorrectPasswordLabel.TabIndex = 9;
            this.incorrectPasswordLabel.Text = "Incorrect Password. Try Again.";
            this.incorrectPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.incorrectPasswordLabel.Visible = false;
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(400, 430);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(180, 40);
            this.exitButton.TabIndex = 10;
            this.exitButton.Text = "Exit Application";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.helpMissingPasswordLabel);
            this.Controls.Add(this.helpMissingUsernameLabel);
            this.Controls.Add(this.incorrectUsernameLabel);
            this.Controls.Add(this.incorrectPasswordLabel);
            this.Controls.Add(this.signinButton);
            this.Controls.Add(this.cTextPassword);
            this.Controls.Add(this.cTextUsername);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            //this.Load += new System.EventHandler(this.Login_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ChreneLib.Controls.TextBoxes.CTextBox cTextUsername;
        private ChreneLib.Controls.TextBoxes.CTextBox cTextPassword;
        private System.Windows.Forms.Button signinButton;
        private System.Windows.Forms.Label helpMissingUsernameLabel;
        private System.Windows.Forms.Label helpMissingPasswordLabel;
        private System.Windows.Forms.Label incorrectUsernameLabel;
        private System.Windows.Forms.Label incorrectPasswordLabel;
        private System.Windows.Forms.Button exitButton;
    }
}
