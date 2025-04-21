using di.repaso.junio.Backend.Modelo;

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

        #region Filtrar por nombre
        public bool NombreUnico(string nombre)
        {
            return contexto.Set<Equipo>().Where(e => e.Nombre == nombre).Count() == 0;
        }

        #endregion
    }
}
