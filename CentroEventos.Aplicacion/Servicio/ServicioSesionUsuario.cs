using CentroEventos.Aplicacion.Entidades;
using System;

public class ServicioSesionUsuario
{
    private static Usuario? _usuarioActual;

    public event Action? OnChange;

    private void NotificarCambio()
    {
    Console.WriteLine(">> Notificando cambio de sesión");
    OnChange?.Invoke();
    }

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
        NotificarCambio();
    }

    public void CerrarSesion()
    {
        _usuarioActual = null;
        NotificarCambio();
    }

    public bool EstaAutenticado()
    {
        return _usuarioActual != null;
    }
}