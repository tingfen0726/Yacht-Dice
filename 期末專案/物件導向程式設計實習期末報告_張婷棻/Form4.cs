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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public static int[] bug = new int[5];//除錯
        public static int T;
        int[] player = new int[2] { 0, 0 };//總分
        int[] player2 = new int[2] { 0, 0 };//紅利加分
        int[] N = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//分數提示
        PictureBox[] pictureBoxes = new PictureBox[5];//顯示骰子
        int[] num = new int[5];//骰子大小
        bool[] stop = new bool[5];//保留
        int play = 2, game = 26;//剩餘次數，遊戲輪數
        bool[] vs1 = new bool[2];//紅利是否加分
        private void Form4_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            pictureBoxes[0] = pictureBox1;
            pictureBoxes[1] = pictureBox2;
            pictureBoxes[2] = pictureBox3;
            pictureBoxes[3] = pictureBox4;
            pictureBoxes[4] = pictureBox5;
            ran();
            go();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (play == 0)
            {
                MessageBox.Show("已無剩餘執骰次數，請選擇分數", "錯誤");
                return;
            }
            else
            {
                play -= 1;
                label1.Text = "剩餘次數：" + play.ToString() + " / 3";
                ran();
            }
            go();
        }
        private void ran()
        {
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                if (stop[i] == false)
                { num[i] = random.Next(1, 7); pictureBoxes[i].Image = imageList1.Images[num[i]]; }
            }
        }//隨機骰子
        private void go()
        {
            for (int i = 0; i < 13; i++) N[i] = 0;
            for (int i = 0; i < 5; i++) if (num[i] == 1) N[0] += 1;
            for (int i = 0; i < 5; i++) if (num[i] == 2) N[1] += 2;
            for (int i = 0; i < 5; i++) if (num[i] == 3) N[2] += 3;
            for (int i = 0; i < 5; i++) if (num[i] == 4) N[3] += 4;
            for (int i = 0; i < 5; i++) if (num[i] == 5) N[4] += 5;
            for (int i = 0; i < 5; i++) if (num[i] == 6) N[5] += 6;
            int a = 0, d = 0;
            bool b = false, c = false;
            for (int i = 0; i < 5; i++)
            {
                a = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (num[i] == num[j] && i != j) { a++; d = num[i]; }
                    if (a == 2) b = true; if (a == 3) c = true;
                }
            }
            a = 0;
            if (b == true) N[7] = num[0] + num[1] + num[2] + num[3] + num[4];
            if (c == true) N[8] = num[0] + num[1] + num[2] + num[3] + num[4];
            if (b == true)
            {
                for (int j = 0; j < 5; j++) for (int i = 0; i < 5; i++)
                        if (num[j] == num[i] && j != i && num[j] != d) N[9] = 25;
            }
            bool[] vs = new bool[6];
            for (int j = 0; j < 5; j++)
            {
                if (num[j] == 1) vs[0] = true;
                if (num[j] == 2) vs[1] = true;
                if (num[j] == 3) vs[2] = true;
                if (num[j] == 4) vs[3] = true;
                if (num[j] == 5) vs[4] = true;
                if (num[j] == 6) vs[5] = true;
            }
            if (vs[0] == true && vs[1] && vs[2] && vs[3]) N[10] = 30;
            if (vs[1] == true && vs[2] && vs[3] && vs[4]) N[10] = 30;
            if (vs[2] == true && vs[3] && vs[4] && vs[5]) N[10] = 30;
            if (vs[0] == true && vs[1] && vs[2] && vs[3] && vs[4]) N[11] = 40;
            if (vs[1] == true && vs[2] && vs[3] && vs[4] && vs[5]) N[11] = 40;
            for (int i = 0; i < 4; i++) if (num[4] == num[i]) a++;
            if (a == 4) N[12] = 50;
            N[13] = num[0] + num[1] + num[2] + num[3] + num[4];
            if (game % 2 == 0)
            {
                if (label11.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label11.ForeColor = System.Drawing.Color.Silver;
                    label11.Text = N[0].ToString();
                }
                if (label12.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label12.ForeColor = System.Drawing.Color.Silver;
                    label12.Text = N[1].ToString();
                }
                if (label13.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label13.ForeColor = System.Drawing.Color.Silver;
                    label13.Text = N[2].ToString();
                }
                if (label14.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label14.ForeColor = System.Drawing.Color.Silver;
                    label14.Text = N[3].ToString();
                }
                if (label15.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label15.ForeColor = System.Drawing.Color.Silver;
                    label15.Text = N[4].ToString();
                }
                if (label16.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label16.ForeColor = System.Drawing.Color.Silver;
                    label16.Text = N[5].ToString();
                }
                if (label18.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label18.ForeColor = System.Drawing.Color.Silver;
                    label18.Text = N[7].ToString();
                }
                if (label19.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label19.ForeColor = System.Drawing.Color.Silver;
                    label19.Text = N[8].ToString();
                }
                if (label110.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label110.ForeColor = System.Drawing.Color.Silver;
                    label110.Text = N[9].ToString();
                }
                if (label111.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label111.ForeColor = System.Drawing.Color.Silver;
                    label111.Text = N[10].ToString();
                }
                if (label112.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label112.ForeColor = System.Drawing.Color.Silver;
                    label112.Text = N[11].ToString();
                }
                if (label113.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label113.ForeColor = System.Drawing.Color.Silver;
                    label113.Text = N[12].ToString();
                }
                if (label114.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label114.ForeColor = System.Drawing.Color.Silver;
                    label114.Text = N[13].ToString();
                }
            }
            else
            {
                if (label21.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label21.ForeColor = System.Drawing.Color.Silver;
                    label21.Text = N[0].ToString();
                }
                if (label22.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label22.ForeColor = System.Drawing.Color.Silver;
                    label22.Text = N[1].ToString();
                }
                if (label23.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label23.ForeColor = System.Drawing.Color.Silver;
                    label23.Text = N[2].ToString();
                }
                if (label24.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label24.ForeColor = System.Drawing.Color.Silver;
                    label24.Text = N[3].ToString();
                }
                if (label25.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label25.ForeColor = System.Drawing.Color.Silver;
                    label25.Text = N[4].ToString();
                }
                if (label26.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label26.ForeColor = System.Drawing.Color.Silver;
                    label26.Text = N[5].ToString();
                }
                if (label28.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label28.ForeColor = System.Drawing.Color.Silver;
                    label28.Text = N[7].ToString();
                }
                if (label29.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label29.ForeColor = System.Drawing.Color.Silver;
                    label29.Text = N[8].ToString();
                }
                if (label210.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label210.ForeColor = System.Drawing.Color.Silver;
                    label210.Text = N[9].ToString();
                }
                if (label211.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label211.ForeColor = System.Drawing.Color.Silver;
                    label211.Text = N[10].ToString();
                }
                if (label212.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label212.ForeColor = System.Drawing.Color.Silver;
                    label212.Text = N[11].ToString();
                }
                if (label213.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label213.ForeColor = System.Drawing.Color.Silver;
                    label213.Text = N[12].ToString();
                }
                if (label214.BackColor == System.Drawing.Color.WhiteSmoke)
                {
                    label214.ForeColor = System.Drawing.Color.Silver;
                    label214.Text = N[13].ToString();
                }
            }
        }//分數計算
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.ForeColor == System.Drawing.Color.LimeGreen)
            { stop[0] = true; button2.ForeColor = System.Drawing.Color.Red; button2.Text = "刪除"; }
            else
            { stop[0] = false; button2.ForeColor = System.Drawing.Color.LimeGreen; button2.Text = "保留"; }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.ForeColor == System.Drawing.Color.LimeGreen)
            { stop[1] = true; button3.ForeColor = System.Drawing.Color.Red; button3.Text = "刪除"; }
            else
            { stop[1] = false; button3.ForeColor = System.Drawing.Color.LimeGreen; button3.Text = "保留"; }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.ForeColor == System.Drawing.Color.LimeGreen)
            { stop[2] = true; button4.ForeColor = System.Drawing.Color.Red; button4.Text = "刪除"; }
            else
            { stop[2] = false; button4.ForeColor = System.Drawing.Color.LimeGreen; button4.Text = "保留"; }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.ForeColor == System.Drawing.Color.LimeGreen)
            { stop[3] = true; button5.ForeColor = System.Drawing.Color.Red; button5.Text = "刪除"; }
            else
            { stop[3] = false; button5.ForeColor = System.Drawing.Color.LimeGreen; button5.Text = "保留"; }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.ForeColor == System.Drawing.Color.LimeGreen)
            { stop[4] = true; button6.ForeColor = System.Drawing.Color.Red; button6.Text = "刪除"; }
            else
            { stop[4] = false; button6.ForeColor = System.Drawing.Color.LimeGreen; button6.Text = "保留"; }
        }

        private void de()
        {
            if (label11.BackColor == System.Drawing.Color.WhiteSmoke) label11.Text = "";
            if (label12.BackColor == System.Drawing.Color.WhiteSmoke) label12.Text = "";
            if (label13.BackColor == System.Drawing.Color.WhiteSmoke) label13.Text = "";
            if (label14.BackColor == System.Drawing.Color.WhiteSmoke) label14.Text = "";
            if (label15.BackColor == System.Drawing.Color.WhiteSmoke) label15.Text = "";
            if (label16.BackColor == System.Drawing.Color.WhiteSmoke) label16.Text = "";
            if (label18.BackColor == System.Drawing.Color.WhiteSmoke) label18.Text = "";
            if (label19.BackColor == System.Drawing.Color.WhiteSmoke) label19.Text = "";
            if (label110.BackColor == System.Drawing.Color.WhiteSmoke) label110.Text = "";
            if (label111.BackColor == System.Drawing.Color.WhiteSmoke) label111.Text = "";
            if (label112.BackColor == System.Drawing.Color.WhiteSmoke) label112.Text = "";
            if (label113.BackColor == System.Drawing.Color.WhiteSmoke) label113.Text = "";
            if (label114.BackColor == System.Drawing.Color.WhiteSmoke) label114.Text = "";
            if (label21.BackColor == System.Drawing.Color.WhiteSmoke) label21.Text = "";
            if (label22.BackColor == System.Drawing.Color.WhiteSmoke) label22.Text = "";
            if (label23.BackColor == System.Drawing.Color.WhiteSmoke) label23.Text = "";
            if (label24.BackColor == System.Drawing.Color.WhiteSmoke) label24.Text = "";
            if (label25.BackColor == System.Drawing.Color.WhiteSmoke) label25.Text = "";
            if (label26.BackColor == System.Drawing.Color.WhiteSmoke) label26.Text = "";
            if (label28.BackColor == System.Drawing.Color.WhiteSmoke) label28.Text = "";
            if (label29.BackColor == System.Drawing.Color.WhiteSmoke) label29.Text = "";
            if (label210.BackColor == System.Drawing.Color.WhiteSmoke) label210.Text = "";
            if (label211.BackColor == System.Drawing.Color.WhiteSmoke) label211.Text = "";
            if (label212.BackColor == System.Drawing.Color.WhiteSmoke) label212.Text = "";
            if (label213.BackColor == System.Drawing.Color.WhiteSmoke) label213.Text = "";
            if (label214.BackColor == System.Drawing.Color.WhiteSmoke) label214.Text = "";
            label115.Text = player[0].ToString();
            if (player2[0] >= 63) label17.Text = "63 / 63";
            else label17.Text = player2[0].ToString() + " / 63";
            label215.Text = player[1].ToString();
            if (player2[1] >= 63) label27.Text = "63 / 63";
            else label27.Text = player2[1].ToString() + " / 63";
            for (int i = 0; i < 5; i++) stop[i] = false;
            button2.ForeColor = System.Drawing.Color.LimeGreen;
            button2.Text = "保留";
            button3.ForeColor = System.Drawing.Color.LimeGreen;
            button3.Text = "保留";
            button4.ForeColor = System.Drawing.Color.LimeGreen;
            button4.Text = "保留";
            button5.ForeColor = System.Drawing.Color.LimeGreen;
            button5.Text = "保留";
            button6.ForeColor = System.Drawing.Color.LimeGreen;
            button6.Text = "保留";
        }
        private void p2()
        {
            if (vs1[0] == false) { if (player2[0] >= 63) { player[0] += 35; vs1[0] = true; } }
            if (vs1[1] == false) { if (player2[1] >= 63) { player[1] += 35; vs1[1] = true; } }
        }//紅利加分
        private void games()
        {
            game -= 1; play = 2;
            label1.Text = "剩餘次數：" + play.ToString() + " / 3";
            if (game > 0)
            {
                if (game % 2 == 0) { label2.Text = "目前玩家：玩家1"; }
                else { label2.Text = "目前玩家：玩家2"; }
            }
            if (game == 0)
            {
                label1.Text = "剩餘次數：0 / 3";
                label2.Text = "目前玩家：";
                if (player[0] > player[1]) MessageBox.Show("「玩家1」贏了!!!");
                else if (player[0] < player[1]) MessageBox.Show("「玩家2」贏了!!!");
                else if (player[0] == player[1]) MessageBox.Show("平手!真不可思議!");
                Form1.Gamer[Form1.Gamer2[0]] += player[0];
                Form1.Gamer[Form1.Gamer2[1]] += player[1];
                Form1.Gamer3[Form1.Gamer2[0]]++;
                Form1.Gamer3[Form1.Gamer2[1]]++;
            }
        }
        private void label11_Click(object sender, EventArgs e)
        {
            if (label11.BackColor == System.Drawing.Color.WhiteSmoke && label11.Text != "")
            {
                label11.BackColor = System.Drawing.Color.LemonChiffon;
                label11.ForeColor = System.Drawing.Color.Black;
                player[0] += N[0];
                player2[0] += N[0];
                p2(); de(); ran(); games(); go();
            }

        }
        private void label12_Click(object sender, EventArgs e)
        {
            if (label12.BackColor == System.Drawing.Color.WhiteSmoke && label12.Text != "")
            {
                label12.BackColor = System.Drawing.Color.LemonChiffon;
                label12.ForeColor = System.Drawing.Color.Black;
                player[0] += N[1];
                player2[0] += N[1];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label13_Click(object sender, EventArgs e)
        {
            if (label13.BackColor == System.Drawing.Color.WhiteSmoke && label13.Text != "")
            {
                label13.BackColor = System.Drawing.Color.LemonChiffon;
                label13.ForeColor = System.Drawing.Color.Black;
                player[0] += N[2];
                player2[0] += N[2];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label14_Click(object sender, EventArgs e)
        {
            if (label14.BackColor == System.Drawing.Color.WhiteSmoke && label14.Text != "")
            {
                label14.BackColor = System.Drawing.Color.LemonChiffon;
                label14.ForeColor = System.Drawing.Color.Black;
                player[0] += N[3];
                player2[0] += N[3];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label15_Click(object sender, EventArgs e)
        {
            if (label15.BackColor == System.Drawing.Color.WhiteSmoke && label15.Text != "")
            {
                label15.BackColor = System.Drawing.Color.LemonChiffon;
                label15.ForeColor = System.Drawing.Color.Black;
                player[0] += N[4];
                player2[0] += N[4];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label16_Click(object sender, EventArgs e)
        {
            if (label16.BackColor == System.Drawing.Color.WhiteSmoke && label16.Text != "")
            {
                label16.BackColor = System.Drawing.Color.LemonChiffon;
                label16.ForeColor = System.Drawing.Color.Black;
                player[0] += N[5];
                player2[0] += N[5];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label18_Click(object sender, EventArgs e)
        {
            if (label18.BackColor == System.Drawing.Color.WhiteSmoke && label18.Text != "")
            {
                label18.BackColor = System.Drawing.Color.LemonChiffon;
                label18.ForeColor = System.Drawing.Color.Black;
                player[0] += N[7];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label19_Click(object sender, EventArgs e)
        {
            if (label19.BackColor == System.Drawing.Color.WhiteSmoke && label19.Text != "")
            {
                label19.BackColor = System.Drawing.Color.LemonChiffon;
                label19.ForeColor = System.Drawing.Color.Black;
                player[0] += N[8];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label110_Click(object sender, EventArgs e)
        {
            if (label110.BackColor == System.Drawing.Color.WhiteSmoke && label110.Text != "")
            {
                label110.BackColor = System.Drawing.Color.LemonChiffon;
                label110.ForeColor = System.Drawing.Color.Black;
                player[0] += N[9];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label111_Click(object sender, EventArgs e)
        {
            if (label111.BackColor == System.Drawing.Color.WhiteSmoke && label111.Text != "")
            {
                label111.BackColor = System.Drawing.Color.LemonChiffon;
                label111.ForeColor = System.Drawing.Color.Black;
                player[0] += N[10];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label112_Click(object sender, EventArgs e)
        {
            if (label112.BackColor == System.Drawing.Color.WhiteSmoke && label112.Text != "")
            {
                label112.BackColor = System.Drawing.Color.LemonChiffon;
                label112.ForeColor = System.Drawing.Color.Black;
                player[0] += N[11];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label113_Click(object sender, EventArgs e)
        {
            if (label113.BackColor == System.Drawing.Color.WhiteSmoke && label113.Text != "")
            {
                label113.BackColor = System.Drawing.Color.LemonChiffon;
                label113.ForeColor = System.Drawing.Color.Black;
                player[0] += N[12];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label114_Click(object sender, EventArgs e)
        {
            if (label114.BackColor == System.Drawing.Color.WhiteSmoke && label114.Text != "")
            {
                label114.BackColor = System.Drawing.Color.LemonChiffon;
                label114.ForeColor = System.Drawing.Color.Black;
                player[0] += N[13];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label21_Click(object sender, EventArgs e)
        {
            if (label21.BackColor == System.Drawing.Color.WhiteSmoke && label21.Text != "")
            {
                label21.BackColor = System.Drawing.Color.LemonChiffon;
                label21.ForeColor = System.Drawing.Color.Black;
                player[1] += N[0];
                player2[1] += N[0];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label22_Click(object sender, EventArgs e)
        {
            if (label22.BackColor == System.Drawing.Color.WhiteSmoke && label22.Text != "")
            {
                label22.BackColor = System.Drawing.Color.LemonChiffon;
                label22.ForeColor = System.Drawing.Color.Black;
                player[1] += N[1];
                player2[1] += N[1];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label23_Click(object sender, EventArgs e)
        {
            if (label23.BackColor == System.Drawing.Color.WhiteSmoke && label23.Text != "")
            {
                label23.BackColor = System.Drawing.Color.LemonChiffon;
                label23.ForeColor = System.Drawing.Color.Black;
                player[1] += N[2];
                player2[1] += N[2];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label24_Click(object sender, EventArgs e)
        {
            if (label24.BackColor == System.Drawing.Color.WhiteSmoke && label24.Text != "")
            {
                label24.BackColor = System.Drawing.Color.LemonChiffon;
                label24.ForeColor = System.Drawing.Color.Black;
                player[1] += N[3];
                player2[1] += N[3];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label25_Click(object sender, EventArgs e)
        {
            if (label25.BackColor == System.Drawing.Color.WhiteSmoke && label25.Text != "")
            {
                label25.BackColor = System.Drawing.Color.LemonChiffon;
                label25.ForeColor = System.Drawing.Color.Black;
                player[1] += N[4];
                player2[1] += N[4];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label26_Click(object sender, EventArgs e)
        {
            if (label26.BackColor == System.Drawing.Color.WhiteSmoke && label26.Text != "")
            {
                label26.BackColor = System.Drawing.Color.LemonChiffon;
                label26.ForeColor = System.Drawing.Color.Black;
                player[1] += N[5];
                player2[1] += N[5];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label28_Click(object sender, EventArgs e)
        {
            if (label28.BackColor == System.Drawing.Color.WhiteSmoke && label28.Text != "")
            {
                label28.BackColor = System.Drawing.Color.LemonChiffon;
                label28.ForeColor = System.Drawing.Color.Black;
                player[1] += N[7];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label29_Click(object sender, EventArgs e)
        {
            if (label29.BackColor == System.Drawing.Color.WhiteSmoke && label29.Text != "")
            {
                label29.BackColor = System.Drawing.Color.LemonChiffon;
                label29.ForeColor = System.Drawing.Color.Black;
                player[1] += N[8];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label210_Click(object sender, EventArgs e)
        {
            if (label210.BackColor == System.Drawing.Color.WhiteSmoke && label210.Text != "")
            {
                label210.BackColor = System.Drawing.Color.LemonChiffon;
                label210.ForeColor = System.Drawing.Color.Black;
                player[1] += N[9];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label211_Click(object sender, EventArgs e)
        {
            if (label211.BackColor == System.Drawing.Color.WhiteSmoke && label211.Text != "")
            {
                label211.BackColor = System.Drawing.Color.LemonChiffon;
                label211.ForeColor = System.Drawing.Color.Black;
                player[1] += N[10];
                p2(); de(); ran(); games(); go();
            }
        }


        private void label212_Click(object sender, EventArgs e)
        {
            if (label212.BackColor == System.Drawing.Color.WhiteSmoke && label212.Text != "")
            {
                label212.BackColor = System.Drawing.Color.LemonChiffon;
                label212.ForeColor = System.Drawing.Color.Black;
                player[1] += N[11];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label213_Click(object sender, EventArgs e)
        {
            if (label213.BackColor == System.Drawing.Color.WhiteSmoke && label213.Text != "")
            {
                label213.BackColor = System.Drawing.Color.LemonChiffon;
                label213.ForeColor = System.Drawing.Color.Black;
                player[1] += N[12];
                p2(); de(); ran(); games(); go();
            }
        }
        private void label214_Click(object sender, EventArgs e)
        {
            if (label214.BackColor == System.Drawing.Color.WhiteSmoke && label214.Text != "")
            {
                label214.BackColor = System.Drawing.Color.LemonChiffon;
                label214.ForeColor = System.Drawing.Color.Black;
                player[1] += N[13];
                p2(); de(); ran(); games(); go();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); form2.Visible = true; timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bug[4] != 0)
            {
                for (int i = 0; i < bug.Length; i++) { pictureBoxes[i].Image = imageList1.Images[bug[i]];num[i] = bug[i]; bug[i] = 0;  }
            }
            if (T != 0) { T = 0; timer1.Enabled = false; }
            go();
        }
    }
}
