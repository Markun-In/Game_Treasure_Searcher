using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static Treasure_Searcher.Main;

namespace Treasure_Searcher
{
    public partial class Save : Form
    {
        public Save(string s1, string s2, string s3)
        {
            InitializeComponent();
            Text = s1;
            label1.Text = s2;
            button1.Text = s3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Text == "Сохранение")
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите имя сохранения!", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (StreamWriter sw = new StreamWriter(textBox1.Text + ".txt")) 
                {
                    sw.WriteLine(Main.man.x);
                    sw.WriteLine(Main.man.y);
                    for (int i = 0; i < 5; i++)
                        sw.WriteLine(Main.mon[i].x);
                    for (int i = 0; i < 5; i++)
                        sw.WriteLine(Main.mon[i].y);
                    for (int i = 0; i <= Main.wall.Length - 1; i++)
                        sw.WriteLine(Main.wall[i].x);
                    for (int i = 0; i <= Main.wall.Length - 1; i++)
                        sw.WriteLine(Main.wall[i].y);
                    sw.WriteLine(Main.Minisund);
                    sw.WriteLine(Main.life);
                    for (int i = 0; i <  4; i++) { 
                        if (Main.sund[i] != null)
                        {
                            sw.WriteLine(Main.sund[i].x);
                            sw.WriteLine(Main.sund[i].y);
                        }
                    }
                    sw.WriteLine(Main.level);
                }
            }
             
            if (Text == "Загрузка")
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите имя сохранения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } 
                else if (!File.Exists(textBox1.Text + ".txt"))
                {
                    MessageBox.Show("Такого файла не существует! Попробуйте снова", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (StreamReader sr = new StreamReader(textBox1.Text + ".txt")) 
                {
                    Main.man.x = Convert.ToInt32(sr.ReadLine()); 
                    Main.man.y = Convert.ToInt32(sr.ReadLine());

                    for (int i = 0; i < 5; i++)
                        Main.mon[i].x = Convert.ToInt32(sr.ReadLine());
                    for (int i = 0; i < 5; i++)
                        Main.mon[i].y = Convert.ToInt32(sr.ReadLine());
                    for (int i = 0; i <= Main.wall.Length - 1; i++)
                        Main.wall[i].x = Convert.ToInt32(sr.ReadLine());
                    for (int i = 0; i <= Main.wall.Length - 1; i++)  
                        Main.wall[i].y = Convert.ToInt32(sr.ReadLine());

                    Main.Minisund = Convert.ToInt32(sr.ReadLine());
                    Main.life = Convert.ToInt32(sr.ReadLine());
                    Main.sund = new Main.Sunduk[Minisund];

                    for (int i = 0; i < Main.Minisund; i++)
                        Main.sund[i] = new Main.Sunduk(0 ,0);
                    
                    for (int i = 0; i < Minisund; i++)
                        if (Main.sund[i] != null)
                        {
                            Main.sund[i].x = Convert.ToInt32(sr.ReadLine());
                            Main.sund[i].y = Convert.ToInt32(sr.ReadLine());
                        }
                   
                    Main.level = Convert.ToInt32(sr.ReadLine());
                }
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

            //if(Text == "Загрузка")
            //{
            //    //Form1.label2.Enabled = true;
            //    //label5.Visible = false;
            //    //label1.Visible = true;
            //}
        }
    }
}
