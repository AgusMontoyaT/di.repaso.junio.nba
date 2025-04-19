using di.repaso.junio.Backend.Modelo;

namespace di.repaso.junio.Backend.Servicios
{
    public class ServicioEquipo : ServicioGenerico<Equipo>
    {

        private NbaContext contexto;

        public ServicioEquipo(NbaContext context) : base(context)
        {
            contexto = context;
        }

        public int getLastId()
        {
            Jugadore ju = contexto.Set<Jugadore>().OrderByDescending(j => j.Codigo).FirstOrDefault();
            return ju.Codigo;
        }

        public bool NombreUnico(string nombre)
        {
            return contexto.Set<Equipo>().Where(e => e.Nombre == nombre).Count() == 0;
        }

        public List<string> getDivisiones()
        {
            var result = from eq in contexto.Equipos
                         group eq by eq.Division into d
                         select d.Key;
            return result.ToList();
            
            /*var result = contexto.Database.SqlQuery<string>("select Division from equipos group by Division").ToList();
            return result;*/
        }

        public List<string> getConferencias()
        {
            var confs = from eq in contexto.Equipos
                        group eq by eq.Conferencia into c
                        select c.Key;
            return confs.ToList();
        }

    }
}
