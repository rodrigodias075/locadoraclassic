using System;
using System.Linq;
using System.Windows.Forms;
using LocadoraClassic.VO;
using LocadoraClassic.DAL;

namespace LocadoraClassic.View
{
    public partial class FrmTelaCliente : Form
    {
        ClienteDAL clienteDAL = new ClienteDAL();

        public FrmTelaCliente()
        {
            InitializeComponent();
            txtClientes.TextChanged += txtClientes_TextChanged;
        }

        private void FrmTelaCliente_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void txtClientes_TextChanged(object sender, EventArgs e)
        {
            string nomeCliente = txtClientes.Text;
            BuscarClientesPorNome(nomeCliente);
        }

        private void BuscarClientesPorNome(string nomeCliente)
        {

        }

        private void CarregarGrid()
        {
            dgvClientes.DataSource = clienteDAL.ObterClientes().ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Criar um objeto Cliente com os dados preenchidos
            Cliente cliente = new Cliente();
            cliente.Nome = txtClientes.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.Whatsapp = txtWhatsapp.Text;
            cliente.CPF = txtCpf.Text;
            cliente.RG = txtRg.Text;

            // Inserir o cliente no banco de dados
            clienteDAL.InserirCliente(cliente);

            // Limpar os campos de texto
            txtClientes.Text = "";
            txtEndereco.Text = "";
            txtWhatsapp.Text = "";
            txtCpf.Text = "";
            txtRg.Text = "";

            // Carregar os dados atualizados do banco de dados no grid
            CarregarGrid();

            // Exibir uma mensagem de sucesso
            MessageBox.Show("Dados inseridos com sucesso!");
        }
    }
}
