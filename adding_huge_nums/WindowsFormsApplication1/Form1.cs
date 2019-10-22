using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();        
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
               textBox3.Visible = true;
            textBox3.Clear();
                label3.Visible = true;
                if ((textBox1.TextLength == 0) || (textBox2.TextLength == 0))
                    MessageBox.Show("Введіть числа");
                else
                {
                    string s1, s2;
                    int i1, i2;
                    int pr1 = 0;
                    int[] ar1 = new int[textBox1.TextLength > textBox2.TextLength ? textBox1.TextLength : textBox2.TextLength]; //массив 1, тут храниться первое длинное число
                    int[] ar2 = new int[textBox1.TextLength > textBox2.TextLength ? textBox1.TextLength : textBox2.TextLength]; //массив 2, тут храниться первое длинное число
                    int[] ar3 = new int[textBox1.TextLength > textBox2.TextLength ? textBox1.TextLength + 1 : textBox2.TextLength + 1];
                    int[] ar4 = new int[textBox1.TextLength > textBox2.TextLength ? textBox1.TextLength : textBox2.TextLength];//массив 3, тут храниться результат суммы.
                    s1 = textBox1.Text;
                    s2 = textBox2.Text;
                    ar1 = Array.ConvertAll<string, int>(Array.ConvertAll<char, string>(s1.ToCharArray(), Convert.ToString), Convert.ToInt32);
                    ar2 = Array.ConvertAll<string, int>(Array.ConvertAll<char, string>(s2.ToCharArray(), Convert.ToString), Convert.ToInt32);
                    Array.Clear(ar4, 0, ar4.Length - 1);
                    int a = textBox1.TextLength;
                    int b = textBox2.TextLength;
                    int c = a - b;
                    int d;
                    d = b-a;
                if (c > 0)
                {
                    for (int i = 0; i < c; i++)
                    { ar4[i] = 0; }
                    ar2.CopyTo(ar4, c);
                    if ((checkBox1.Checked) && (checkBox2.Checked))
                    {
                        for (int hh = ar1.Length - 1; hh >= 0; hh--)  //исчисление суммы
                        {
                            ar3[hh + 1] = ar4[hh] + ar1[hh]; //пишем нужную сумму
                        }
                        for (int i = ar3.Length - 1; i > 0; i--)
                        {
                            if (ar3[i] > 9)
                            {
                                ar3[i] -= 10;
                                ar3[i - 1] += 1;
                            }
                        }
                        label6.Text = "-";
                    }
                    else
                    if (checkBox1.Checked)
                    {
                        for (int hh = ar1.Length - 1; hh >= 0; hh--)  //исчисление суммы
                        {
                            ar3[hh + 1] = ar1[hh] - ar4[hh]; //пишем нужную сумму
                        }
                        for (int i = ar3.Length - 1; i > 0; i--)
                        {
                            if (ar3[i] < 0)
                            {
                                ar3[i] += 10;
                                ar3[i - 1] -= 1;
                            }
                        }
                        label6.Text = "-";
                    }
                else 
                 if (checkBox2.Checked)
                    {
                        for (int hh = ar1.Length - 1; hh >= 0; hh--)  //исчисление суммы
                        {
                            ar3[hh + 1] = ar1[hh] - ar4[hh]; //пишем нужную сумму
                        }
                        for (int i = ar3.Length - 1; i > 0; i--)
                        {
                            if (ar3[i] < 0)
                            {
                                ar3[i] += 10;
                                ar3[i - 1] -= 1;
                            }
                           // label6.Text = "-";
                        }
                    }
                    else
                    {
                        for (int hh = ar1.Length - 1; hh >= 0; hh--)  //исчисление суммы
                        {
                            ar3[hh + 1] = ar4[hh] + ar1[hh]; //пишем нужную сумму
                        }
                        for (int i = ar3.Length - 1; i > 0; i--)
                        {
                            if (ar3[i] > 9)
                            {
                                ar3[i] -= 10;
                                ar3[i - 1] += 1;
                            }
                        }
                    }
                }
                else 
                if (c < 0)
                {
                    for (int i = 0; i < d; i++)
                    { ar4[i] = 0; }
                    ar1.CopyTo(ar4, d);
                    if ((checkBox1.Checked) && (checkBox2.Checked))
                    {
                        for (int hh = ar2.Length - 1; hh >= 0; hh--)  //исчисление суммы
                        {
                            ar3[hh + 1] = ar4[hh] + ar2[hh]; //пишем нужную сумму
                        }
                        for (int i = ar3.Length - 1; i > 0; i--)
                        {
                            if (ar3[i] > 9)
                            {
                                ar3[i] -= 10;
                                ar3[i - 1] += 1;
                            }
                        }
                        label6.Text = "-";
                    }
                    else
                    if (checkBox1.Checked)
                    {
                        for (int hh = ar2.Length - 1; hh >= 0; hh--)  //исчисление суммы
                        {
                            ar3[hh + 1] = ar2[hh] - ar4[hh]; //пишем нужную сумму
                        }
                        for (int i = ar3.Length - 1; i > 0; i--)
                        {
                            if (ar3[i] < 0)
                            {
                                ar3[i] += 10;
                                ar3[i - 1] -= 1;
                            }
                           // label6.Text = "-";
                        }
                    }
                    else 
                    if (checkBox2.Checked)
                    {
                        for (int hh = ar2.Length - 1; hh >= 0; hh--)  //исчисление суммы
                        {
                            ar3[hh + 1] = ar2[hh] - ar4[hh]; //пишем нужную сумму
                        }
                        for (int i = ar3.Length - 1; i > 0; i--)
                        {
                            if (ar3[i] < 0)
                            {
                                ar3[i] += 10;
                                ar3[i - 1] -= 1;
                            }
                            label6.Text = "-";
                        }
                    }
                    else
                    {
                        for (int hh = ar2.Length - 1; hh >= 0; hh--)  //исчисление суммы
                        {
                            ar3[hh + 1] = ar4[hh] + ar2[hh]; //пишем нужную сумму
                        }
                        for (int i = ar3.Length - 1; i > 0; i--)
                        {
                            if (ar3[i] > 9)
                            {
                                ar3[i] -= 10;
                                ar3[i - 1] += 1;
                            }
                        }
                    }
                }

                else if (c == 0)
                {
                    int v;
                    v = 0;
                    for (int i = ar1.Length - 1; i >= 0; i--)
                    {
                        if (ar1[i] > ar2[i])
                            v = 1;
                    }
                    if ((checkBox1.Checked) && (checkBox2.Checked))
                    {
                        for (int hh = ar1.Length - 1; hh >= 0; hh--)  //исчисление суммы
                        {
                            ar3[hh + 1] = ar1[hh] + ar2[hh]; //пишем нужную сумму
                        }
                        for (int i = ar3.Length - 1; i > 0; i--)
                        {
                            if (ar3[i] > 9)
                            {
                                ar3[i] -= 10;
                                ar3[i - 1] += 1;
                            }
                        }
                        label6.Text = "-";
                    }
                    else
                    if (checkBox1.Checked)
                        {
                        if (v == 0)
                        {
                            for (int hh = ar1.Length - 1; hh >= 0; hh--)  //исчисление суммы
                            {
                                ar3[hh + 1] = ar2[hh] - ar1[hh]; //пишем нужную сумму
                            }
                        }
                        else
                            for (int hh = ar1.Length - 1; hh >= 0; hh--)  //исчисление суммы
                            {
                                ar3[hh + 1] = ar1[hh] - ar2[hh]; //пишем нужную сумму
                            }
                        for (int i = ar3.Length - 1; i > 0; i--)
                            {
                                if (ar3[i] < 0)
                                {
                                    ar3[i] += 10;
                                    ar3[i - 1] -= 1;
                                }
                                if (v==1)
                                label6.Text = "-";
                            }
                        }
                        else 
                        if (checkBox2.Checked)
                        {
                        if (v == 0)
                        {
                            for (int hh = ar1.Length - 1; hh >= 0; hh--)  //исчисление суммы
                            {
                                ar3[hh + 1] = ar2[hh] - ar1[hh]; //пишем нужную сумму
                            }
                        }
                        else
                            for (int hh = ar1.Length - 1; hh >= 0; hh--)  //исчисление суммы
                            {
                                ar3[hh + 1] = ar1[hh] - ar2[hh]; //пишем нужную сумму
                            }
                        for (int i = ar3.Length - 1; i > 0; i--)
                            {
                                if (ar3[i] < 0)
                                {
                                    ar3[i] += 10;
                                    ar3[i - 1] -= 1;
                                }
                            if (v == 0)
                                label6.Text = "-";
                        }
                        }
                   
                    else
                        {
                            for (int hh = ar1.Length - 1; hh >= 0; hh--)  //исчисление суммы
                            {
                                ar3[hh + 1] = ar2[hh] + ar1[hh]; //пишем нужную сумму
                            }
                            for (int i = ar3.Length - 1; i > 0; i--)
                            {
                                if (ar3[i] > 9)
                                {
                                    ar3[i] -= 10;
                                    ar3[i - 1] += 1;
                                }
                            }
                    }
                    }
                textBox3.Text = string.Join("", ar3);
            }
            }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Select();
            //textBox2.Visible = false;
            //textBox3.Visible = false;
            //label2.Visible = false;
            //label3.Visible = false;
           // button1.Enabled = false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Visible = true;
                label2.Visible = true;
                textBox2.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.TextLength == 0)
                MessageBox.Show("Введіть числo");
            else { 
            int r, i;
            string s;
            textBox1.Text = "";
            s = textBox4.Text;
            r = Convert.ToInt32(s);
                Random random = new Random();
                for (i = 0; i < r; i++)
                {
                    int m = random.Next(0, 9);
                    string g = Convert.ToString(m);
                    textBox1.Text = textBox1.Text + g;
                    textBox2.Visible = true;
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Enabled = true;
                button1_Click(button1, e);
               }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.TextLength == 0)
                MessageBox.Show("Введіть числo");
            else
            {
                int r, i;
                string s;
                textBox1.Text = "";
                s = textBox4.Text;
                r = Convert.ToInt32(s);
                Random random = new Random();
                for (i = 0; i < r; i++)
                {
                    int m = random.Next(0, 9);
                    string g = Convert.ToString(m);
                    textBox1.Text = textBox1.Text + g;
                    textBox2.Visible = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            label6.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void очиститиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            label6.Text = "";
        }

        private void вихідToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void проРозробникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Програму розробив студент групи 472"+"\n"+"КІСІТ КНЕУ ім. В.Гетьмана"+ "\n" + "Падалка А.С.");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == ',' ||  e.KeyChar == (char)Keys.Back)))
              //  ((TextBox)sender).SelectionStart > 0) ||
               
            {
                e.Handled = true;
                MessageBox.Show("Введіть тільки числа");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == ',' || e.KeyChar == (char)Keys.Back)))
         //  ((TextBox)sender).SelectionStart > 0) ||  
                    {
                e.Handled = true;
                MessageBox.Show("Введіть тільки числа");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == ',' || e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
                MessageBox.Show("Введіть тільки числа");
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == ',' || e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
                MessageBox.Show("Введіть тільки числа");
            }
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Програма розроблена для додавання довгих чисел");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());
            if (e.KeyCode == Keys.F1)
            {
                System.Diagnostics.Process.Start("instr.html");
            }
        }

        private void інструкціяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("instr.html");
        }
    }
}