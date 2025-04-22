using di.repaso.junio.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace di.repaso.junio.Frontend.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UC_Jugador.xaml
    /// </summary>
    public partial class UC_Jugador : UserControl
    {

        MVJugador _mvJugador;

        public UC_Jugador(MVJugador mvJugador)
        {
            InitializeComponent();
            _mvJugador = mvJugador;
            DataContext = _mvJugador;
        }

        private void cbEquipos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mvJugador.Filtrar();
        }

        private void cbPosiciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mvJugador.Filtrar();
        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            _mvJugador.Filtrar();

        }

        private void btnEliminarFiltros_Click(object sender, RoutedEventArgs e)
        {
            _mvJugador.Desfiltrar();

        }
    }
}
