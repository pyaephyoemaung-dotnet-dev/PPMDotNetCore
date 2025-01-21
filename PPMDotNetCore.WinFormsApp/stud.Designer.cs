namespace PPMDotNetCore.WinFormsApp
{
    partial class stud
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
            savebtn = new Button();
            rollno = new TextBox();
            classno = new TextBox();
            name = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            id = new TextBox();
            label4 = new Label();
            listbtn = new Button();
            SuspendLayout();
            // 
            // savebtn
            // 
            savebtn.Location = new Point(342, 233);
            savebtn.Name = "savebtn";
            savebtn.Size = new Size(61, 29);
            savebtn.TabIndex = 0;
            savebtn.Text = "Save";
            savebtn.UseVisualStyleBackColor = true;
            savebtn.Click += button1_Click;
            // 
            // rollno
            // 
            rollno.Location = new Point(342, 56);
            rollno.Name = "rollno";
            rollno.Size = new Size(125, 27);
            rollno.TabIndex = 1;
            // 
            // classno
            // 
            classno.Location = new Point(342, 114);
            classno.Name = "classno";
            classno.Size = new Size(125, 27);
            classno.TabIndex = 2;
            // 
            // name
            // 
            name.Location = new Point(342, 186);
            name.Name = "name";
            name.Size = new Size(125, 27);
            name.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(258, 63);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 4;
            label1.Text = "Roll no";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(258, 121);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 5;
            label2.Text = "Class";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(258, 193);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 6;
            label3.Text = "Name";
            // 
            // id
            // 
            id.Location = new Point(342, 12);
            id.Name = "id";
            id.Size = new Size(125, 27);
            id.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(258, 15);
            label4.Name = "label4";
            label4.Size = new Size(22, 20);
            label4.TabIndex = 8;
            label4.Text = "Id";
            // 
            // listbtn
            // 
            listbtn.Location = new Point(409, 233);
            listbtn.Name = "listbtn";
            listbtn.Size = new Size(58, 29);
            listbtn.TabIndex = 9;
            listbtn.Text = "List";
            listbtn.UseVisualStyleBackColor = true;
            listbtn.Click += listbtn_Click;
            // 
            // stud
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listbtn);
            Controls.Add(label4);
            Controls.Add(id);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(name);
            Controls.Add(classno);
            Controls.Add(rollno);
            Controls.Add(savebtn);
            Name = "stud";
            Text = "stud";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button savebtn;
        private TextBox rollno;
        private TextBox classno;
        private TextBox name;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox id;
        private Label label4;
        private Button listbtn;
    }
}