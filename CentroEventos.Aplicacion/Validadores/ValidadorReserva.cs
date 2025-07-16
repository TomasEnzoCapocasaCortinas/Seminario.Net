using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Validadores
{
    public class ValidadorReserva
    {
        private readonly IRepositorioUsuario _repoUsuario;
        private readonly IRepositorioEventoDeportivo _repoEvento;
        private readonly IRepositorioReserva _repoReserva;

        public ValidadorReserva(
            IRepositorioUsuario repoUsuario,
            IRepositorioEventoDeportivo repoEvento,
            IRepositorioReserva repoReserva)
        {
            _repoUsuario = repoUsuario;
            _repoEvento = repoEvento;
            _repoReserva = repoReserva;
        }

        public void ValidarParaCrear(Reserva reserva)
        {   
            // Validar existencia de Usuario
            if (_repoUsuario.ObtenerPorId(reserva.UsuarioId)==null)
                throw new ValidacionException($"La Usuario con ID {reserva.UsuarioId} no existe.");

            // Validar existencia de Evento
            var evento = _repoEvento.ObtenerPorId(reserva.EventoDeportivoId);
            if (evento is null)
                throw new ValidacionException($"El evento con ID {reserva.EventoDeportivoId} no existe.");

            // Valida la hora de la inscripcion
            if (evento.FechaHoraInicio <= DateTime.Now)
                throw new ValidacionException("No se pueden reservar eventos que ya comenzaron.");

            // Validar duplicidad
            if (_repoReserva.ExisteReservaParaPersonaYEvento(reserva.UsuarioId, reserva.EventoDeportivoId))
                throw new ValidacionException("El Usuario ya tiene una reserva para este evento.");

            // Validar cupo
            int reservasActuales = _repoReserva.ContarReservasPorEvento(reserva.EventoDeportivoId);
            if (reservasActuales >= evento.CupoMaximo)
                throw new ValidacionException("No hay cupo disponible para este evento.");
        }
    }
}
