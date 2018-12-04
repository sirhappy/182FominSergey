using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task02
{
    public partial class Form02 : Form
    {
        public Form02()
        {
            InitializeComponent();
        }

        private void Form02_Load(object sender, EventArgs e)
        {
            label1.ForeColor = Color.DeepPink;
        }

        double step = 0.02;
        int cnt = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.Text.Length > 0 && step > 0)
            {
                if (++cnt % 4 == 0)
                    label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
            }
            else
            {
                this.Opacity -= step;
                if (this.Opacity <= 0)
                {
                    label1.Text = "Кот уже ушёл!";
                    step = -step;
                }
            }
        }
    }
}
