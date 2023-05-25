using System;
using System.Linq;
using System.Windows.Forms;
using LocadoraClassic.VO;
using LocadoraClassic.DAL;

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
    }
}
