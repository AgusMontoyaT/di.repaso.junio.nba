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
        public bool Unico => _servicioJugador.NombreUnico(Jugador.Nombre);

        private Predicate<Jugadore> _criterioEquipo;
        private Predicate<Jugadore> _criterioPosicion;
        private Predicate<Jugadore> _criterioNombre;
        private List<Predicate<Jugadore>> _criterios;
        private Predicate<object> _predicadoJugadores;

        private string _nombre;
        private string _posicion;
        private string _equipoDelJugador;

        public string Nombre { get => _nombre; set { _nombre = value; OnPropertyChanged(nameof(Nombre)); } }

        public string Posicion { get => _posicion; set { _posicion = value; OnPropertyChanged(nameof(Posicion)); } }

        public string EquipoDelJugador { get => _equipoDelJugador; set { _equipoDelJugador = value; OnPropertyChanged(nameof(EquipoDelJugador)); } }

        #endregion

        #region Getters y setters
        public Jugadore Jugador
        {
            get => _jugador;
            set { _jugador = value; OnPropertyChanged(nameof(Jugador)); }
        }

        public ListCollectionView listaJugadores => _listaJugadores;

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

        private void InicializaCriterios()
        {
            _criterioPosicion = new Predicate<Jugadore>(e => !string.IsNullOrEmpty(e.Posicion) && e.Posicion.Equals(Posicion));

            _criterioEquipo = new Predicate<Jugadore>(e => !string.IsNullOrEmpty(e.NombreEquipoNavigation.Nombre) && e.NombreEquipoNavigation.Nombre.Equals(EquipoDelJugador));

            _criterioNombre = new Predicate<Jugadore>(e => !string.IsNullOrEmpty(e.Nombre) && e.Nombre.ToLower().Contains(Nombre));
        }

        private void AddCriterios()
        {
            _criterios.Clear();

            if (!string.IsNullOrEmpty(Posicion)) { _criterios.Add(_criterioPosicion); }
            if (!string.IsNullOrEmpty(EquipoDelJugador)) { _criterios.Add(_criterioEquipo); }
            if (!string.IsNullOrEmpty(Nombre)) { _criterios.Add(_criterioNombre); }
        }


        //SUPER IMPORTANTE
        private bool Filtrado(object item)
        {
            bool correcto = true;
            Jugadore ju;

            if (item != null && _criterios.Count > 0)
            {
                //Casting
                ju = (Jugadore)item;
                //PARA QUE SOLO COJA UNA PROPIEDAD DEL OBJETO
                correcto = _criterios.TrueForAll(x => x(ju));
            }

            return correcto;
        }
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

            // FILTROS
            _criterios = new List<Predicate<Jugadore>>();
            _predicadoJugadores = new Predicate<object>(Filtrado);
            InicializaCriterios();
        }

        public void Filtrar()
        {
            AddCriterios();
            listaJugadores.Filter = _predicadoJugadores;
        }

        public void Desfiltrar()
        {
            _criterios.Clear();

            Nombre = "";
            Posicion = "";
            EquipoDelJugador = "";

            listaJugadores.Filter = null;
            listaJugadores.Refresh();

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