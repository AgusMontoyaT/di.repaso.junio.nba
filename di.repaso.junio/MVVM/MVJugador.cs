using di.repaso.junio.Backend.Modelo;
using di.repaso.junio.Backend.Servicios;
using di.repaso.junio.MVVM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace di.repaso.junio.MVVM
{
    // Ve a la clase correspondiente y enlaza con la propiedad de la carpeta MVVM.Base
    public class MVJugador : MVBaseCRUD<Jugadore>
    {
        private NbaContext _context;
        private ServicioJugador _servicioJugador;
        private ServicioEquipo _servicioEquipo;
        private Jugadore _jugador;

        private ListCollectionView _listaJugadores;

        #region Filtros
        // SERVICIOJUGADOR EDITADO
        public bool unico => _servicioJugador.NombreUnico(Jugador.Nombre);

        public Button btnAdd { get; set; }

        #endregion

        #region Getters y setters
        public Jugadore Jugador
        {
            get => _jugador;
            set { _jugador = value; OnPropertyChanged(nameof(Jugador)); }
        }

        public List<string> listaPosiciones => _servicioJugador.getPosiciones();
        public IEnumerable<Equipo> listaEquipos
        {
            get { return Task.Run(() => _servicioEquipo.GetAllAsync()).Result; }
        }
        #endregion

        #region Constructores
        public MVJugador() { }


        public MVJugador(NbaContext context)
        {
            _context = context;
        }
        #endregion

        #region Métodos privados

        #endregion

        #region Métodos públicos
        public async Task Inicializa()
        {
            _servicioEquipo = new ServicioEquipo(_context);
            _servicioJugador = new ServicioJugador(_context);
            servicio = _servicioJugador;
            List<Jugadore> lista = (await _servicioJugador.GetAllAsync()).ToList();
            _listaJugadores = new ListCollectionView(lista);

            _jugador = new Jugadore();
        }

        public async Task<bool> Guarda()
        {
            // CODIGO NO AUTOINCREMENTAL
            Jugador.Codigo = _servicioJugador.getLastId() + 1;

            return await Add(Jugador);
        }
        #endregion
    }
}