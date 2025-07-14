using System;
using System.Data;
using CentroEventos.Aplicacion.Interfaces; 
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class AltaPersona
{
    private readonly IRepositorioPersona RepositorioP;

    private readonly PersonaValidador _validador;

    public AltaPersona(IRepositorioPersona repositorio, PersonaValidador validador)
    {
        RepositorioP = repositorio;
        _validador = validador;
    }
    public void Ejecutar (Persona nuevaPersona)
    {
        _validador.Validar(nuevaPersona);
        
        if (!_validador.DNIUnico(nuevaPersona))
            throw new DuplicadoException("Ya existe una persona con ese DNI.");

        if (!_validador.EmailUnico(nuevaPersona))
            throw new DuplicadoException("Ya existe una persona con ese Email.");

        RepositorioP.Agregar(nuevaPersona);
    }
}
