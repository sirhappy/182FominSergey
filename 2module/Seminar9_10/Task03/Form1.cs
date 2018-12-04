using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int _pell, _prevpell;

        private void Form1_Load(object sender, EventArgs e)
        {
            _prevpell = 0;
            _pell = 1;
        }

        string str = "Следующий элемент Пелла: ";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int t = checked(_pell + _prevpell);
                _prevpell = _pell;
                _pell = t;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ряд переполнен! " + ex.ToString());
                _pell = 1;
                _prevpell = 1;
            }
            finally
            {
                label1.Text = str + _pell.ToString();
            }
        }
    }
}
