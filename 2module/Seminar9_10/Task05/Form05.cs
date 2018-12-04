using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task05
{
    public partial class Form05 : Form
    {
        public Form05()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        string s = "def";

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            char[] t = textBox1.Text.ToCharArray();
            string s = "";
            for (int i = 0; i < t.Length; ++i)
            {
                if (t[i] == '\n' || t[i] == '\r') t[i] = ' ';
                s += t[i];
            }
            MessageBox.Show(s);
        }
    }
}
