using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LocadoraClassic.DAL
{
    public class Conexao
    {

        private static  MySqlConnection _instance;
        public static  MySqlConnection Instance {
            get { 
                if(_instance == null)
                {
                    _instance = new MySqlConnection(@"Server=127.0.0.1;Database=locadoraclassic;Uid=root;Pwd=");
                }
                return _instance; 
            } 
        }

      
    }
}
