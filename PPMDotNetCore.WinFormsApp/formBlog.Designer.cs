namespace PPMDotNetCore.WinFormsApp
{
    partial class formBlog
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
            txtTitle = new TextBox();
            txtContent = new TextBox();
            txtAuthor = new TextBox();
            btnCancel = new Button();
            btnSave = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(170, 77);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(360, 27);
            txtTitle.TabIndex = 1;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(170, 183);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(360, 113);
            txtContent.TabIndex = 2;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(170, 130);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(360, 27);
            txtAuthor.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(270, 302);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "C&ancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(170, 302);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(170, 107);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 6;
            label1.Text = "Author :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(170, 160);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 7;
            label2.Text = "Content :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(170, 54);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 8;
            label3.Text = "Title :";
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.IndianRed;
            btnUpdate.Location = new Point(170, 302);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "&Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // formBlog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUpdate);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(txtAuthor);
            Controls.Add(txtContent);
            Controls.Add(txtTitle);
            Name = "formBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtContent;
        private TextBox txtAuthor;
        private Button btnCancel;
        private Button btnSave;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnUpdate;
    }
}
