using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace 物件導向程式設計實習期末報告_張婷棻
{
    public partial class form6 : Form
    {
        public form6()
        {
            InitializeComponent();
        }

        PictureBox[] pictureBoxes = new PictureBox[5];//顯示骰子
        Label[] labels = new Label[14];//計分格玩家
        Label[] labels2 = new Label[14];//計分格AI
        int play = 2, game = 26;//剩餘次數，遊戲輪數
        int[] num = new int[5];//骰子大小
        bool[] stop = new bool[5];//保留
        int[] N = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//分數提示
        int[] player = new int[2] { 0, 0 };//總分
        int[] player2 = new int[2] { 0, 0 };//紅利加分
        bool[] vs1 = new bool[2];//紅利是否加分


        private void Form6_Load(object sender, EventArgs e)
        {
            //骰子顯示
            {
                pictureBoxes[0] = pictureBox1;
                pictureBoxes[1] = pictureBox2;
                pictureBoxes[2] = pictureBox3;
                pictureBoxes[3] = pictureBox4;
                pictureBoxes[4] = pictureBox5;
            }
            //計分格
            {
                labels[0] = label11;
                labels[1] = label12;
                labels[2] = label13;
                labels[3] = label14;
                labels[4] = label15;
                labels[5] = label16;
                labels[6] = label17;
                labels[7] = label18;
                labels[8] = label19;
                labels[9] = label110;
                labels[10] = label111;
                labels[11] = label112;
                labels[12] = label113;
                labels[13] = label114;

                labels2[0] = label21;
                labels2[1] = label22;
                labels2[2] = label23;
                labels2[3] = label24;
                labels2[4] = label25;
                labels2[5] = label26;
                labels2[6] = label27;
                labels2[7] = label28;
                labels2[8] = label29;
                labels2[9] = label210;
                labels2[10] = label211;
                labels2[11] = label212;
                labels2[12] = label213;
                labels2[13] = label214;
            }
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
                for(int i= 0; i < 14; i++)
                {
                    if (i != 6)
                    {
                        if (labels[i].BackColor == System.Drawing.Color.WhiteSmoke)
                        {
                            labels[i].ForeColor = System.Drawing.Color.Silver;
                            labels[i].Text = N[i].ToString();
                        }
                    }
                }
            }
            if (game % 2 == 1)
            {
                for (int i = 0; i < 14; i++)
                {
                    if (i != 6)
                    {
                        if (labels2[i].BackColor == System.Drawing.Color.WhiteSmoke)
                        {
                            labels2[i].ForeColor = System.Drawing.Color.Silver;
                            labels2[i].Text = N[i].ToString();
                        }
                    }
                }
                int big = 0;
                int big2 = 0;
                for (int i = 0; i < 14; i++)
                {
                    if (N[i] >= big && labels2[i].BackColor == System.Drawing.Color.WhiteSmoke)
                    {
                        big = N[i]; big2 = i;
                    }
                }
                if (big == 0 && play > 0)
                {
                    play -= 1;
                    label1.Text = "剩餘次數：" + play.ToString() + " / 3";
                    ran(); go();
                }
                else
                {
                    labels2[big2].BackColor = System.Drawing.Color.LemonChiffon;
                    labels2[big2].ForeColor = System.Drawing.Color.Black;
                    player[1] += N[big2];
                    if (big2 <= 5) { player2[1] += N[big2]; }
                    p2(); de(); ran(); games(); go();
                }
            }
        }
        private void p2()
        {
            if (vs1[0] == false) { if (player2[0] >= 63) { player[0] += 35; vs1[0] = true; } }
            if (vs1[1] == false) { if (player2[1] >= 63) { player[1] += 35; vs1[1] = true; } }
        }//紅利加分
        private void games()
        {
            if (game > 0) { game -= 1; play = 2; }
            label1.Text = "剩餘次數：" + play.ToString() + " / 3";
            if (game > 0)
            {
                if (game % 2 == 0) { label2.Text = "目前玩家：玩家1"; }
                else { label2.Text = "目前玩家：電腦AI"; }
            }
            if (game == 0)
            {
                label1.Text = "剩餘次數：0 / 3";
                label2.Text = "目前玩家：";
                if (player[0] > player[1]) MessageBox.Show("「玩家1」贏了!!!");
                else if (player[0] < player[1]) MessageBox.Show("「電腦AI」贏了!!!");
                else if (player[0] == player[1]) MessageBox.Show("平手!真不可思議!");
                Form1.Gamer[Form1.Gamer2[0]] += player[0];
                Form1.Gamer3[Form1.Gamer2[0]]++;
            }
        }

        private void de()
        {
            for (int i = 0; i < 14; i++) 
            { 
              if (labels[i].BackColor == System.Drawing.Color.WhiteSmoke) labels[i].Text = "";
              if (labels2[i].BackColor == System.Drawing.Color.WhiteSmoke) labels2[i].Text = "";
            }
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
    }
}
