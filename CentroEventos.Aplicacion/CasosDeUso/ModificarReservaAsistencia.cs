// Archivo: ModificarReservaAsistencia.cs
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ModificarReservaAsistencia
{
    private readonly IRepositorioReserva _repositorio;

    public ModificarReservaAsistencia(IRepositorioReserva repositorio)
    {
        _repositorio = repositorio;
    }

    public void Ejecutar(int reservaId, EstadoAsistencia nuevoEstado)
    {
        var reserva = _repositorio.ObtenerPorId(reservaId);
        if (reserva != null)
        {
            reserva.EstadoAsistencia = nuevoEstado;
            _repositorio.Modificar(reserva);
        }
        else
        {
            throw new Exception("Reserva no encontrada.");
        }
    }
}
