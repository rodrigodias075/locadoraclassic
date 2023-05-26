using System;
using System.Windows.Forms;
using LocadoraClassic.View;

namespace LocadoraClassic
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Criação da instância da tela de login
            FrmTelaLogin telaLogin = new FrmTelaLogin();

            // Verifica se o login foi bem-sucedido antes de abrir a tela principal
            if (telaLogin.ShowDialog() == DialogResult.OK)
            {
                // Abre a tela principal
                Application.Run(new frmMenu());
            }
            else
            {
                // Encerra a aplicação se o login não foi válido
                Application.Exit();
            }
        }
    }
}
