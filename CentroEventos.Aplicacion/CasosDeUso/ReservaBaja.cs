using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enumerativos; 

namespace CentroEventos.Aplicacion.CasosDeUso
{
    public class ReservaBaja
    {
        private readonly IRepositorioReserva _repoReserva;
        private readonly IServicioAutorizacion _autorizacion;

        public ReservaBaja(
            IRepositorioReserva repoReserva,
            IServicioAutorizacion autorizacion)
        {
            _repoReserva = repoReserva;
            _autorizacion = autorizacion;
        }

        public void Ejecutar(int idReserva, int idUsuario)
        {
            if (!_autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaBaja)) 
                throw new FalloAutorizacionException("No posee el permiso de dar de baja una reserva"); 

            var reserva = _repoReserva.ObtenerPorId(idReserva)
                ?? throw new EntidadNotFoundException("Reserva no encontrada");

            _repoReserva.Eliminar(idReserva);
        }
    }
}
