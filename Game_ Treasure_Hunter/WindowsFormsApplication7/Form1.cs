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
    public partial class Form1 : Form
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

        public Form1()
        {
            MaximizeBox = false; // Чтобы нельзя было разворачивать форму на весь экран
            InitializeComponent();
            label6 = new System.Windows.Forms.Label();
            this.panel2.Controls.Add(label6);
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label6.Location = new System.Drawing.Point(442, 2);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(24, 25);
            label6.TabIndex = 0;
            label6.Text = "0";
            panel3.Location = new Point(0, 0);
            panel2.Location = new Point(0, 0);
            panel3.Visible = true;
            timer1 = new Timer();
            timer4 = new Timer();
            timer4.Interval = 1000;
            timer4.Enabled = false;
            timer1.Interval = 250;
            timer1.Enabled = false;
            timer1.Tick += timer1_Tick;
            timer4.Tick += timer4_Tick;
            panel1.Location = new Point(0, 34);
            level1();
        }

        void randLavel()
        {
            man = new Man(6, 6);
            mon = new Monster[5];
            sund = new Sunduk[4];
            wall = new Wall[23];
            for (int i = 0; i < wall.Length; i++)
                wall[i] = new Wall();
            for (int i = 0; i < 5; i++)
                mon[i] = new Monster();
            for (int i = 0; i < 4; i++)
                sund[i] = new Sunduk();
        }

        void level1()
        {
            Minisund = 4;
            man = new Man(6, 6);
            mon = new Monster[5];
            sund = new Sunduk[4];
            wall = new Wall[23];
            mon[0] = new Monster(6, 9);
            mon[1] = new Monster(5, 4);
            mon[2] = new Monster(7, 10);
            mon[3] = new Monster(3, 6);
            mon[4] = new Monster(2, 4);
            sund[0] = new Sunduk(7, 9);
            sund[1] = new Sunduk(8, 5);
            sund[2] = new Sunduk(5, 1);
            sund[3] = new Sunduk(2, 6);
            wall[0] = new Wall(1, 1);
            wall[1] = new Wall(2, 2);
            wall[2] = new Wall(3, 3);
            wall[3] = new Wall(4, 4);
            wall[4] = new Wall(5, 5);
            wall[5] = new Wall(12,13);
            wall[6] = new Wall(7, 7);
            wall[7] = new Wall(9, 9);
            wall[8] = new Wall(11, 11);
            wall[9] = new Wall(11, 1);
            wall[10] = new Wall(1, 11);
            wall[11] = new Wall(2, 10);
            wall[12] = new Wall(3, 9);
            wall[13] = new Wall(4, 8);
            wall[14] = new Wall(5, 7);
            wall[15] = new Wall(7, 5);
            wall[16] = new Wall(8, 4);
            wall[17] = new Wall(9, 3);
            wall[18] = new Wall(10, 2);
            wall[19] = new Wall(7, 7);
            wall[20] = new Wall(8, 8);
            wall[21] = new Wall(9, 9);
            wall[22] = new Wall(10, 10);
        }

        static void level2()
        {
            Minisund = 4;
            man = new Man(6, 6);
            mon = new Monster[5];
            sund = new Sunduk[4];
            wall = new Wall[23];
            mon[0] = new Monster(1, 4);
            mon[1] = new Monster(9, 9);
            mon[2] = new Monster(10, 7);
            mon[3] = new Monster(9, 8);
            mon[4] = new Monster(9, 4);
            sund[0] = new Sunduk(0, 0);
            sund[1] = new Sunduk(12, 0);
            sund[2] = new Sunduk(12, 12);
            sund[3] = new Sunduk(0, 12);
            wall[0] = new Wall(2, 0);
            wall[1] = new Wall(1, 1);
            wall[2] = new Wall(1, 2);
            wall[3] = new Wall(11, 1);
            wall[4] = new Wall(11, 2);
            wall[5] = new Wall(10, 0);
            wall[6] = new Wall(0, 10);
            wall[7] = new Wall(1, 12);
            wall[8] = new Wall(12, 11);
            wall[9] = new Wall(11, 11);
            wall[10] = new Wall(10, 11);
            wall[11] = new Wall(6, 5);
            wall[12] = new Wall(5, 6);
            wall[13] = new Wall(7, 6);
            wall[14] = new Wall(8, 6);
            wall[15] = new Wall(5, 6);
            wall[16] = new Wall(4, 6);
            wall[17] = new Wall(3, 6);
            wall[18] = new Wall(2, 6);
            wall[19] = new Wall(1, 6);
            wall[20] = new Wall(9, 6);
            wall[21] = new Wall(10, 6);
            wall[22] = new Wall(11, 6);
        }

        static void level3()
        {
            Minisund = 4;
            man = new Man(6, 6);
            mon = new Monster[5];
            sund = new Sunduk[4];
            wall = new Wall[23];
            mon[0] = new Monster(1, 4);
            mon[1] = new Monster(9, 7);
            mon[2] = new Monster(2, 2);
            mon[3] = new Monster(11, 9);
            mon[4] = new Monster(4, 4);
            sund[0] = new Sunduk(0, 0);
            sund[1] = new Sunduk(12, 0);
            sund[2] = new Sunduk(12, 12);
            sund[3] = new Sunduk(0, 12);
            wall[0] = new Wall(1, 1);
            wall[1] = new Wall(3, 3);
            wall[2] = new Wall(2, 3);
            wall[3] = new Wall(8, 1);
            wall[4] = new Wall(6, 0);
            wall[5] = new Wall(12, 4);
            wall[6] = new Wall(2, 6);
            wall[7] = new Wall(3, 11);
            wall[8] = new Wall(7, 0);
            wall[9] = new Wall(9, 12);
            wall[10] = new Wall(1, 10);
            wall[11] = new Wall(12, 9);
            wall[12] = new Wall(6, 3);
            wall[13] = new Wall(11, 1);
            wall[14] = new Wall(10, 7);
            wall[15] = new Wall(5, 12);
            wall[16] = new Wall(12, 10);
            wall[17] = new Wall(12, 9);
            wall[18] = new Wall(5, 3);
            wall[19] = new Wall(8, 1);
            wall[20] = new Wall(5, 7);
            wall[21] = new Wall(6, 12);
            wall[22] = new Wall(4, 10);
        }
        
        static void level4() 
        {

        }

        static public void next_level()
        {
            level++;
            if (level == 5)
            {
                MessageBox.Show("Вы выйграли!");
                return;
            }
            
            timer4.Enabled = true;
            timer1.Enabled = true;
            if (level == 2)
                level2();
            if (level == 3)
                level3();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(man.image, man.x * blockSize, man.y * blockSize, blockSize, blockSize);
            for (int i = 0; i < 5; i++)
                e.Graphics.DrawImage(mon[i].image, mon[i].x * blockSize, mon[i].y * blockSize, blockSize, blockSize);
            for (int i = 0; i < 4; i++)
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
            public void left()
            {
                x--;
                image = Properties.Resources.Left_2_;
                if (x < 0)
                    x++;
                for (int i = 0; i < wall.Length; i++)
                    if(wall[i]!= null)
                if (x == wall[i].x && y == wall[i].y)
                {
                    x++;
                    return;
                }
                for (int i = 0; i < 5; i++)
                    if (mon[i] != null)
                    if (x == mon[i].x && y == mon[i].y)
                        life--;
                if (life == 0)
                {
                    timer1.Enabled = false;
                    timer4.Enabled = false;
                    MessageBox.Show("Вы проиграли!");
                }
                for (int i = 0; i < 4; i++)
                    if (sund[i] != null)
                        if (x == sund[i].x && y == sund[i].y)
                        {
                            sund[i] = null;
                            Minisund--;
                            if (Minisund == 0)
                            {
                                timer1.Enabled = false;
                                timer4.Enabled = false;
                                next_level();
                            }
                        }
                if (home_enamble == 10 && x == 6 && y == 6)
                {
                    life++;
                    home_enamble = 0;
                    if (home_enamble > 10)
                        home_enamble--;

                    label6.Text = home_enamble.ToString();
                    if (life > 3)
                    {
                        life--;
                    }
                }
                
            }
            public void right()
            {
                x++;
                image = Properties.Resources.Right_3_;
                if (x > Form1.areasize)
                    x--;
                for (int i = 0; i < wall.Length; i++)
                    if (wall[i] != null)
                if (x == wall[i].x && y == wall[i].y)
                {
                    x--;
                    return;
                }
                for (int i = 0; i < 5; i++)
                    if (x == mon[i].x && y == mon[i].y)
                        life--;
                if (life == 0)
                {
                    timer1.Enabled = false;
                    timer4.Enabled = false;
                    MessageBox.Show("Вы проиграли!");
                }
                for (int i = 0; i < 4; i++)
                    if (sund[i] != null)
                if (x == sund[i].x && y == sund[i].y)
                {
                    sund[i] = null;
                    Minisund--;
                    if (Minisund == 0)
                    {
                        timer1.Enabled = false;
                        timer4.Enabled = false;
                        next_level();
                    }
                }
                if (home_enamble == 10 && x == 6 && y == 6)
                {
                    life++;
                    home_enamble = 0;
                    if (home_enamble > 10)
                    {
                        home_enamble--;
                    }
                    label6.Text = home_enamble.ToString();
                    if (life > 3)
                    {
                        life--;
                    }
                }
            }
            public void down()
            {
                y++;
                image = Properties.Resources.Down_1_;
                if (y > Form1.areasize)
                    y--;
                for (int i = 0; i < wall.Length; i++)
                    if(wall[i]!= null)
                if (x == wall[i].x && y == wall[i].y)
                {
                    y--;
                    return;
                }
                for (int i = 0; i < 5; i++)
                    if (x == mon[i].x && y == mon[i].y)
                        life--;
                if (life == 0)
                {
                    timer1.Enabled = false;
                    timer4.Enabled = false;
                    MessageBox.Show("Вы проиграли!");
                }
                for (int i = 0; i < 4; i++)
                    if (sund[i] != null)
                if (x == sund[i].x && y == sund[i].y)
                {
                    sund[i] = null;
                    Minisund--;
                    if (Minisund == 0)
                    {
                        timer1.Enabled = false;
                        timer4.Enabled = false;
                        next_level();
                    }
                    
                }
                if (home_enamble == 10 && x == 6 && y == 6)
                {
                    life++;
                    home_enamble = 0;
                    if (home_enamble > 10)
                    {
                        home_enamble--;
                    }
                    label6.Text = home_enamble.ToString();
                    if (life > 3)
                    {
                        life--;
                    }
                }
            }
            public void up()
            {
                y--;
                image = Properties.Resources.Up_4_;
                if (y < 0)
                    y++;
                for (int i = 0; i < wall.Length; i++)
                    if (wall[i] != null)
                if (x == wall[i].x && y == wall[i].y)
                {
                    y++;
                    return;
                }
                for (int i = 0; i < 5; i++)
                    if (mon[i] != null)
                    if (x == mon[i].x && y == mon[i].y)
                        life--;
                if (life == 0)
                {
                    timer1.Enabled = false;
                    timer4.Enabled = false;
                    MessageBox.Show("Вы проиграли!");
                }
                for (int i = 0; i < 4; i++)
                   if (sund[i] != null)
                if (x == sund[i].x && y == sund[i].y)
                {
                    sund[i] = null;
                    Minisund--;
                    if (Minisund == 0)
                    {
                        timer1.Enabled = false;
                        timer4.Enabled = false;
                        next_level();
                    }
                    
                }
                if (home_enamble == 10 && x == 6 && y == 6)
                {
                    life++;
                    home_enamble = 0;
                    if (home_enamble > 10)
                    {
                        home_enamble--;
                    }
                    label6.Location = new Point(362, 2);
                    label6.Text = home_enamble.ToString();
                    if (life > 3)
                    {
                        life--;
                    }
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
                    x = r.Next(Form1.areasize);
                    y = r.Next(Form1.areasize);
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
                for (int i = 0; i < 4; i++)
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
            public void left()
            {
                image = Properties.Resources.Mon_left;
                if (move_ok(x - 1, y) == false)
                    x--;
                if (man.x == x && man.y == y)
                {
                    life--;
                    if (life == 0)
                    {
                        timer1.Enabled = false;
                        timer4.Enabled = false;
                        MessageBox.Show("Вы проиграли!");
                    }
                }
            }
            public void right()
            {
                image = Properties.Resources.Mon_right;
                if (move_ok(x + 1, y) == false)
                    x++;
                if (man.x == x && man.y == y)
                {
                    life--;
                    if (life == 0)
                    {
                        timer1.Enabled = false;
                        timer4.Enabled = false;
                        MessageBox.Show("Вы проиграли!");
                    }
                }
            }
            public void down()
            {
                image = Properties.Resources.Mon_right;
                if (move_ok(x, y+1) == false)
                    y++;
                if (man.x == x && man.y == y)
                {
                    life--;
                    if (life == 0)
                    {
                        timer1.Enabled = false;
                        timer4.Enabled = false;
                        MessageBox.Show("Вы проиграли!");
                    }
                }
            }
            public void up()
            {
                image = Properties.Resources.Mon_right;
                if (move_ok(x, y - 1) == false)
                    y--;
                if (man.x == x && man.y == y)
                {
                    life--;
                    if (life == 0)
                    {
                        timer1.Enabled = false;
                        timer4.Enabled = false;
                        MessageBox.Show("Вы проиграли!");
                    }
                }
            }
            public void move()
            {
                
                Random r = new Random();
                int c = r.Next(x * 2 + y * 3 + x + 8 + y) % 4;
                if (c == 0)
                    right();
                if (c == 1)
                    left();
                if (c == 2)
                    up();
                if (c == 3)
                    down();
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
                    x = r.Next(Form1.areasize);
                    y = r.Next(Form1.areasize);
                } while (move_ok(x, y) == true);
                image = Properties.Resources.hgrtfdtetrd;
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
                    x = r.Next(Form1.areasize);
                    y = r.Next(Form1.areasize);
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
                if (timer1.Enabled && life >= 1) //Чтобы нельзя было попасть после сметри из меню в игру
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
                if (life <= 0) //При входе в меню после смерти можно начать только новую игру
                   label5.Visible = true;
                    
            }
            if (timer1.Enabled)
            {
                switch (e.KeyCode) // Управление персонажем
                {
                    case Keys.Left:
                        man.left();
                        break;
                    case Keys.Right:
                        man.right();
                        break;
                    case Keys.Up:
                        man.up();
                        break;
                    case Keys.Down:
                        man.down();
                        break;
                    case Keys.W:
                        man.up();
                        break;
                    case Keys.S:
                        man.down();
                        break;
                    case Keys.A:
                        man.left();
                        break;
                    case Keys.D:
                        man.right();
                        break;
                }
                panel1.Refresh();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            home_enamble++;
            if (home_enamble > 10)
                home_enamble--;
            label6.Text = home_enamble.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
                mon[i].move();
            panel1.Refresh();
            panel2.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Save s = new Save("Сохранение", "Под каким профилем сохранить?","Сохранить");
            s.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Save s = new Save("Загрузка", "Какой профиль загрузить?", "Загрузить");
            s.ShowDialog();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)   // Нажатие на кнопку "Новая игра"
        {
            level1();
            level = 1;
            life = 3;
            label1.Visible = true;
            panel3.Visible = false;
            timer1.Enabled = true;
            timer4.Enabled = true;
            label5.Visible = false;
        }

    }
}
