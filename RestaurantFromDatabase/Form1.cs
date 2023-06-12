using MySqlConnector;
using System.Numerics;

namespace RestaurantFromDatabase
{
    public partial class Form1 : Form
    {

        MySqlCommand cmd;
        string connString;
        MySqlConnection conn;

        List<Table> tables = new List<Table>();
        List<Zidle> zidle = new List<Zidle>();

        public Form1()
        {
            SQLconnect(true);

            InitializeComponent();
        }

        private void SQLconnect(bool isTable)
        {

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
                        (int)reader["id"],
                        new Vector2((float)reader["pozX"], (float)reader["pozY"]),
                        new Vector2((float)reader["velX"], (float)reader["velY"]),
                        isReservedGetter((int)reader["rezervovano"])));
                }
            }

            if (!isTable)
            {
                cmd = new MySqlCommand("SELECT * FROM zidle", conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    zidle.Add(new Zidle(
                        (int)reader["id"],
                        new Vector2((float)reader["pozX"], (float)reader["pozY"]),
                        (int)reader["vel"],
                        (int)reader["fk_stul"]
                        ));
                }
            }

            conn.Close();
        }


        private bool isReservedGetter(int v)
        {
            if(v == 1)
            {
                return true;
            }

            if (v == 0)
            {
                return false;
            }

            return false;
        }
    }
}