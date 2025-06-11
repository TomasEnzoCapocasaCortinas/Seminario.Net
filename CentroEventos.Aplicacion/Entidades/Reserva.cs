using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.Entidades
{
    public class Reserva
    {
        public int Id { get; set; } // Gestionado por el repositorio (autoincremental)
        public int PersonaId { get; set; }
        public int EventoDeportivoId { get; set; }
        public DateTime FechaAltaReserva { get; set; } = DateTime.Now;
        public EstadoAsistencia EstadoAsistencia { get; set; } = EstadoAsistencia.Pendiente;

        public override string ToString()
        {
            return $"[Reserva #{Id}] PersonaId: {PersonaId}, EventoId: {EventoDeportivoId}, " +
                   $"FechaAlta: {FechaAltaReserva:g}, Estado: {EstadoAsistencia}";
        }
    }
}