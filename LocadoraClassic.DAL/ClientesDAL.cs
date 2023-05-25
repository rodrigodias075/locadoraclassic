using LocadoraClassic.VO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace LocadoraClassic.DAL
{
    public class ClienteDAL
    {
        public void InserirCliente(Cliente cliente)
        {
            Conexao.Instance.Open();

            MySqlCommand comando = Conexao.Instance.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "INSERT INTO cliente (nome_do_cliente, endereço, whatsapp, cpf, rg) " +
                                   "VALUES (@nome_do_cliente, @endereço, @whatsapp, @cpf, @rg)";
            comando.Parameters.Add(new MySqlParameter("@nome_do_cliente", cliente.Nome));
            comando.Parameters.Add(new MySqlParameter("@endereço", cliente.Endereco));
            comando.Parameters.Add(new MySqlParameter("@whatsapp", cliente.Whatsapp));
            comando.Parameters.Add(new MySqlParameter("@cpf", cliente.CPF));
            comando.Parameters.Add(new MySqlParameter("@rg", cliente.RG));

            comando.ExecuteNonQuery();

            Conexao.Instance.Close();
        }

        public List<Cliente> ObterClientes()
        {
            Conexao.Instance.Open();

            MySqlCommand comando = Conexao.Instance.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM cliente";

            MySqlDataReader reader = comando.ExecuteReader();

            List<Cliente> clientes = new List<Cliente>();
            while (reader.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = Convert.ToInt32(reader["id"]);
                cliente.Nome = reader["nome_do_cliente"].ToString();
                cliente.Endereco = reader["endereço"].ToString();
                cliente.Whatsapp = reader["whatsapp"].ToString();
                cliente.CPF = reader["cpf"].ToString();
                cliente.RG = reader["rg"].ToString();

                clientes.Add(cliente);
            }

            reader.Close();
            Conexao.Instance.Close();

            return clientes;
        }
    }
}