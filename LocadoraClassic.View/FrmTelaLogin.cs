using System;
using System.Windows.Forms;
using LocadoraClassic.DAL;

namespace LocadoraClassic.View
{
    public partial class FrmTelaLogin : Form
    {
        private string connectionString;
        private LoginDAL loginDAL;

        public FrmTelaLogin()
        {
            InitializeComponent();
            connectionString = "Server=127.0.0.1;Database=locadoraclassic;Uid=root;Pwd=";
            loginDAL = new LoginDAL(connectionString);
        }

        private int tentativas = 0;

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text;
            string password = txtSenha.Text;

            if (loginDAL.ValidateCredentials(username, password))
            {
                // Login bem-sucedido
                MessageBox.Show("Login realizado com sucesso!");
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Login inválido
                tentativas++;

                if (tentativas >= 3)
                {
                    MessageBox.Show("Número máximo de tentativas excedido. A aplicação será encerrada.");
                    DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nome de usuário ou senha incorretos! Tentativas restantes: " + (3 - tentativas));
                }
            }
        }
    }
}
