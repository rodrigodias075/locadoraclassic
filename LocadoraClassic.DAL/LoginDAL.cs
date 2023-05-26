using System;
using MySql.Data.MySqlClient;

namespace LocadoraClassic.DAL
{
    public class LoginDAL
    {
        private string connectionString;

        public LoginDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool ValidateCredentials(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM tabela_usuarios WHERE username = @username AND password = @password";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    int result = Convert.ToInt32(command.ExecuteScalar());

                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro de conexão com o banco de dados: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
