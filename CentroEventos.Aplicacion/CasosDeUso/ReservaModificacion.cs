using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enumerativos; //agregue esto

namespace CentroEventos.Aplicacion.CasosDeUso
{
    public class ReservaModificacion
    {
        private readonly IRepositorioReserva _repoReserva;
        private readonly IServicioAutorizacion _autorizacion;

        public ReservaModificacion(
            IRepositorioReserva repoReserva,
            IServicioAutorizacion autorizacion)
        {
            _repoReserva = repoReserva;
            _autorizacion = autorizacion;
        }

        public void Ejecutar(Reserva reservaModificada, int idUsuario)
        {
            if (!_autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaModificacion)) //antes era PoseePermiso,  "ReservaModificacion"
                throw new FalloAutorizacionException("No tiene permiso de modificar la reserva"); //no se que string poner

            var reservaExistente = _repoReserva.ObtenerPorId(reservaModificada.Id)
                ?? throw new EntidadNotFoundException("Reserva no encontrada");

            reservaExistente.EstadoAsistencia = reservaModificada.EstadoAsistencia;

            _repoReserva.Modificar(reservaExistente);
        }
    }
}
