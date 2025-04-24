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
    /// Lógica de interacción para UC_Jugadores.xaml
    /// </summary>
    public partial class UC_Jugadores : UserControl
    {

        MVJugador _mvJugador;
        public UC_Jugadores(MVJugador mv)
        {
            InitializeComponent();
            _mvJugador = mv;
            DataContext = _mvJugador;
        }

        private void treeJugadores_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }
    }
}
