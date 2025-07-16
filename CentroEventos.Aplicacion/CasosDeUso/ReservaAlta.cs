using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso
{
    public class ReservaAlta
    {
        private readonly IRepositorioReserva _repoReserva;
        private readonly IRepositorioEventoDeportivo _repoEvento;
        private readonly IRepositorioUsuario _repoUsuario;
        private readonly IServicioAutorizacion _autorizacion;
        private readonly ValidadorReserva _validador;

        public ReservaAlta(
            IRepositorioReserva repoReserva,
            IRepositorioEventoDeportivo repoEvento,
            IRepositorioUsuario repoUsuario,
            IServicioAutorizacion autorizacion,
            ValidadorReserva validador)
        {
            _repoReserva = repoReserva;
            _repoEvento = repoEvento;
            _repoUsuario = repoUsuario;
            _autorizacion = autorizacion;
            _validador = validador;
        }

        public void Ejecutar(Reserva datosReserva, int idUsuario)
        {
            if (!_autorizacion.PoseeElPermiso(idUsuario, Permiso.ReservaAlta))
                throw new FalloAutorizacionException("No está autorizado para hacer una alta");

            _validador.ValidarParaCrear(datosReserva);

            datosReserva.FechaAltaReserva = DateTime.Now;
            datosReserva.EstadoAsistencia = EstadoAsistencia.Pendiente;

            _repoReserva.Agregar(datosReserva);
        }
    }
}