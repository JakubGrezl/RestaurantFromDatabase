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
        public int id;
        public Vector2 pozition;
        public Vector2 size;
        public bool isReserved;
        public List<Zidle> allZidle;
        public List<Zidle> zidle = new List<Zidle>();

        public Table(int id, Vector2 pozition, Vector2 size, bool isReserved, List<Zidle> allZidle)
        {
            this.id = id;
            this.pozition = pozition;
            this.size = size;
            this.isReserved = isReserved;
            this.allZidle = allZidle;
            GetZidle();
        }

        internal void GenerateChair(Graphics g, Brush brush)
        {
            foreach (Zidle eineZidle in zidle)
            {
                g.FillEllipse(brush, (int)eineZidle.pozition.X, (int)eineZidle.pozition.Y, eineZidle.size, eineZidle.size);
            }
        }

        private void GetZidle() { 
            foreach (Zidle lol in allZidle)
            {
                if (lol.fk_table == this.id && lol != null)
                {
                    zidle.Add(lol);
                }
            }
        }
    }
}
