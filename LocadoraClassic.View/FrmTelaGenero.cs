using System;
using System.Linq;
using System.Windows.Forms;
using LocadoraClassic.VO;
using LocadoraClassic.DAL;
using MySql.Data.MySqlClient;

namespace LocadoraClassic.View
{
    public partial class FrmTelaGenero : Form
    {
        GeneroDAL generoDAL = new GeneroDAL();
        public FrmTelaGenero()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //objeto VO
            Genero genero = new Genero();
            //objeto DAL

            //Pegar o valor da caixinha e colocar na propriedade Nome
            genero.Nome = txtGenero.Text;

            //INSERIR NO BANCO DE DADOS
            generoDAL.InserirGenero(genero);

            //Limpar a caixa
            txtGenero.Text = "";
            CarregarGrid();
            MessageBox.Show("Dados inseridos com sucesso!");


        }

        private void FrmTelaGenero_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        public void CarregarGrid()
        {
            dgvGeneros.DataSource = generoDAL.ObterGeneros().ToList();
        }

        private void dgvGeneros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        int id = 0; // Declare a variável id fora do escopo condicional
        private string connectionString;

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Verifica se há alguma linha selecionada no DataGridView
            if (dgvGeneros.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvGeneros.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                GeneroDAL generoDALInstance = new GeneroDAL();
                generoDALInstance.ExcluirGenero(id);

                CarregarGrid();
            }
            else
            {
                // Trate o caso em que nenhuma linha é selecionada, se necessário
            }
        }



        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dgvGeneros.SelectedRows.Count > 0)
            {
                // Obtém a linha selecionada
                DataGridViewRow selectedRow = dgvGeneros.SelectedRows[0];

                // Obtém o valor do campo "id" da célula selecionada
                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                // Cria um novo objeto Genero com os valores atualizados
                Genero genero = new Genero();
                genero.Nome = txtGenero.Text;
                genero.Id = id;

                // Chama o método de atualização na classe GeneroDAL
                generoDAL.AtualizarGenero(genero);

                // Limpa o campo de texto
                txtGenero.Text = "";

                // Atualiza o grid
                CarregarGrid();
            }
        }
    }
}
            
    

