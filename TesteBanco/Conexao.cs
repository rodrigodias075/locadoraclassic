using MySql.Data.MySqlClient;

namespace TesteBanco
{
    public class Conexao
    {
        private static MySqlConnection _conn;

        public static MySqlConnection Instance
        {
            get
            {

                if (_conn == null)
                {

                    _conn = new MySqlConnection(@"Server = 127.0.0.1; Database = locadora; Uid = root; Pwd = ;");
                }

                return _conn;
            }

        }
    }    
}

