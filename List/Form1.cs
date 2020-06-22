using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace List
{
    public partial class Form1 : Form
    {
        List<string> list = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = list.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            list.AddBegin(textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            list.Add(textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox9.Text, out int x))
                list.Add(textBox4.Text, x);
            else
                MessageBox.Show("Input error!");      
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox5.Text, out int x))
                textBox6.Text = list[x];
            else
                MessageBox.Show("Input error!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox8.Text, out int x))
                list[x] = textBox7.Text;
            else
                MessageBox.Show("Input error!");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            list.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox10.Text = list.Count.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            list.AddBefore(textBox12.Text, textBox11.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            list.Remove(textBox14.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox15.Text, out int x))
                list.RemoveAt(x);
            else
                MessageBox.Show("Input error!");
        }
    }
}
