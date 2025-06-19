using System;
using System.Data;
using CentroEventos.Aplicacion.Interfaces; 
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class AltaUsuario
{
private readonly IRepositorioUsuario Repositorio;
    private readonly ValidadorUsuario Validador;

    public AltaUsuario(IRepositorioUsuario repo, ValidadorUsuario validador)
    {
        Repositorio = repo;
        Validador = validador;
    }

    public void Ejecutar(Usuario nuevoUsuario)
    {
        //Validador.Validar(nuevoUsuario);

        if (Repositorio.ObtenerPorEmail(nuevoUsuario.Email) != null)
            throw new DuplicadoException("Ya existe un usuario con ese email.");

        // Primer Usuario
        if (!Repositorio.HayUsuarios())
        {
            nuevoUsuario.Permisos = Enum.GetValues<Permiso>().ToList();
        }

        Repositorio.Agregar(nuevoUsuario);
    }
}
