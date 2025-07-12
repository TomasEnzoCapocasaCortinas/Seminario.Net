using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Entidades; 
//repo persona???

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
    public void Ejecutar(EventoDeportivo evento)
    {
        _validador.ValidarAlta(evento);
        _repositorio.Agregar(evento);
    }
}
