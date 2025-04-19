using di.repaso.junio.Backend.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace di.repaso.junio.Frontend.Dialogos
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private NbaContext _contexto;
        public Login()
        {
            if (Conectar())
            { 
                InitializeComponent();
            
            } else
            {
                this.Close();
            }
        }
        private bool Conectar()
        {
            bool conectado = false;
            _contexto = new NbaContext();
            try
            {
                _contexto.Database.OpenConnection();
                conectado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return conectado;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow pantallaInicial;
            pantallaInicial = new MainWindow(_contexto);
            pantallaInicial.Show();
            this.Close();
        }

        private void btnGoogle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFacebook_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
