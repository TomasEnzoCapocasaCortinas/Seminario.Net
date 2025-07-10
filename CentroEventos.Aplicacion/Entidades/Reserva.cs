using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.Entidades
{
    public class Reserva
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int EventoDeportivoId { get; set; }
        public DateTime FechaAltaReserva { get; set; } = DateTime.Now;
        public EstadoAsistencia EstadoAsistencia { get; set; } = EstadoAsistencia.Pendiente;

        public override string ToString()
        {
            return $"[Reserva #{Id}] UsuarioId: {UsuarioId}, EventoId: {EventoDeportivoId}, " +
                   $"FechaAlta: {FechaAltaReserva:g}, Estado: {EstadoAsistencia}";
        }
    }
}