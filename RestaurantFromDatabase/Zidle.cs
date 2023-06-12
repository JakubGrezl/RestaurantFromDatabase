using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFromDatabase
{
    public class Zidle
    {
        public int id;
        public Vector2 pozition;
        public int size;
        public int fk_table;

        public Zidle(int id, Vector2 pozition, int size, int fk_table)
        {
            this.id = id;
            this.pozition = pozition;
            this.size = size;
            this.fk_table = fk_table;
        }
    }
}
