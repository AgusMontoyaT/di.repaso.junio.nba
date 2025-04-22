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
using System.Windows.Shapes;

namespace di.repaso.junio.Frontend.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DialogoAddEquipo.xaml
    /// </summary>
    public partial class DialogoAddEquipo : Window
    {


        private MVEquipo _mvEquipo;


        public DialogoAddEquipo(MVEquipo mvEquipo)
        {
            InitializeComponent();
            _mvEquipo = mvEquipo;
            DataContext = _mvEquipo;

            // Deshabilitar el botón:
            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(_mvEquipo.OnErrorEvent));
            _mvEquipo.btnGuardar = btnAdd;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_mvEquipo.IsValid(this))
            {
                if (_mvEquipo.Unico)
                {
                    bool guardado = await _mvEquipo.Guarda();

                    if (guardado)
                    {
                        MessageBox.Show("El equipo se ha guardado correctamente.", "Éxito");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar el equipo. Inténtalo de nuevo.", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe un equipo con ese nombre. Elige otro.", "Nombre duplicado");
                }
            }
            else
            {
                MessageBox.Show("Faltan campos obligatorios por rellenar.", "Formulario incompleto");
            }
        }

    }
}
