using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarAsistenciaAEvento
{
    private readonly IRepositorioReserva repositorioReserva;
    private readonly IRepositorioUsuario repositorioUsuario;

    public ListarAsistenciaAEvento(IRepositorioReserva repoReserva, IRepositorioUsuario repoUsuario)
    {
        repositorioReserva = repoReserva;
        repositorioUsuario = repoUsuario;
    }

    public List<Usuario> Ejecutar(int eventoId)
    {
        var reservas = repositorioReserva.ObtenerReservasPorEvento(eventoId);

        var presente = new List<Usuario>();

        foreach (var reserva in reservas)
        {
            var usuario = repositorioUsuario.ObtenerPorId(reserva.UsuarioId);
            if (usuario != null && reserva.EstadoAsistencia==EstadoAsistencia.Presente)
            {
                presente.Add(usuario);
            }
        }

        return presente;
    }
}
