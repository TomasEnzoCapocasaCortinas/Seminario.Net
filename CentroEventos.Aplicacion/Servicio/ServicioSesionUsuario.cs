using CentroEventos.Aplicacion.Entidades;
using System;
public class ServicioSesionUsuario
{
    private Usuario? _usuarioActual;
    
    public Usuario ObtenerUsuarioActual()
    {
        if (_usuarioActual == null)
        {
            throw new InvalidOperationException("No hay un usuario autenticado.");
        }
        return _usuarioActual;
    }

    public void IniciarSesion(Usuario usuario)
    {
        _usuarioActual = usuario;
    }

    public void CerrarSesion()
    {
        _usuarioActual = null;
    }
    
    public bool EstaAutenticado()
    {
        return _usuarioActual != null;
    }
}