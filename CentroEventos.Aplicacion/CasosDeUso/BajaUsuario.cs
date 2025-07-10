using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
namespace CentroEventos.Aplicacion.CasosDeUso;
public class BajaUsuario
{
    private IRepositorioUsuario RepositorioU;
    private IServicioAutorizacion Autorizacion;

    public BajaUsuario(IRepositorioUsuario RepoUsuario, IServicioAutorizacion autorizacion)
    {
        Autorizacion = autorizacion;
        RepositorioU = RepoUsuario;
    }
    public void Ejecutar(int IdEliminar, int IdUsuario)
    {
        if (!Autorizacion.PoseeElPermiso(IdUsuario, Permiso.PersonaBaja))
        {
            throw new FalloAutorizacionException("No posee el permiso para realizar esta accion.");
        }

        var usuario = RepositorioU.ObtenerPorId(IdEliminar);
        if (usuario == null) throw new EntidadNotFoundException("No se encontró el usuario para eliminar");

        RepositorioU.Eliminar(IdEliminar);
    }
}