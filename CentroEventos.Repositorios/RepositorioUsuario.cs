using System; //actualizado con base de datos
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Repositorios;

public class RepositorioUsuario : IRepositorioUsuario
{
private readonly CentroEventosDbContext dataBase;

    public RepositorioUsuario(CentroEventosDbContext db)
    {
        dataBase = db;
    }

    public void Agregar(Usuario usuario)
    {
        dataBase.Usuarios.Add(usuario);
        dataBase.SaveChanges();
    }

    public void Modificar(Usuario usuario)
    {
        dataBase.Usuarios.Update(usuario);
        dataBase.SaveChanges();
    }

    public void Eliminar(int id)
    {
        var usuario = dataBase.Usuarios.Find(id);
        if (usuario != null)
        {
            dataBase.Usuarios.Remove(usuario);
            dataBase.SaveChanges();
        }
    }

    public Usuario? ObtenerPorId(int id) => dataBase.Usuarios.Find(id);
    public Usuario? ObtenerPorEmail(string email) => dataBase.Usuarios.FirstOrDefault(u => u.Email == email);
    public List<Usuario> ObtenerTodos() => dataBase.Usuarios.ToList();
    public bool HayUsuarios() => dataBase.Usuarios.Any();
}
