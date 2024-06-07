namespace PPMDotNetCore.WinFormsAppSqlInjection
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            label1 = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            txtPassword = new TextBox();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(250, 185);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "&Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(250, 76);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 1;
            label1.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(250, 99);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(367, 27);
            txtEmail.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(250, 129);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(250, 152);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(367, 27);
            txtPassword.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label label1;
        private TextBox txtEmail;
        private Label label2;
        private TextBox txtPassword;
    }
}
