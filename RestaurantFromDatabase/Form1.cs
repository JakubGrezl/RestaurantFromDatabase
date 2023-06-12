using MySqlConnector;
using System.Numerics;

namespace RestaurantFromDatabase
{
    public partial class Form1 : Form
    {

        

        List<Table> tables = new List<Table>();
        public List<Zidle> zidle = new List<Zidle>();

        public Form1()
        {
            SQLconnect(false);

            SQLconnect(true);

            InitializeComponent();
        }

        private void SQLconnect(bool isTable)
        {
            MySqlCommand cmd;
            string connString;
            MySqlConnection conn;


            connString = "server=167.86.71.184;uid=restaurator;pwd=superHeslo123;database=restaurace";
            conn = new MySqlConnection(connString);
            conn.Open();

            if (isTable)
            {
                cmd = new MySqlCommand("SELECT * FROM stoly", conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tables.Add(new Table(
                        (int)reader.GetValue(0),
                        new Vector2((float)(int)reader.GetValue(1), (float)(int)reader.GetValue(2)),
                        new Vector2((float)(int)reader.GetValue(3), (float)(int)reader.GetValue(4)),
                        (bool)reader.GetValue(5),
                        zidle
                        ));
                }
            }

            if (!isTable)
            {
                cmd = new MySqlCommand("SELECT * FROM zidle", conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    zidle.Add(new Zidle(
                        (int)reader.GetValue(0),
                        new Vector2((float)(int)reader.GetValue(1), (float)(int)reader.GetValue(2)),
                        (int)reader.GetValue(3),
                        (int)reader.GetValue(4)
                        ));
                }
            }

            conn.Close();
        }


        private bool isReservedGetter(int v)
        {
            if (v == 1)
            {
                return true;
            }

            if (v == 0)
            {
                return false;
            }

            return false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (Table table in tables)
            {
                Brush brush = getColorOfTable(table.isReserved);

                g.FillRectangle(brush, table.pozition.X, table.pozition.Y, table.size.X, table.size.Y);
                table.GenerateChair(g, brush);
            }
        }

        private Brush getColorOfTable(bool isReserved)
        {
            if (isReserved)
            {
                return Brushes.Orange;
            } else
            {
                return Brushes.Gray;
            }
        }
    }
}