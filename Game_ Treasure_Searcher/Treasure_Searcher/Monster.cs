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

        private static bool Move_ok(int x, int y)
        {
            if (x == 6 && y == 6)
                return true;
            for (int i = 0; i < 5; i++)
                if (mon[i].x == x && mon[i].y == y && mon[i] != null)
                    return true;
            if (man.x == x && man.y == y)
                return true;
            for (int i = 0; i < sund.Length; i++)
                if (sund[i] != null)
                    if (sund[i].x == x && sund[i].y == y)
                        return true;
            for (int n = 0; n < wall.Length; n++)
                if (x == wall[n].x && y == wall[n].y && wall[n] != null)
                    return true;
            if (x < 0 || y < 0 || x > 9 || y > 9)
                return true;
            return false;
        }
        public void Left()
        {
            image = Properties.Resources.Mon_left;
            if (Move_ok(x - 1, y) == false)
                x--;
            if (man.x == x && man.y == y)
                life--;
        }
        public void Right()
        {
            image = Properties.Resources.Mon_right;
            if (Move_ok(x + 1, y) == false)
                x++;
            if (man.x == x && man.y == y)
                life--;
        }
        public void Down()
        {
            image = Properties.Resources.Mon_right;
            if (Move_ok(x, y + 1) == false)
                y++;
            if (man.x == x && man.y == y)
                life--;
        }
        public void Up()
        {
            image = Properties.Resources.Mon_right;
            if (Move_ok(x, y - 1) == false)
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
