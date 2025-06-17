using CentroEventos.Aplicacion.Interfaces; //agregue esto
using CentroEventos.Aplicacion.Entidades; //agregue esto
namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarUsuarios
{
    private readonly IRepositorioUsuario RepositorioU;

    public ListarUsuarios(IRepositorioUsuario repositorio)
    {
        RepositorioU = repositorio;
    }
    public List<Usuario> Ejecutar()
        {
        return RepositorioU.ObtenerTodos();
        }
}
