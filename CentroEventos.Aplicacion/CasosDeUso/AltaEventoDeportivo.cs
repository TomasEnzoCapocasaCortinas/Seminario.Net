using System;
using CentroEventos.Aplicacion.Interfaces; //agregue esto
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Entidades; //agregue esto


namespace CentroEventos.Aplicacion.CasosDeUso;

public class AltaEventoDeportivo
{
    private readonly IRepositorioEventoDeportivo _repositorio;
    private readonly IRepositorioPersona repoPersona;
    private readonly ValidadorEventoDeportivo _validador;

    public AltaEventoDeportivo(IRepositorioEventoDeportivo repositorio, IRepositorioPersona repoP)
    {
        _repositorio = repositorio;
        repoPersona = repoP;
        _validador = new ValidadorEventoDeportivo(repoP);
    }
    public void Ejecutar(EventoDeportivo evento, int PersonaId)
    {
        _validador.ValidarAlta(evento); //Falta una variable IRepositorioPersona 
        _repositorio.Agregar(evento);
    }
}
