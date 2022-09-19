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
using static WindowsFormsApplication7.Form1;

namespace WindowsFormsApplication7
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
                    sw.WriteLine(Form1.man.x);
                    sw.WriteLine(Form1.man.y);
                    for (int i = 0; i < 5; i++)
                        sw.WriteLine(Form1.mon[i].x);
                    for (int i = 0; i < 5; i++)
                        sw.WriteLine(Form1.mon[i].y);
                    for (int i = 0; i <= Form1.wall.Length - 1; i++)
                        sw.WriteLine(Form1.wall[i].x);
                    for (int i = 0; i <= Form1.wall.Length - 1; i++)
                        sw.WriteLine(Form1.wall[i].y);
                    sw.WriteLine(Form1.Minisund);
                    sw.WriteLine(Form1.life);
                    for (int i = 0; i <  4; i++) { 
                        if (Form1.sund[i] != null)
                        {
                            sw.WriteLine(Form1.sund[i].x);
                            sw.WriteLine(Form1.sund[i].y);
                        }
                    }
                    sw.WriteLine(Form1.level);
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

                StreamReader sr = new StreamReader(textBox1.Text + ".txt");
                Form1.man.x = Convert.ToInt32(sr.ReadLine());
                Form1.man.y = Convert.ToInt32(sr.ReadLine());
                for (int i = 0; i < 5; i++)
                    Form1.mon[i].x = Convert.ToInt32(sr.ReadLine());
                for (int i = 0; i < 5; i++)
                    Form1.mon[i].y = Convert.ToInt32(sr.ReadLine());
                for (int i = 0; i <= Form1.wall.Length - 1; i++)
                    Form1.wall[i].x = Convert.ToInt32(sr.ReadLine());
                for (int i = 0; i <= Form1.wall.Length - 1; i++)  
                    Form1.wall[i].y = Convert.ToInt32(sr.ReadLine());
                Form1.Minisund = Convert.ToInt32(sr.ReadLine());
                Form1.life = Convert.ToInt32(sr.ReadLine());
                Form1.sund = new Form1.Sunduk[Minisund];

                for (int i = 0; i < Form1.Minisund; i++)
                    Form1.sund[i] = new Form1.Sunduk(0 ,0);
                
                for (int i = 0; i < Minisund; i++)
                    if (Form1.sund[i] != null)
                    {
                        Form1.sund[i].x = Convert.ToInt32(sr.ReadLine());
                        Form1.sund[i].y = Convert.ToInt32(sr.ReadLine());
                    }
               
                Form1.level = Convert.ToInt32(sr.ReadLine());
                sr.Close();
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
