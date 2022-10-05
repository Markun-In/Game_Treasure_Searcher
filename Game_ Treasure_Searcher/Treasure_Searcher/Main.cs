using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace Treasure_Searcher
{
    public partial class Main : Form
    {
        public static int areaSize = 12;
        public static int blockSize = 70;
        public static Man man;
        public static Monster[] mon;
        public static Sunduk[] sund;
        public static Wall[] wall;
        public static int life = 3;
        public static int Minisund;
        public static Timer timer1;
        public static int home_enamble = 0;
        public static Label label6;
        public static int level = 1;
        public static Timer timer4;

        public Main()
        {
            InitializeComponent();
            label6 = new Label();
            panel2.Controls.Add(label6);
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label6.Location = new Point(442, 2);
            label6.Name = "home_enable";
            label6.Size = new Size(24, 25);
            label6.TabIndex = 0;
            panel3.Location = new Point(0, 0);
            panel2.Location = new Point(0, 0);
            panel3.Visible = true;
            timer4 = new Timer();
            timer4.Interval = 1000;
            timer4.Enabled = false;
            timer4.Tick += timer4_Tick;
            timer1 = new Timer();
            timer1.Interval = 350;
            timer1.Enabled = false;
            timer1.Tick += timer1_Tick;
            panel1.Location = new Point(0, 34);
            MaximizeBox = false;
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(man.image, man.x * blockSize, man.y * blockSize, blockSize, blockSize);
            for (int i = 0; i < mon.Length; i++)
                e.Graphics.DrawImage(mon[i].image, mon[i].x * blockSize, mon[i].y * blockSize, blockSize, blockSize);
            for (int i = 0; i < sund.Length; i++)
                if (sund[i] != null)
                    e.Graphics.DrawImage(sund[i].image, sund[i].x * blockSize, sund[i].y * blockSize, blockSize, blockSize);
            for (int i = 0; i < wall.Length; i++)
                if (wall[i] != null)
                    e.Graphics.DrawImage(wall[i].image, wall[i].x * blockSize, wall[i].y * blockSize, blockSize, blockSize);
            e.Graphics.DrawImage(Properties.Resources.home, 6*blockSize, 6*blockSize, blockSize, blockSize);
        }
        
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (life >= 1)
                e.Graphics.DrawImage(Properties.Resources.Life, 17, 2, 30, 30);
            if (life >= 2)
                e.Graphics.DrawImage(Properties.Resources.Life, 44, 2, 30, 30);
            if (life >= 3)
                e.Graphics.DrawImage(Properties.Resources.Life, 71, 2, 30, 30);
            if (Minisund >= 1)
                e.Graphics.DrawImage(Properties.Resources.mini_sunduk, 850, 2, 30, 30);
            if (Minisund >= 2)
                e.Graphics.DrawImage(Properties.Resources.mini_sunduk, 810, 2, 30, 30);
            if (Minisund >= 3)
                e.Graphics.DrawImage(Properties.Resources.mini_sunduk, 770, 2, 30, 30); 
            if (Minisund >= 4)
                e.Graphics.DrawImage(Properties.Resources.mini_sunduk, 730, 2, 30, 30);
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (timer1.Enabled && life >= 1)
                {
                        timer1.Enabled = false;
                        timer4.Enabled = false;
                        panel3.Visible = true;
                }
                else
                {
                    if (life >= 1) 
                    {
                        timer4.Enabled = true;
                        timer1.Enabled = true;
                        panel3.Visible = false;
                    }
                    else
                    {
                        timer1.Enabled = false;
                        timer4.Enabled = false;
                        panel3.Visible = true;
                    }
                }
                if (life <= 0) 
                   label5.Visible = true;
            }
            if (timer1.Enabled)
            {
                switch (e.KeyCode) 
                {
                    case Keys.Left: case Keys.A:
                        man.Left();
                        break;
                    case Keys.Right: case Keys.D:
                        man.Right();
                        break;
                    case Keys.Up: case Keys.W:
                        man.Up();
                        break;
                    case Keys.Down: case Keys.S:
                        man.Down();
                        break;
                }
                panel1.Refresh();
            }
        }
        private static void timer4_Tick(object sender, EventArgs e)
        {
            if (home_enamble < 10)
                home_enamble++;
            label6.Text = home_enamble.ToString();
            if (home_enamble == 10 && man.x == 6 && man.y == 6 && life < 3)
            {
                life++; 
                home_enamble = 0;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (life <= 0)
            {
                timer1.Enabled = false;
                timer4.Enabled = false;
                MessageBox.Show("Вы проиграли!");
            }
            for (int i = 0; i < mon.Length; i++)
                mon[i].Mon_move();
            panel1.Refresh();
            panel2.Refresh();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            label1.Visible = true;
            panel3.Visible = false;
            timer1.Enabled = true;
            timer4.Enabled = true;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Save save = new Save("Сохранение", "Под каким профилем сохранить?", "Сохранить");
            save.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Save load = new Save("Загрузка", "Какой профиль загрузить?", "Загрузить");
            load.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Вы действительно хотите выйти ?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result1 == DialogResult.Yes)
                Close();
            else
                return;
        }

        private void label5_Click(object sender, EventArgs e) // Нажатие на кнопку "Новая игра"
        {
            Levels.Level1();
            life = 3;
            home_enamble = 0;
            label1.Visible = true;
            panel3.Visible = false;
            timer1.Enabled = true;
            timer4.Enabled = true;
            label5.Visible = false;
            label2.Enabled = true;
        }
    }
}
