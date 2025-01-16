using PPMDotNetCore.WinFormsApp.Models;
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
    public partial class Assignment : Form
    {
        public Assignment()
        {
            InitializeComponent();
        }

        private void comboxbtn_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox1.Text);
            comboBox1.Items.Add(textBox2.Text);
            textBox1.Clear();
            textBox2.Clear();
        }

        private void listboxbtn_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is not null)
            {
                listBox1.Items.Add(comboBox1.SelectedItem);
            }
        }

        private void checklistbtn_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox1.Items)
            {
                checkedListBox1.Items.Add(item);
            }
        }

        private void viewbtn_Click(object sender, EventArgs e)
        {
            string selectedItems = "";
            foreach (var item in checkedListBox1.CheckedItems)
            {
                selectedItems = item.ToString();
            }
            MessageBox.Show("Your slesction is" + selectedItems);
        }
    }
}
