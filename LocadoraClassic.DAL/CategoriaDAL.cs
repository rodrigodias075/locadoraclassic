using LocadoraClassic.VO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace LocadoraClassic.DAL
{
    public class CategoriaDAL
    {
        public void InserirCategoria(Categoria categoria)
        {
            Conexao.Instance.Open();

            MySqlCommand comando = Conexao.Instance.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "INSERT INTO categoria (nome, valor_diaria) VALUES (@nome, @valorDiaria)";
            comando.Parameters.Add(new MySqlParameter("@nome", categoria.Nome));
            comando.Parameters.Add(new MySqlParameter("@valorDiaria", categoria.ValorDiaria));
            comando.ExecuteNonQuery();

            Conexao.Instance.Close();
        }

        public List<Categoria> ObterCategorias()
        {
            Conexao.Instance.Open();

            MySqlCommand comando = Conexao.Instance.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM categoria";

            MySqlDataReader reader = comando.ExecuteReader();

            List<Categoria> categorias = new List<Categoria>();

            while (reader.Read())
            {
                Categoria categoria = new Categoria();
                categoria.Id = Convert.ToInt32(reader["id"]);
                categoria.Nome = reader["nome"].ToString();
                categoria.ValorDiaria = Convert.ToDecimal(reader["valor_diaria"]);

                categorias.Add(categoria);
            }

            reader.Close();
            Conexao.Instance.Close();

            return categorias;
        }
    }
}