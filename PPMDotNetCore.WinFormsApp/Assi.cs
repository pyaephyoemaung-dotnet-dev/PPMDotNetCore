using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPMDotNetCore.WinFormsApp
{
    public partial class Assi : Form
    {
        public Assi()
        {
            InitializeComponent();
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            checkedListbox.Items.Add(textBox1.Text);
            checkedListbox.Items.Add(textBox2.Text);
            textBox1.Clear();
            textBox2.Clear();
        }

        private void listbtn_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListbox.CheckedItems)
            {
                listBox1.Items.Add(item);
            }
            for(int i = 0; i < checkedListbox.Items.Count; i++)
            {
                checkedListbox.SetItemChecked(i, false);
            }
        }
    }
}
