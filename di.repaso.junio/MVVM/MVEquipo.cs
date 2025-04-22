using di.repaso.junio.Backend.Modelo;
using di.repaso.junio.Backend.Servicios;
using di.repaso.junio.MVVM.Base;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace di.repaso.junio.MVVM
{
    // Ve a la clase correspondiente y enlaza con la propiedad de la carpeta MVVM.Base
    public class MVEquipo : MVBaseCRUD<Equipo>
    {
        private NbaContext _context;
        private Equipo _equipo;
        private ServicioEquipo _servicioEquipo;

        private ListCollectionView _listaEquipos;

        #region Filtros
        private Predicate<Equipo> _criterioConferencia;
        private Predicate<Equipo> _criterioDivision;
        private Predicate<Equipo> _criterioNombre;
        private List<Predicate<Equipo>> _criterios;
        private Predicate<object> _predicadoEquipos;

        private string _conferencia;
        private string _division;
        private string _nombre;

        // Propiedades SelectedItem
        public string Conferencia { get => _conferencia; set { _conferencia = value; OnPropertyChanged(nameof(Conferencia)); } }
        public string Division { get => _division; set { _division = value; OnPropertyChanged(nameof(Division)); } }
        public string Nombre { get => _nombre; set { _nombre = value; OnPropertyChanged(nameof(Nombre)); } }

        public bool Unico => _servicioEquipo.NombreUnico(Equipo.Nombre);
        #endregion

        #region Getters y setters
        public Equipo Equipo
        {
            get => _equipo;
            set { _equipo = value; OnPropertyChanged(nameof(Equipo)); }
        }

        public ListCollectionView listaEquipos => _listaEquipos;

        public List<string> listaConferencias => _servicioEquipo.getConferencias();


        public List<string> listaDivisiones => _servicioEquipo.getDivisiones();

        #endregion

        #region Constructores
        public MVEquipo() { }

        public MVEquipo(NbaContext context)
        {
            _context = context;
        }
        #endregion

        #region Métodos privados
        private void InicializaCriterios()
        {
            // ComboBox:
            _criterioConferencia = new Predicate<Equipo>(e => !string.IsNullOrEmpty(e.Conferencia) && e.Conferencia.Equals(Conferencia));

            _criterioDivision = new Predicate<Equipo>(e => !string.IsNullOrEmpty(e.Division) && e.Division.Equals(Division));

            // TextBox:
            _criterioNombre = new Predicate<Equipo>(e => !string.IsNullOrEmpty(e.Nombre) && e.Nombre.ToLower().Contains(Nombre));
        }

        private void AddCriterios()
        {
            _criterios.Clear();

            if (!string.IsNullOrEmpty(Conferencia)) { _criterios.Add(_criterioConferencia); }
            if (!string.IsNullOrEmpty(Division)) { _criterios.Add(_criterioDivision); }
            if (!string.IsNullOrEmpty(Nombre)) { _criterios.Add(_criterioNombre); }
        }

        //SUPER IMPORTANTE
        private bool Filtrado(object item)
        {
            bool correcto = true;
            Equipo eq;

            if (item != null && _criterios.Count > 0)
            {
                //Casting
                eq = (Equipo)item;
                //PARA QUE SOLO COJA UNA PROPIEDAD DEL OBJETO
                correcto = _criterios.TrueForAll(x => x(eq));
            }

            return correcto;
        }


        #endregion

        #region Métodos públicos
        public async Task Inicializa()
        {
            _servicioEquipo = new ServicioEquipo(_context);
            servicio = _servicioEquipo;
            List<Equipo> lista = (await _servicioEquipo.GetAllAsync()).ToList();
            _listaEquipos = new ListCollectionView(lista);
            _equipo = new Equipo();

            //FILTROS
            _criterios = new List<Predicate<Equipo>>();
            _predicadoEquipos = new Predicate<object>(Filtrado);
            InicializaCriterios();
        }

        public void Filtrar()
        {
            AddCriterios();
            listaEquipos.Filter = _predicadoEquipos;
        }

        public void Desfiltrar()
        {
            _criterios.Clear();

            Nombre = "";
            Conferencia = "";
            Division = "";

            listaEquipos.Filter = null;
            listaEquipos.Refresh();

        }

        public async Task<bool> Guarda()
        {
            return await Add(Equipo);
        }

        #endregion
    }
}
