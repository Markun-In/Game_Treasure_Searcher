using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static Treasure_Searcher.Main;

namespace Treasure_Searcher
{
    public class Monster
    {
        public Image image;
        public int x, y;
        public Monster(int x, int y)
        {
            this.x = x;
            this.y = y;
            image = Properties.Resources.Mon_down;
        }
        public Monster()
        {
            Random r = new Random();
            do
            {
                x = r.Next(Main.areasize);
                y = r.Next(Main.areasize);
            } while (move_ok(x, y) == true);
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
            if (move_ok(x, y + 1) == false)
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
}
