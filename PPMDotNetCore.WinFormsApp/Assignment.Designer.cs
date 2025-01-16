
namespace PPMDotNetCore.WinFormsApp
{
    partial class Assignment
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            comboxbtn = new Button();
            listboxbtn = new Button();
            checklistbtn = new Button();
            viewbtn = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            checkedListBox1 = new CheckedListBox();
            comboBox1 = new ComboBox();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(231, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(327, 27);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(231, 113);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(327, 27);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // comboxbtn
            // 
            comboxbtn.Location = new Point(231, 209);
            comboxbtn.Name = "comboxbtn";
            comboxbtn.Size = new Size(94, 29);
            comboxbtn.TabIndex = 4;
            comboxbtn.Text = "comboboxBtn";
            comboxbtn.UseVisualStyleBackColor = true;
            comboxbtn.Click += comboxbtn_Click;
            // 
            // listboxbtn
            // 
            listboxbtn.Location = new Point(231, 250);
            listboxbtn.Name = "listboxbtn";
            listboxbtn.Size = new Size(94, 29);
            listboxbtn.TabIndex = 5;
            listboxbtn.Text = "listboxbtn";
            listboxbtn.UseVisualStyleBackColor = true;
            listboxbtn.Click += listboxbtn_Click;
            // 
            // checklistbtn
            // 
            checklistbtn.Location = new Point(231, 294);
            checklistbtn.Name = "checklistbtn";
            checklistbtn.Size = new Size(94, 29);
            checklistbtn.TabIndex = 6;
            checklistbtn.Text = "checklistbtn";
            checklistbtn.UseVisualStyleBackColor = true;
            checklistbtn.Click += checklistbtn_Click;
            // 
            // viewbtn
            // 
            viewbtn.Location = new Point(345, 294);
            viewbtn.Name = "viewbtn";
            viewbtn.Size = new Size(94, 29);
            viewbtn.TabIndex = 7;
            viewbtn.Text = "viewbtn";
            viewbtn.UseVisualStyleBackColor = true;
            viewbtn.Click += viewbtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(231, 37);
            label1.Name = "label1";
            label1.Size = new Size(28, 20);
            label1.TabIndex = 8;
            label1.Text = "Txt";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(231, 152);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 9;
            label2.Text = "combobox";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(231, 90);
            label3.Name = "label3";
            label3.Size = new Size(28, 20);
            label3.TabIndex = 10;
            label3.Text = "Txt";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(408, 152);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 11;
            label4.Text = "checklist";
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(408, 175);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(150, 114);
            checkedListBox1.TabIndex = 12;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(231, 175);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 13;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(576, 185);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(150, 104);
            listBox1.TabIndex = 14;
            // 
            // Assignment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox1);
            Controls.Add(comboBox1);
            Controls.Add(checkedListBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(viewbtn);
            Controls.Add(checklistbtn);
            Controls.Add(listboxbtn);
            Controls.Add(comboxbtn);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Assignment";
            Text = "Assignment";
            ResumeLayout(false);
            PerformLayout();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox2.Text);
            textBox2.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox1.Text);
            textBox1.Clear();
        }


        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button comboxbtn;
        private Button listboxbtn;
        private Button checklistbtn;
        private Button viewbtn;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private CheckedListBox checkedListBox1;
        private ComboBox comboBox1;
        private ListBox listBox1;
    }
}