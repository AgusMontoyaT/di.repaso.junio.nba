using di.repaso.junio.Backend.Modelo;
using Microsoft.EntityFrameworkCore;

namespace di.repaso.junio.Backend.Servicios
{
    public class ServicioJugador : ServicioGenerico<Jugadore>
    {
        private NbaContext contexto;

        public ServicioJugador(NbaContext context) : base(context)
        {
            contexto = context;
        }

        public int getLastId()
        {
            Jugadore ju = contexto.Set<Jugadore>().OrderByDescending(j => j.Codigo).FirstOrDefault();
            return ju.Codigo;
        }

        public List<string> getPosiciones()
        {
            var pos = from ju in contexto.Jugadores
                        group ju by ju.Posicion into p
                        select p.Key;
            return pos.ToList();
        }
		
		public List<string> getTemporadas()
        {
            var result = from par in contexto.Partidos
                         group par by par.Temporada into t
                         select t.Key;
            return result.ToList();
        }

        #region AÑADIDOS
        public bool NombreUnico(string nombre)
        {
            return contexto.Set<Jugadore>().Where(e => e.Nombre == nombre).Count() == 0;
        }

        public async Task<IEnumerable<Jugadore>> getEstadisticas()
        {
            return await contexto.Jugadores
                .Include(j => j.Estadisticas)
                .Include(j => j.NombreEquipoNavigation)
                .ToListAsync();
        }

        #endregion
    }
}
