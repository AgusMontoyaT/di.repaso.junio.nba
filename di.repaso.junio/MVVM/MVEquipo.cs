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
    public class MVEquipo : MVBaseCRUD<Equipo>
    {
        private NbaContext _context;
        private Equipo _equipo;
        private ServicioEquipo _servicioEquipo;

        private ListCollectionView _listaEquipos;


        #region Getters y setters
        public Equipo Equipo {
            get => _equipo;
            set { _equipo = value; OnPropertyChanged(nameof(Equipo)); }
        }

        public List<string> listaConferencias => _servicioEquipo.getConferencias();

        public List<string> listaDivisiones => _servicioEquipo.getDivisiones();

        public bool unico => _servicioEquipo.NombreUnico(Equipo.Nombre);
        
        public Button btnAdd { get; set; }
        #endregion

        #region Constructores
        public MVEquipo() { }

        public MVEquipo(NbaContext context)
        {
            _context = context;
        }
        #endregion

        #region Métodos privados

        #endregion

        #region Métodos públicos
        public async Task Inicializa() { 
        _servicioEquipo = new ServicioEquipo(_context);
            servicio = _servicioEquipo;
            List<Equipo> lista = (await _servicioEquipo.GetAllAsync()).ToList();
            _listaEquipos = new ListCollectionView(lista);
            _equipo = new Equipo();
            
            // FILTROS
        }

        public async Task<bool> Guarda() {
            return await Add(Equipo);
        }
        #endregion
    }
}
