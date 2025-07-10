namespace CentroEventos.Repositorios; //actualizado con base de datos

using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
public class PersonaRepositorio : IRepositorioPersona
{
    private readonly CentroEventosDbContext dataBase;

    public PersonaRepositorio(CentroEventosDbContext db)
    {
        dataBase = db;
    }
    public void Agregar(Persona p)
    {
        dataBase.Personas.Add(p);
        dataBase.SaveChanges();

    }
    public Persona? ObtenerPorId(int id)
    {
        return dataBase.Personas.Find(id);
    }

    public Persona? ObtenerPorDNI(string dni) => dataBase.Personas.FirstOrDefault(p => p.Dni == dni);

    public Persona? ObtenerPorEmail(string email) => dataBase.Personas.FirstOrDefault(p => p.Email == email);

    public List<Persona> ObtenerTodas()
    {
        return dataBase.Personas.ToList();
    }
    public void Actualizar(Persona p)
    {
        if (p == null)
        {
            throw new ArgumentNullException(nameof(p), "La persona no puede ser nula.");
        }
        dataBase.Personas.Update(p);
        dataBase.SaveChanges();
    }

    public bool Eliminar(int id)
    {
        var persona = dataBase.Personas.Find(id);
        if (persona != null)
        {
            dataBase.Personas.Remove(persona);
            dataBase.SaveChanges();
            return true;
        }
        return false;
    }
}
