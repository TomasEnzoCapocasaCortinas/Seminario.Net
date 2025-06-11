using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enumerativos; // agregue esto

namespace CentroEventos.Aplicacion.CasosDeUso
{
    public class ReservaAlta
    {
        private readonly IRepositorioReserva _repoReserva;
        private readonly IRepositorioEventoDeportivo _repoEvento;
        private readonly IRepositorioPersona _repoPersona;
        private readonly IServicioAutorizacion _autorizacion;

        public ReservaAlta(
            IRepositorioReserva repoReserva,
            IRepositorioEventoDeportivo repoEvento,
            IRepositorioPersona repoPersona,
            IServicioAutorizacion autorizacion)
        {
            _repoReserva = repoReserva;
            _repoEvento = repoEvento;
            _repoPersona = repoPersona;
            _autorizacion = autorizacion;
        }

        public void Ejecutar(Reserva datosReserva, int idUsuario)
        {
            if (!_autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaAlta)) // poseeElpermiso, agregue permiso.reservaalta
                throw new FalloAutorizacionException("No está autorizado para hacer una alta"); //agregue el mensaje

            var persona = _repoPersona.ObtenerPorId(datosReserva.PersonaId)
                ?? throw new EntidadNotFoundException("Persona no encontrada");

            var evento = _repoEvento.ObtenerPorId(datosReserva.EventoDeportivoId) ?? throw new EntidadNotFoundException("Evento deportivo no encontrado");

            var reservasEvento = _repoReserva.ObtenerReservasPorEvento(evento.ID); //obtener reservas por evento, ID con mayus

            if (reservasEvento.Count >= evento.CupoMaximo)
                throw new CupoExcedidoException("Los cupos están agotados"); //agregue el mensaje

            if (reservasEvento.Any(r => r.PersonaId == datosReserva.PersonaId))
                throw new DuplicadoException("Reserva duplicada para este evento");

            datosReserva.FechaAltaReserva = DateTime.Now;
            datosReserva.EstadoAsistencia = EstadoAsistencia.Pendiente;

            _repoReserva.Agregar(datosReserva);
        }
    }
}