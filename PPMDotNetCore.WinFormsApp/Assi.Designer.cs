namespace PPMDotNetCore.WinFormsApp
{
    partial class Assi
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
            checkedListbox = new CheckedListBox();
            Savebtn = new Button();
            listBox1 = new ListBox();
            listbtn = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(224, 24);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(224, 67);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 1;
            // 
            // checkedListbox
            // 
            checkedListbox.FormattingEnabled = true;
            checkedListbox.Location = new Point(381, 24);
            checkedListbox.Name = "checkedListbox";
            checkedListbox.Size = new Size(150, 114);
            checkedListbox.TabIndex = 2;
            // 
            // Savebtn
            // 
            Savebtn.Location = new Point(224, 109);
            Savebtn.Name = "Savebtn";
            Savebtn.Size = new Size(94, 29);
            Savebtn.TabIndex = 3;
            Savebtn.Text = "SaveBtn";
            Savebtn.UseVisualStyleBackColor = true;
            Savebtn.Click += Savebtn_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(381, 161);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(150, 104);
            listBox1.TabIndex = 4;
            // 
            // listbtn
            // 
            listbtn.Location = new Point(224, 144);
            listbtn.Name = "listbtn";
            listbtn.Size = new Size(94, 29);
            listbtn.TabIndex = 5;
            listbtn.Text = "listsavebtn";
            listbtn.UseVisualStyleBackColor = true;
            listbtn.Click += listbtn_Click;
            // 
            // Assi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listbtn);
            Controls.Add(listBox1);
            Controls.Add(Savebtn);
            Controls.Add(checkedListbox);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Assi";
            Text = "Assi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private CheckedListBox checkedListbox;
        private Button Savebtn;
        private ListBox listBox1;
        private Button listbtn;
    }
}