using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using static Treasure_Searcher.Main;

namespace Treasure_Searcher
{
    public class Wall
    {
        public Image image;
        public int x, y;
        public Wall(int x, int y)
        {
            this.x = x;
            this.y = y;
            image = Properties.Resources.hgrtfdtetrd;
        }

        public Wall()
        {
            Random r = new Random();
            do
            {
                x = r.Next(areaSize);
                y = r.Next(areaSize);
            } while (move_ok(x, y) == true);
            image = Properties.Resources.hgrtfdtetrd;
        }

        bool move_ok(int x, int y)
        {
            for (int i = 0; i < sund.Length; i++)
                if (sund[i] != null)
                    if (sund[i].x == x && sund[i].y == y)
                        return true;
            if (man.x == x && man.y == y)
                return true;
            for (int i = 0; i < 5; i++)
                if (mon[i] != null)
                    if (mon[i].x == x && mon[i].y == y)
                        return true;
            for (int i = 0; i < wall.Length; i++)
                if (wall[i] != null)
                    if (wall[i].x == x && wall[i].y == y)
                        return true;
            return false;
        }
    }
}
