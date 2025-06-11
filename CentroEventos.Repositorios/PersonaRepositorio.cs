namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion.Excepciones; //agregue esto
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
public class PersonaRepositorio : IRepositorioPersona
{
    private string ArchivoPersona = "personas.txt";
    private int ProximoId;
    public PersonaRepositorio()
    {
        if (!File.Exists(ArchivoPersona))
            File.Create(ArchivoPersona).Close();

        ProximoId = CalcularProximoId();
    }

    private int CalcularProximoId()
    {
        var lineas = File.ReadAllLines(ArchivoPersona);
        if (lineas.Length == 0) return 1;

        return lineas.Select(l => int.Parse(l.Split('|')[0])).Max() + 1;
    }
    public Persona Agregar(Persona p)
    {
        p.IdUsuario = ProximoId++;
        var linea = $"{p.IdUsuario}|{p.Nombre}|{p.Apellido}|{p.Dni}|{p.Email}|{p.Tel}";
        File.AppendAllText(ArchivoPersona, linea + Environment.NewLine);
        return p;
    }
    public Persona? ObtenerPorId(int id)
    {
        return ObtenerTodas().FirstOrDefault(p => p.IdUsuario == id);
    }

    public Persona? ObtenerPorDNI(string dni)
    {
        return ObtenerTodas().FirstOrDefault(p => p.Dni == dni);
    }

    public Persona? ObtenerPorEmail(string email)
    {
        return ObtenerTodas().FirstOrDefault(p => p.Email == email);
    }

    public List<Persona> ObtenerTodas()
    {
        var personas = new List<Persona>();
        foreach (var linea in File.ReadAllLines(ArchivoPersona))
        {
            var datos = linea.Split('|');
            personas.Add(new Persona(int.Parse(datos[0]),datos[1],datos[2],datos[3],datos[4],datos[5]));
        }
        return personas;
    }
    public bool Actualizar(Persona p)
    {
        var personas = ObtenerTodas();
        int i = 0;
        bool actualizado = false;

        while (i < personas.Count && !actualizado)
        {
            if (personas[i].IdUsuario == p.IdUsuario)
            {
                personas[i] = p;
                actualizado = true;
            }
            i++;
        }
        if (!actualizado)
        {
            throw new EntidadNotFoundException($"No se encontro a la persona con. ${p.IdUsuario} ");
        }
        var linea = personas.Select(p => $"{p.IdUsuario}|{p.Nombre}|{p.Apellido}|{p.Dni}|{p.Email}|{p.Tel}");
        File.WriteAllLines(ArchivoPersona, linea);
        return actualizado;
    }

    public bool Eliminar(int id)
    {
        var personas = ObtenerTodas();
        var persona = personas.FirstOrDefault(p => p.IdUsuario == id);
        if (persona == null) return false;

        personas.Remove(persona);
        var linea = personas.Select(p=> $"{p.IdUsuario}|{p.Nombre}|{p.Apellido}|{p.Dni}|{p.Email}|{p.Tel}");
        File.WriteAllLines(ArchivoPersona, linea);
        return true;
    }
}
