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
    /// Lógica de interacción para UC_Equipo.xaml
    /// </summary>
    public partial class UC_Equipo : UserControl
    {
        MVEquipo _mvEquipo;

        public UC_Equipo(MVEquipo mvEquipo)
        {
            InitializeComponent();
            _mvEquipo = mvEquipo;
            DataContext = _mvEquipo;
        }


        private void cbConferencias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mvEquipo.Filtrar();
        }

        private void cbDivisiones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mvEquipo.Filtrar();
        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            _mvEquipo.Filtrar();
        }

        private void btnEliminarFiltros_Click(object sender, RoutedEventArgs e)
        {
            _mvEquipo.Desfiltrar();
        }
    }
}
