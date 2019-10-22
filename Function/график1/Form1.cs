using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace график1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "y=sin(x/2)-cos(x*x)";
            label5.Text = "Графік ф-ї y=sin(x/2)-cos(x*x)";
        }
        List<double> q = new List<double>();
        double x, y;

        private void кінецьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Програма розроблена для" + "\n" + "табулювання функції" + "\n" + "Розробник: Падалка А.С.");
        }

        private void очиститиПоляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void протабулюватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                MessageBox.Show("Введiть данi");
            else
            {
                double p;
                double a = Convert.ToDouble(textBox1.Text.Replace('.',','));
                double b = Convert.ToDouble(textBox2.Text.Replace('.', ','));
                double h = Convert.ToDouble(textBox3.Text.Replace('.', ','));
               
                    listBox1.Items.Add("X\tY");
                for (x = a; x < b + h / 2; x += h)
                {
                    y = Math.Sin(x/2) - Math.Cos(x*x);
                    p = 2 * (Math.Cos(x) * Math.Sin(2 * x - 1.5)+ 2*Math.Cos(2*x-1.5)) * Math.Sin(2 * x + 1.5);
                    if (checkBox1.Checked == true)
                        listBox1.Items.Add(Convert.ToString(Math.Round(x, 2)) + '\t' + Convert.ToString(Math.Round(y, 2)));
                    else
                        if (checkBox1.Checked == true)
                            listBox1.Items.Add(Convert.ToString(Math.Round(x, 2)) + '\t' + Convert.ToString(Math.Round(y, 2)));
                } for (x = a; x > b + h / 2; x += h)
                {
                    y = 2 * Math.Sin(x) * Math.Sin(2 * x - 1.5) * Math.Cos(2 * x + 1.5) - 6;
                    p = 2 * (Math.Cos(x) * Math.Sin(2 * x - 1.5) + 2 * Math.Cos(2 * x - 1.5)) * Math.Sin(2 * x + 1.5);
                    if (checkBox1.Checked == true)
                        listBox1.Items.Add(Convert.ToString(Math.Round(x, 2)) + '\t' + Convert.ToString(Math.Round(y, 2)) );
                    else
                        if (checkBox1.Checked == true)
                            listBox1.Items.Add(Convert.ToString(Math.Round(x, 2)) + '\t' + Convert.ToString(Math.Round(y, 2)));
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "C:";
            saveFileDialog1.Filter = "txt файлы(*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter streamWriter;
                streamWriter = new System.IO.StreamWriter(saveFileDialog1.FileName);
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    streamWriter.Write(listBox1.Items[i].ToString() + '\t');
                        streamWriter.Write(Environment.NewLine);
                }
                streamWriter.Close();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox3.Checked)
                return;
            listBox2.Items.Clear();
            double a = Convert.ToDouble(textBox1.Text.Replace('.', ','));
            double b = Convert.ToDouble(textBox2.Text.Replace('.', ','));
            double h = Convert.ToDouble(textBox3.Text.Replace('.', ','));
            listBox2.Items.Add("Y");
            for (x = a; x < b + h / 2; x += h)
            {
                y = Math.Sin(x / 2) - Math.Cos(x * x);
                q.Add(Math.Round(y,2));
            }
            for (x = a; x > b + h / 2; x += h)
            {
                y = Math.Sin(x / 2) - Math.Cos(x * x);
                q.Add(Math.Round(y, 2));
            }
            foreach (double w in q)
            listBox2.Items.Add(w.ToString());
        }

        private void виведенняГрафікаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text.Replace('.',','));
            double b = Convert.ToDouble(textBox2.Text.Replace('.',','));
            double h = Convert.ToDouble(textBox3.Text.Replace('.',','));
            chart1.Series[0].Color = Color.BlueViolet;
            chart1.Series[0].Points.Clear();
            for (double x = a; x < b; x += h)
                chart1.Series[0].Points.AddXY(Math.Sin(Math.Round(x,2)), Math.Round(x, 2));
            for (double x = a; x > b; x += h)
                chart1.Series[0].Points.AddXY(Math.Sin(Math.Round(x, 2)), Math.Round(x, 2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count == 0)
                MessageBox.Show("Встановiть прапорець 'У масив'");             
            else
            {
                if (textBox4.Text == "" || textBox5.Text == "")
                    MessageBox.Show("Введiть данi");
                else
                {
                    int r = 0;
                    double a = Convert.ToDouble(textBox4.Text.Replace('.', ','));
                    double b = Convert.ToDouble(textBox5.Text.Replace('.', ','));
                    for (int i = 0; i < q.Count; i++)
                        if (q[i] > a || q[i] < b)
                            r++;
                    textBox6.Text = r.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Text = textBox1.Text.Replace('.', ',');
            Random q = new Random();
            double a,b,h;
            for (int i = 0; i >= 0; i++)
            {
                a = Math.Round(q.Next(-11, 11) * q.NextDouble(), 2);
                b = Math.Round(q.Next(-11, 11) * q.NextDouble(), 2);
                h = Math.Round(q.Next(-2, 2) * q.NextDouble(), 1);
                if ((a<b && h<=0)||(a>b&&h>=0)||h>=a||h>=b)
                    continue;
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox1.Text = a.ToString();
                    textBox2.Text = b.ToString();
                    textBox3.Text = h.ToString();
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] str;
            openFileDialog1.Filter = "txt файлы(*.txt)|*.txt";
            openFileDialog1.InitialDirectory = Application.StartupPath;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader read = new StreamReader(openFileDialog1.FileName);
                str = read.ReadToEnd().Split(new Char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                int pos = 0;
                while (str[pos] == "")
                    pos++;
                textBox1.Text = str[0];
                textBox2.Text = str[1];
                textBox3.Text = str[2];
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((TextBox)sender).Text.Contains('-'))
            {
                if (!((Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == ',' || ((TextBox)sender).SelectionStart > 0) || e.KeyChar == (char)Keys.Back))
                {
                    e.Handled = true;
                    MessageBox.Show("Not correct data"+"Maybe you enter symbol");
                }
            }
            else
                if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == ',' || e.KeyChar == (char)Keys.Back || (e.KeyChar == '-' && ((TextBox)sender).SelectionStart == 0)))
                {
                    e.Handled = true;
                    MessageBox.Show("Not correct data" +"\n"+ "Maybe you enter symbol");
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "C:";
            saveFileDialog1.Filter = "txt файлы(*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter streamWriter;
                streamWriter = new System.IO.StreamWriter(saveFileDialog1.FileName);
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    streamWriter.Write(listBox2.Items[i].ToString() + '\t');
                    streamWriter.Write(Environment.NewLine);
                }
                streamWriter.Close();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1_KeyPress(sender, e);
        }

    }
}
