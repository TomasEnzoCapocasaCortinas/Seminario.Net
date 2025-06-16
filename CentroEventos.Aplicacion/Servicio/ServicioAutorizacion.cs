
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.Servicio;

public class ServicioAutorizacion : IServicioAutorizacion
{
    private readonly IRepositorioUsuario Repositorio;
    public ServicioAutorizacion(IRepositorioUsuario repo)
    {
        Repositorio = repo;
    }

    public void PoseeElPermiso(int idUsuario, Permiso permisoRequerido)
    {
        var usuario = Repositorio.ObtenerPorId(idUsuario)
            ?? throw new Exception("Usuario no encontrado");

        if (!usuario.Permisos.Contains(permisoRequerido))
            throw new Exception($"No tiene permiso: {permisoRequerido}");
    }

}