using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraClassic.VO
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorDiaria { get; set; }

        public Categoria()
        {

        }

        public Categoria(int id, string nome, decimal valorDiaria)
        {
            Id = id;
            Nome = nome;
            ValorDiaria = valorDiaria;
        }

        public Categoria(string nome, decimal valorDiaria)
        {
            Nome = nome;
            ValorDiaria = valorDiaria;
        }
    }
}