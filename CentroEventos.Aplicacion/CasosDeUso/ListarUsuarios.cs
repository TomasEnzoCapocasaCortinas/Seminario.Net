using CentroEventos.Aplicacion.Interfaces; 
using CentroEventos.Aplicacion.Entidades; 
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
