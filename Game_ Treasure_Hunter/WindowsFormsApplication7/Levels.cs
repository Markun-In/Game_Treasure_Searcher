using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApplication7.Main;

namespace WindowsFormsApplication7
{
    public class Levels
    {
        public static void Level1()
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
            wall[5] = new Wall(12, 13);
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
        public static void Level2()
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

        public static void Level3()
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
        void RandLevel()
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
        static public void Next_level()
        {
            if (level == 4)
            {
                timer1.Enabled = false;
                timer4.Enabled = false;
                MessageBox.Show("Вы выйграли!");
                return;
            }
            else
            {
                level++;
                timer4.Enabled = true;
                timer1.Enabled = true;
                if (level == 2)
                    Levels.Level2();
                if (level == 3)
                    Levels.Level3();
            }
        }
    }
}
