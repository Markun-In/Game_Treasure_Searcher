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

namespace WindowsFormsApplication7
{
    public partial class Main : Form
    {
        static public int areasize = 12;
        static public int blockSize = 70;
        static public Man man; 
        static public Monster[] mon;
        static public Sunduk [] sund;
        static public Wall [] wall;
        static public int life = 3;
        static public int Minisund;
        static public Timer timer1;
        static public int home_enamble = 0;
        static public System.Windows.Forms.Label label6;
        static public int level = 1;
        static public Timer timer4;

        public Main()
        {
            MaximizeBox = false; 
            InitializeComponent();
            label6 = new System.Windows.Forms.Label();
            this.panel2.Controls.Add(label6);
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label6.Location = new System.Drawing.Point(442, 2);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(24, 25);
            label6.TabIndex = 0;
            panel3.Location = new Point(0, 0);
            panel2.Location = new Point(0, 0);
            panel3.Visible = true;
            timer1 = new Timer();
            timer4 = new Timer();
            timer4.Interval = 1000;
            timer4.Enabled = false;
            timer1.Interval = 350;
            timer1.Enabled = false;
            timer1.Tick += timer1_Tick;
            timer4.Tick += timer4_Tick;
            panel1.Location = new Point(0, 34);
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(man.image, man.x * blockSize, man.y * blockSize, blockSize, blockSize);
            for (int i = 0; i < 5; i++)
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
        public class Man
        {
            public int x, y;
            public Image image;
            public Man(int i, int j)
            {
                x = i;
                y = j;
                image = Properties.Resources.Down_1_;
            }
            public void Left()
            {
                image = Properties.Resources.Left_2_;
                if (x > 0)
                    x--;
                for (int i = 0; i < wall.Length; i++)
                    if (x == wall[i].x && y == wall[i].y)
                        x++;
                for (int i = 0; i < mon.Length; i++)
                    if (mon[i] != null) 
                        if (x == mon[i].x && y == mon[i].y) 
                            life--;
                for (int i = 0; i < sund.Length; i++)
                    if (sund[i] != null)
                        if (x == sund[i].x && y == sund[i].y)
                        {
                            sund[i] = null;
                            Minisund--;
                            if (Minisund == 0) 
                                Levels.Next_level();
                        }
            }
            public void Right()
            {
                image = Properties.Resources.Right_3_;
                if (x < Main.areasize)
                    x++;
                for (int i = 0; i < wall.Length; i++)
                    if (x == wall[i].x && y == wall[i].y)
                        x--;
                for (int i = 0; i < 5; i++)
                    if (x == mon[i].x && y == mon[i].y)
                        life--;
                for (int i = 0; i < sund.Length; i++)
                    if (sund[i] != null) 
                        if (x == sund[i].x && y == sund[i].y) 
                        { 
                            sund[i] = null; 
                            Minisund--; 
                            if (Minisund == 0)
                                Levels.Next_level();
                        }
            }
            public void Down()
            {
                image = Properties.Resources.Down_1_;
                if (y < Main.areasize)
                    y++;
                for (int i = 0; i < wall.Length; i++)
                    if (x == wall[i].x && y == wall[i].y)
                        y--; 
                for (int i = 0; i < 5; i++)
                    if (x == mon[i].x && y == mon[i].y)
                        life--;
                for (int i = 0; i < sund.Length; i++)
                    if (sund[i] != null) 
                        if (x == sund[i].x && y == sund[i].y) 
                        { 
                            sund[i] = null; 
                            Minisund--; 
                            if (Minisund == 0)
                                Levels.Next_level();
                        }
            }
            public void Up()
            {
                image = Properties.Resources.Up_4_;
                if (y > 0)
                    y--;
                for (int i = 0; i < wall.Length; i++)
                    if (x == wall[i].x && y == wall[i].y) 
                        y++;
                for (int i = 0; i < 5; i++)
                    if (mon[i] != null) 
                        if (x == mon[i].x && y == mon[i].y) 
                            life--;
                for (int i = 0; i < sund.Length; i++)
                   if (sund[i] != null) 
                       if (x == sund[i].x && y == sund[i].y) 
                       { 
                           sund[i] = null; 
                           Minisund--; 
                           if (Minisund == 0) 
                               Levels.Next_level();
                       }
            }
        }
        public class Monster
        {
            public Image image;
            public int x, y;
            public Monster(int a, int b)
            {
                x = a;
                y = b;
                image = Properties.Resources.Mon_down;
            }
            public Monster()
            {
                Random r = new Random();
                do
                {
                    x = r.Next(Main.areasize);
                    y = r.Next(Main.areasize);
                } while(move_ok(x,y) == true);
                image = Properties.Resources.Mon_down;
            }

            bool move_ok(int a, int b)
            {
                if (a == 6 && b == 6)
                    return true;
                for (int i = 0; i < 5; i++)
                    if (mon[i] != null)
                        if (mon[i].x == a && mon[i].y == b)
                            return true;
                if (man.x == a && man.y == b)
                    return true;
                for (int i = 0; i < sund.Length; i++)
                    if (sund[i] != null)
                        if (sund[i].x == a && sund[i].y == b)
                            return true;
                for (int n = 0; n < wall.Length; n++)
                    if (wall[n] != null)
                        if (a == wall[n].x && b == wall[n].y)
                            return true;
                if (a < 0 || b < 0 || a > 9 || b > 9)
                    return true;
                return false;
            }
            public void Left()
            {
                image = Properties.Resources.Mon_left;
                if (move_ok(x - 1, y) == false)
                    x--;
                if (man.x == x && man.y == y)
                    life--;
            }
            public void Right()
            {
                image = Properties.Resources.Mon_right;
                if (move_ok(x + 1, y) == false)
                    x++;
                if (man.x == x && man.y == y)
                    life--;
            }
            public void Down()
            {
                image = Properties.Resources.Mon_right;
                if (move_ok(x, y+1) == false)
                    y++;
                if (man.x == x && man.y == y)
                    life--;
            }
            public void Up()
            {
                image = Properties.Resources.Mon_right;
                if (move_ok(x, y - 1) == false)
                    y--;
                if (man.x == x && man.y == y)
                    life--;
            }
            public void Mon_move()
            {
                Random r = new Random();
                int c = r.Next(x * 2 + y * 3 + x + 8 + y) % 4;
                if (c == 0)
                    Right();
                if (c == 1)
                    Left();
                if (c == 2)
                    Up();
                if (c == 3)
                    Down();
            }
        }
        public class Wall
        {
            public Image image;
            public int x, y;
            public Wall(int a, int b)
            {
                x = a;
                y = b;
                image = Properties.Resources.hgrtfdtetrd;
            }   

            public Wall()
            {
                Random r = new Random();
                do
                {
                    x = r.Next(Main.areasize);
                    y = r.Next(Main.areasize);
                } while (move_ok(x, y) == true);
                image = Properties.Resources.hgrtfdtetrd;
            }

            bool move_ok(int n, int h)
            {
                for (int i = 0; i < sund.Length; i++)
                    if (sund[i] != null)
                        if (sund[i].x == n && sund[i].y == h)
                            return true;
                if (man.x == n && man.y == h)
                    return true;
                for (int i = 0; i < 5; i++)
                    if(mon[i] != null) 
                        if (mon[i].x == n && mon[i].y == h) 
                            return true;
                for (int i = 0; i < wall.Length; i++) 
                    if(wall[i] != null) 
                        if (wall[i].x == n && wall[i].y == h) 
                            return true;
                return false;
            }
        }
        public class Sunduk
        {
            public Image image;
            public int x, y;
            public Sunduk(int a, int b)
            {
                x = a;
                y = b;
                image = Properties.Resources.Treasure;
            }

            public Sunduk()
            {
                Random r = new Random();
                do
                {
                    x = r.Next(Main.areasize);
                    y = r.Next(Main.areasize);
                } while(move_ok(x,y) == true);
                image = Properties.Resources.Treasure;
            }
            bool move_ok(int n, int h)
              {
                  for (int i = 0; i < 4; i++) 
                      if (sund[i] != null)
                          if (sund[i].x == n && sund[i].y == h)
                              return true;
                  if (man.x == n && man.y == h)
                      return true;
                  for (int i = 0; i < 5; i++)
                      if (mon[i] != null)
                          if (mon[i].x == n && mon[i].y == h)
                              return true;
                  for (int i = 1; i < 10; i++) 
                      if (wall[i].x == n && wall[i].y == h) 
                          return true;
                  return false;
              }
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
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (home_enamble < 10)
                home_enamble++;
            label6.Text = home_enamble.ToString();
            if (home_enamble == 10 && man.x == 6 && man.y == 6 && life < 3)
            {
                life++; 
                home_enamble = 0;
                label6.Text = home_enamble.ToString();
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
            for (int i = 0; i < 5; i++)
                mon[i].Mon_move();
            panel1.Refresh();
            panel2.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            timer1.Enabled = true;
            timer4.Enabled = true;
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
            Save s = new Save("Сохранение", "Под каким профилем сохранить?", "Сохранить");
            s.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Save s = new Save("Загрузка", "Какой профиль загрузить?", "Загрузить");
            s.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Вы действительно хотите выйти ?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result1 == DialogResult.Yes)
                Close();
            else
                return;
        }

        private void label5_Click(object sender, EventArgs e)   // Нажатие на кнопку "Новая игра"
        {
            Levels.Level3();
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
