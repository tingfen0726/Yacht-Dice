using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 物件導向程式設計實習期末報告_張婷棻
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] vs = new int[5];
            vs[0] = int.Parse(textBox1.Text);
            vs[1] = int.Parse(textBox2.Text);
            vs[2] = int.Parse(textBox3.Text);
            vs[3] = int.Parse(textBox4.Text);
            vs[4] = int.Parse(textBox5.Text);
            for(int i = 0; i < vs.Length; i++)
            {
                Form4.bug[i] = vs[i];
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form4.T = 1;
        }
    }
}
