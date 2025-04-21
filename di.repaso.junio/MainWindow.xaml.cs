using System.Windows;
using di.repaso.junio.Backend.Modelo;
using di.repaso.junio.Frontend.Dialogos;
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
            _ = Inicializa();
        }
        private async Task Inicializa()
        {
            _mvEquipo = new MVEquipo(_context);
            await _mvEquipo.Inicializa();
            //_mvJugador = new MVJugador(_contexto);
            //await _mvJugador.Inicializa();
        }
        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState=WindowState.Maximized;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAgregarEquipo_Click(object sender, RoutedEventArgs e)
        {
            DialogoAddEquipo dialogoAdd = new DialogoAddEquipo(_mvEquipo);
            dialogoAdd.ShowDialog();
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