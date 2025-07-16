using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class ModificarPersona
{
    private readonly IRepositorioPersona RepositorioP;
    private readonly PersonaValidador Validador;

    public ModificarPersona(IRepositorioPersona repositorio, PersonaValidador validador)
    {
        RepositorioP = repositorio;
        Validador = validador;
    }

    public void Ejecutar(Persona personaActualizada)
    {
        if(RepositorioP.ObtenerPorId(personaActualizada.Id)==null)
            throw new EntidadNotFoundException("No se encontró la persona");

        Validador.Validar(personaActualizada);
        if (!Validador.DNIUnico(personaActualizada))
            throw new DuplicadoException("Ya existe otra persona con ese DNI");

        if (!Validador.EmailUnico(personaActualizada))
            throw new DuplicadoException("Ya existe otra persona con ese email");
            
        RepositorioP.Actualizar(personaActualizada);
    }
}
