using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantFromDatabase
{
    public class Table
    {
        int id;
        Vector2 pozition;
        Vector2 size;
        bool isReserved;
        List<Zidle> zidle;

        public Table(int id, Vector2 pozition, Vector2 size, bool isReserved, List<Zidle> zidle)
        {
            this.id = id;
            this.pozition = pozition;
            this.size = size;
            this.isReserved = isReserved;
            this.zidle = zidle;
        }
    }
}
