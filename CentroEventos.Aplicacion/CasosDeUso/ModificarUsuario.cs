using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ModificarUsuario
{
    private readonly IRepositorioUsuario RepositorioU;
    private readonly IServicioAutorizacion Autorizacion;
    private readonly ValidadorUsuario Validador;

    public ModificarUsuario(IRepositorioUsuario repositorio, IServicioAutorizacion autorizador, ValidadorUsuario validador)
    {
        RepositorioU = repositorio;
        Autorizacion = autorizador;
        Validador = validador;
    }

    public void Ejecutar(Usuario usuarioActualizado, int idUsuario)
    {
        if (!Autorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioModificacion))
            throw new FalloAutorizacionException("No tiene permiso para modificar usuarios");

        var usuario = RepositorioU.ObtenerPorId(usuarioActualizado.Id)
            ?? throw new EntidadNotFoundException("El usuario no existe");

        if (usuarioActualizado.Email != usuario.Email && RepositorioU.ObtenerPorEmail(usuarioActualizado.Email) != null)
            throw new DuplicadoException("Ya existe otro usuario con ese email");

        Validador.Validar(usuarioActualizado);
        RepositorioU.Modificar(usuarioActualizado);
    }
}