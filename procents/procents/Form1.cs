using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace procents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b, c,c1;
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox3.Text);
            c = a*100 / (100 + b);
            c1 = Math.Round(c);
            textBox2.Text = Convert.ToString(c1);
        }
    }
}
