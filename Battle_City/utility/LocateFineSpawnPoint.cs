using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Battle_City.utility
{
    public class LocaterFineSpawnPoint
    {
        int time_used = 0;
        int depht;

        Random rnd = new Random();
       public LocaterFineSpawnPoint(int depht_)
        {
            this.depht = depht_;
        }

        public Point find_fine_spawn_point(int[,] wall_map)
        {
            int count = 0;
            while (count < 200)
            {
                int x = rnd.Next(0, 23); // random 0 - 23
                if(time_used%2 == 1)
                {
                    x = 23 - x;
                }
              
                int y = rnd.Next(0, depht);
                if (time_used % 7 == 1) { y = y / 2; }
               // int y = (int)Math.Floor(rnd.NextDouble() * depht); // random 0 - 23

                if (wall_map[y, x] == 0 && wall_map[y+1, x] == 0 && wall_map[y, x+1] == 0 && wall_map[y+1, x+1] == 0) { return new Point(x, y); }

                time_used = time_used + 1;
                count = count + 1;
            }

                return Point.Empty;
        }
        public Point find_fine_spawn_point_for_item(int[,] wall_map)
        {
            int count = 0;
            while (count < 200)
            {
                int x = rnd.Next(0, 23); // random 0 - 23
                if (time_used % 2 == 1)
                {
                    x = 23 - x;
                }

                int y = rnd.Next(0, depht);
                if (time_used % 7 == 1) { y = y / 2; }
                // int y = (int)Math.Floor(rnd.NextDouble() * depht); // random 0 - 23

                if (wall_map[y, x] == 0) { return new Point(x, y); }

                time_used = time_used + 1;
                count = count + 1;
            }
            return Point.Empty;
        }

        }
}
