using System;
using System.Linq;
using System.Windows.Forms;
using LocadoraClassic.VO;
using LocadoraClassic.DAL;

namespace LocadoraClassic.View
{
    public partial class FrmTelaCategoria : Form
    {
        CategoriaDAL categoriaDAL = new CategoriaDAL();

        public FrmTelaCategoria()
        {
            InitializeComponent();
            txtValorDiaria.TextChanged += txtValorDiaria_TextChanged;
        }

        private void FrmTelaCategoria_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void txtValorDiaria_TextChanged(object sender, EventArgs e)
        {
            // Implemente a lógica de busca por valor da diária
            string valorDiaria = txtValorDiaria.Text;
            BuscarCategoriasPorValorDiaria(valorDiaria);
        }

        private void BuscarCategoriasPorValorDiaria(string valorDiaria)
        {
            // Implemente a lógica de busca por valor da diária
        }

        private void CarregarGrid()
        {
            dataGridView1.DataSource = categoriaDAL.ObterCategorias().ToList();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Criar um objeto Categoria com os dados preenchidos
            Categoria categoria = new Categoria();
            categoria.Nome = txtNome.Text;
            categoria.ValorDiaria = Convert.ToDecimal(txtValorDiaria.Text);

            // Inserir a categoria no banco de dados
            categoriaDAL.InserirCategoria(categoria);

            // Limpar os campos de texto
            txtNome.Text = "";
            txtValorDiaria.Text = "";

            // Carregar os dados atualizados do banco de dados no grid
            CarregarGrid();

            // Exibir uma mensagem de sucesso
            MessageBox.Show("Dados inseridos com sucesso!");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}