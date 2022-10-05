using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static Treasure_Searcher.Main;

namespace Treasure_Searcher
{
    public class Sunduk
    {
        public Image image;
        public int x, y;
        public Sunduk(int x, int y)
        {
            this.x = x;
            this.y = y;
            image = Properties.Resources.mini_sunduk;
        }

        #region RandSunduk
        /* public Sunduk()
        {
            Random r = new Random();
            do
            {
                x = r.Next(areaSize);
                y = r.Next(areaSize);
            } while (move_ok(x, y) == true);
            image = Properties.Resources.mini_sunduk;
        } 
        bool move_ok(int x, int y)
        {
            for (int i = 0; i < 4; i++)
                if (sund[i] != null)
                    if (sund[i].x == x && sund[i].y == y)
                        return true;
            if (man.x == x && man.y == y)
                return true;
            for (int i = 0; i < 5; i++)
                if (mon[i] != null)
                    if (mon[i].x == x && mon[i].y == y)
                        return true;
            for (int i = 1; i < 10; i++)
                if (wall[i].x == x && wall[i].y == y)
                    return true;
            return false;
        } */
        #endregion
    }
}
