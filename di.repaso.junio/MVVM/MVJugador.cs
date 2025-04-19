using di.repaso.junio.Backend.Modelo;
using di.repaso.junio.Backend.Servicios;
using di.repaso.junio.MVVM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace di.repaso.junio.MVVM
{
    // Ve a la clase correspondiente y enlaza con la propiedad de la carpeta MVVM.Base
    public class MVJugador : MVBaseCRUD<Jugadore>
    {
        private NbaContext _context;
        private ServicioJugador _servicioJugador;
        private ServicioEquipo _servicioEquipo;
        private Jugadore _jugadore;

        private ListCollectionView _listaJugadores;





        // FILTROS

        #region Getters y setters
        

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
            _servicioJugador = new ServicioJugador(_context);
            servicio = _servicioJugador;
            List<Jugadore> lista = (await _servicioJugador.GetAllAsync()).ToList();
        }


        public async Task<bool> Guarda()
        {
            return await Add(Jugador);
        }
        #endregion
    }
}
