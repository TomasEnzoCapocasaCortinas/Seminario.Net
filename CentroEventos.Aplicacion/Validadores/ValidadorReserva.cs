using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Validadores
{
    public class ValidadorReserva
    {
        private readonly IRepositorioPersona _repoPersona;
        private readonly IRepositorioEventoDeportivo _repoEvento;
        private readonly IRepositorioReserva _repoReserva;

        public ValidadorReserva(
            IRepositorioPersona repoPersona,
            IRepositorioEventoDeportivo repoEvento,
            IRepositorioReserva repoReserva)
        {
            _repoPersona = repoPersona;
            _repoEvento = repoEvento;
            _repoReserva = repoReserva;
        }

        public void ValidarParaCrear(Reserva reserva)
        {
            // Validar existencia de Persona
            if (_repoPersona.ObtenerPorId(reserva.UsuarioId)==null)
                throw new ValidacionException($"La persona con ID {reserva.UsuarioId} no existe.");

            // Validar existencia de Evento
            var evento = _repoEvento.ObtenerPorId(reserva.EventoDeportivoId);
            if (evento is null)
                throw new ValidacionException($"El evento con ID {reserva.EventoDeportivoId} no existe.");

            // Validar duplicidad
            if (_repoReserva.ExisteReservaParaPersonaYEvento(reserva.UsuarioId, reserva.EventoDeportivoId))
                throw new ValidacionException("La persona ya tiene una reserva para este evento.");

            // Validar cupo
            int reservasActuales = _repoReserva.ContarReservasPorEvento(reserva.EventoDeportivoId);
            if (reservasActuales >= evento.CupoMaximo)
                throw new ValidacionException("No hay cupo disponible para este evento.");
        }
    }
}
