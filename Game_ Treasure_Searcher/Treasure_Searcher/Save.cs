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
                    sw.WriteLine(man.x);
                    sw.WriteLine(man.y);
                    for (int i = 0; i < 5; i++)
                        sw.WriteLine(mon[i].x);
                    for (int i = 0; i < 5; i++)
                        sw.WriteLine(mon[i].y);
                    for (int i = 0; i <= wall.Length - 1; i++)
                        sw.WriteLine(wall[i].x);
                    for (int i = 0; i <= wall.Length - 1; i++)
                        sw.WriteLine(wall[i].y);
                    sw.WriteLine(Minisund);
                    sw.WriteLine(life);
                    for (int i = 0; i <  4; i++) { 
                        if (sund[i] != null)
                        {
                            sw.WriteLine(sund[i].x);
                            sw.WriteLine(sund[i].y);
                        }
                    }
                    sw.WriteLine(level);
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
                    man.x = Convert.ToInt32(sr.ReadLine()); 
                    man.y = Convert.ToInt32(sr.ReadLine());

                    for (int i = 0; i < 5; i++)
                        mon[i].x = Convert.ToInt32(sr.ReadLine());
                    for (int i = 0; i < 5; i++)
                        mon[i].y = Convert.ToInt32(sr.ReadLine());
                    for (int i = 0; i <= wall.Length - 1; i++)
                        wall[i].x = Convert.ToInt32(sr.ReadLine());
                    for (int i = 0; i <= wall.Length - 1; i++)  
                        wall[i].y = Convert.ToInt32(sr.ReadLine());

                    Minisund = Convert.ToInt32(sr.ReadLine());
                    life = Convert.ToInt32(sr.ReadLine());
                    sund = new Sunduk[Minisund];

                    for (int i = 0; i < Minisund; i++)
                        sund[i] = new Sunduk(0 ,0);
                    
                    for (int i = 0; i < Minisund; i++)
                        if (sund[i] != null)
                        {
                            sund[i].x = Convert.ToInt32(sr.ReadLine());
                            sund[i].y = Convert.ToInt32(sr.ReadLine());
                        }
                    level = Convert.ToInt32(sr.ReadLine());
                }
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
            => Close();
    }
}
