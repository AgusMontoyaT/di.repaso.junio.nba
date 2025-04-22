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
    /// Lógica de interacción para DialogoAddJugador.xaml
    /// </summary>
    public partial class DialogoAddJugador : Window
    {

        private MVJugador _mvJugador;

        public DialogoAddJugador(MVJugador mVJugador)
        {
            InitializeComponent();
            _mvJugador = mVJugador;
            DataContext = _mvJugador;

            this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(_mvJugador.OnErrorEvent));
            _mvJugador.btnGuardar = btnAdd;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_mvJugador.IsValid(this))
            {
                if (_mvJugador.Unico)
                {
                    bool guardado = await _mvJugador.Guarda();

                    if (guardado)
                    {
                        MessageBox.Show("El jugador se ha guardado correctamente.", "Éxito");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar el jugador. Inténtalo de nuevo.", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe un jugador con ese nombre. Elige otro.", "Nombre duplicado");
                }
            }
            else
            {
                MessageBox.Show("Faltan campos obligatorios por rellenar.", "Formulario incompleto");
            }
        }
    }
}