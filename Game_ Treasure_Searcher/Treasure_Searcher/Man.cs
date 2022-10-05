using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static Treasure_Searcher.Main;

namespace Treasure_Searcher
{
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
}
