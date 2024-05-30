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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int[] Gamer = new int[7] {0,0,0,0,0,0,0};//總分
        public static int[] Gamer2 = new int[2];//玩家
        public static int[] Gamer3 = new int[7] {0,0,0,0,0,0,0};//場次
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == comboBox2.SelectedIndex)
            {
                MessageBox.Show("請勿選擇同位玩家","錯誤");
                return;
            }
            Gamer2[0] = comboBox1.SelectedIndex;
            Gamer2[1] = comboBox2.SelectedIndex;
            if (comboBox2.SelectedIndex == 6)
            {
                form6 form6 = new form6();
                form6.ShowDialog();
            }
            else
            {
                Form4 form4 = new Form4();
                form4.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

    }
}
