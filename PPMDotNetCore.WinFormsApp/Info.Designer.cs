namespace PPMDotNetCore.WinFormsApp
{
    partial class Info
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
            dgv = new DataGridView();
            rnum = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            filed = new DataGridViewTextBoxColumn();
            stuInfo = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { rnum, name, filed, stuInfo });
            dgv.Location = new Point(147, 54);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersWidth = 51;
            dgv.RowTemplate.Height = 29;
            dgv.Size = new Size(516, 327);
            dgv.TabIndex = 0;
            dgv.CellContentClick += dgv_CellContentClick;
            // 
            // rnum
            // 
            rnum.DataPropertyName = "BlogId";
            rnum.HeaderText = "Roll Number";
            rnum.MinimumWidth = 6;
            rnum.Name = "rnum";
            rnum.ReadOnly = true;
            // 
            // name
            // 
            name.DataPropertyName = "BlogTitle";
            name.HeaderText = "Name";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.ReadOnly = true;
            // 
            // filed
            // 
            filed.DataPropertyName = "BlogAuthor";
            filed.HeaderText = "Class Fields";
            filed.MinimumWidth = 6;
            filed.Name = "filed";
            filed.ReadOnly = true;
            // 
            // stuInfo
            // 
            stuInfo.DataPropertyName = "BlogContent";
            stuInfo.HeaderText = "Student Info";
            stuInfo.MinimumWidth = 6;
            stuInfo.Name = "stuInfo";
            stuInfo.ReadOnly = true;
            // 
            // Info
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv);
            Name = "Info";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Info";
            Load += Info_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv;
        private DataGridViewTextBoxColumn rnum;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn filed;
        private DataGridViewTextBoxColumn stuInfo;
    }
}