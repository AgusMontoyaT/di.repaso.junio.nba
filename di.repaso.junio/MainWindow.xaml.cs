using System.Windows;
using di.repaso.junio.Backend.Modelo;
using di.repaso.junio.MVVM;

namespace di.repaso.junio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        NbaContext _context;
        MVEquipo _mvEquipo;
        MVJugador _mvJugador;

        public MainWindow(NbaContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMaximizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAgregarEquipo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnListarEquipo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnArbolEquipo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAgregarJugador_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnListaJugadores_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnArbolJugadores_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}