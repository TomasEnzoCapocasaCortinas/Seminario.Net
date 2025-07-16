using System;
using System.Security.Cryptography;
using System.Text;
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

    public Usuario Agregar(Usuario usuario)
    {
        //hash contrasenia SHA256 del espacio de nombres System.Security.Cryptography
        usuario.Contrasenia = ObtenerHashSHA256(usuario.Contrasenia);
        dataBase.Usuarios.Add(usuario);
        dataBase.SaveChanges();
        return usuario; 
    }

    static string ObtenerHashSHA256(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);             // Convertir la cadena a bytes
            byte[] hashBytes = sha256.ComputeHash(bytes);             // Obtener el hash

            // Convertir el hash a string hexadecimal
            StringBuilder builder = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("x2")); // Formato hexadecimal
            }

            return builder.ToString();
        }
    }
    public void Modificar(Usuario usuario, string? contraseniaNueva){
        if (!string.IsNullOrWhiteSpace(contraseniaNueva))
        {
        usuario.Contrasenia = ObtenerHashSHA256(contraseniaNueva);
        }
    // Si no vino contraseña nueva, se mantiene el hash anterior
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
