using System;
using CentroEventos.Aplicacion.Interfaces; //agregue esto
using CentroEventos.Aplicacion.Entidades; //agregue esto
using CentroEventos.Aplicacion.Excepciones; //agregue esto
namespace CentroEventos.Aplicacion.CasosDeUso;

public class CasoDeUsoModificacionPersona
{
    private readonly IRepositorioPersona RepositorioP;
    private readonly PersonaValidador Validador;

    public CasoDeUsoModificacionPersona(IRepositorioPersona repositorio, PersonaValidador validador)
    {
        RepositorioP = repositorio;
        Validador = validador;
    }

    public void Ejecutar(Persona personaActualizada)
    {
        var persona = RepositorioP.ObtenerPorId(personaActualizada.Id)
            ?? throw new EntidadNotFoundException("No se encontró la persona");

        Validador.Validar(personaActualizada);
        if (!Validador.DNIUnico(personaActualizada))
            throw new DuplicadoException("Ya existe otra persona con ese DNI");

        if (!Validador.EmailUnico(personaActualizada))
            throw new DuplicadoException("Ya existe otra persona con ese email");
            
        RepositorioP.Actualizar(personaActualizada);
    }
}
