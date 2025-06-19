using CentroEventos.Aplicacion.Entidades; //actualizado con base de datos
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enumerativos;
using System.Globalization;

namespace CentroEventos.Repositorios
{
    public class RepositorioReserva : IRepositorioReserva
    {
        private readonly CentroEventosDbContext dataBase;

        public RepositorioReserva(CentroEventosDbContext db)
        {
            dataBase = db;
        }

        public void Agregar(Reserva reserva)
        {
            dataBase.Reservas.Add(reserva);
            dataBase.SaveChanges();
        }

        public void Modificar(Reserva reserva)
        {
            dataBase.Reservas.Update(reserva);
            dataBase.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var reserva = dataBase.Reservas.Find(id);
            if (reserva != null)
            {
                dataBase.Reservas.Remove(reserva);
                dataBase.SaveChanges();
            }
        }

        public Reserva? ObtenerPorId(int id)
        {
            return dataBase.Reservas.Find(id);
        }

        public List<Reserva> ObtenerTodos()
        {
            return dataBase.Reservas.ToList();
        }

        public bool ExisteReservaParaPersonaYEvento(int personaId, int eventoDeportivoId)
        {
            return dataBase.Reservas.Any(r =>
                r.PersonaId == personaId && r.EventoDeportivoId == eventoDeportivoId);
        }

        public int ContarReservasPorEvento(int eventoDeportivoId)
        {
            return dataBase.Reservas.Count(r => r.EventoDeportivoId == eventoDeportivoId);
        }

        public List<Reserva> ObtenerReservasPorEvento(int eventoDeportivoId)
        {
            var evento = dataBase.EventosDeportivos.FirstOrDefault(e => e.ID == eventoDeportivoId);
            if (evento == null || evento.FechaHoraInicio > DateTime.Now)
                return new List<Reserva>();

            return dataBase.Reservas
                .Where(r => r.EventoDeportivoId == eventoDeportivoId)
                .ToList();
        }
    public List<Reserva> ObtenerReservasPorPersona(int personaId)
    {
        var persona = dataBase.Personas.FirstOrDefault(e => e.Id == personaId);
        if (persona == null)
            return new List<Reserva>();

        return dataBase.Reservas
            .Where(r => r.PersonaId == personaId)
            .ToList();
    }
    }
}
