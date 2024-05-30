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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 6; i++)
            {
                label3.Text += $"gamer{i + 1}" + "\n\n";
                label4.Text += Form1.Gamer[i].ToString() + "\n\n";
                label5.Text += Form1.Gamer3[i].ToString() + "\n\n";
                if (Form1.Gamer3[i] == 0) label6.Text += "0" + "\n\n";
                else label6.Text += (Form1.Gamer[i] / Form1.Gamer3[i]).ToString() + "\n\n";
            }
        }
    }
}
