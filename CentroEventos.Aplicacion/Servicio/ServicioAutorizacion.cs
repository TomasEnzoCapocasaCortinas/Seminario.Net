
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Servicio;

public class ServicioAutorizacion : IServicioAutorizacion
{
    private readonly IRepositorioUsuario Repositorio;
    public ServicioAutorizacion(IRepositorioUsuario repo)
    {
        Repositorio = repo;
    }

    public bool PoseeElPermiso(int idUsuario, Permiso permisoRequerido)
    {
        var usuario = Repositorio.ObtenerPorId(idUsuario)
            ?? throw new EntidadNotFoundException("El usuario no existe");

        return usuario.Permisos.Contains(permisoRequerido);
    }

}