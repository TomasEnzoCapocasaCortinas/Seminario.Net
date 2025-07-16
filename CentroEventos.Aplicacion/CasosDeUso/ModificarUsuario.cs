using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ModificarUsuario
{
    private readonly IRepositorioUsuario RepositorioU;
    private readonly ValidadorUsuario Validador;

    public ModificarUsuario(IRepositorioUsuario repositorio, ValidadorUsuario validador)
    {
        RepositorioU = repositorio;
        Validador = validador;
    }

    public void Ejecutar(Usuario usuarioActualizado, string? contrasenia)
    {
        var usuario = RepositorioU.ObtenerPorId(usuarioActualizado.Id)
            ?? throw new EntidadNotFoundException("El usuario no existe");

        if (usuarioActualizado.Email != usuario.Email && RepositorioU.ObtenerPorEmail(usuarioActualizado.Email) != null)
            throw new DuplicadoException("Ya existe otro usuario con ese email");

        Validador.Validar(usuarioActualizado);
        RepositorioU.Modificar(usuarioActualizado, contrasenia);
    }
}