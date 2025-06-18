using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicio;
using CentroEventos.Aplicacion.Excepciones;

public class ServicioUsuario
{
    private readonly ServicioSesionUsuario _sesionUsuario;
    private readonly IRepositorioUsuario _repositorioUsuario;

    public ServicioUsuario(ServicioSesionUsuario sesionUsuario, IRepositorioUsuario repositorioUsuario)
    {
        _sesionUsuario = sesionUsuario;
        _repositorioUsuario = repositorioUsuario;
    }

    // Registrar nuevo usuario
    public ResultadoOperacion Registrar(Usuario usuario, string confirmarContrasenia)
    {
        try
        {
            // Validaciones básicas
            if (usuario == null)
                return ResultadoOperacion.Fallido("El usuario no puede ser nulo");

            if (string.IsNullOrWhiteSpace(usuario.Contrasenia))
                return ResultadoOperacion.Fallido("La contraseña no puede estar vacía");

            if (usuario.Contrasenia != confirmarContrasenia)
                return ResultadoOperacion.Fallido("Las contraseñas no coinciden");

            if (_repositorioUsuario.ObtenerPorEmail(usuario.Email) != null)
                return ResultadoOperacion.Fallido("Ya existe un usuario con este email");
            // Hash de la contraseña se hace en el repositorio
            usuario.FechaCreacion = DateTime.Now;

            // Guardar usuario
            _repositorioUsuario.Agregar(usuario);

            // Iniciar sesión automáticamente
            _sesionUsuario.IniciarSesion(usuario);

            return ResultadoOperacion.Exitoso("Usuario registrado con éxito");
        }
        catch (Exception ex)
        {
            // En un proyecto real, considera registrar este error
            return ResultadoOperacion.Fallido($"Error al registrar: {ex.Message}");
        }
    }

    // Iniciar sesión (versión síncrona)
    public ResultadoOperacion IniciarSesion(string email, string contrasenia)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(contrasenia))
                return ResultadoOperacion.Fallido("Email y contraseña son requeridos");

            var hashContrasenia = ObtenerHashSHA256(contrasenia);
            var usuario = _repositorioUsuario.ObtenerPorEmail(email);
            if (usuario == null)
                return ResultadoOperacion.Fallido("Usuario no encontrado");
            if (usuario.Contrasenia != hashContrasenia)
                return ResultadoOperacion.Fallido("Contraseña incorrecta");
            
            _sesionUsuario.IniciarSesion(usuario);

            return ResultadoOperacion.Exitoso("Inicio de sesión exitoso");
        }
        catch (Exception ex)
        {
            return ResultadoOperacion.Fallido($"Error al iniciar sesión: {ex.Message}");
        }
    }

    // Obtener usuario actual
    public Usuario ObtenerUsuarioActual()
    {
        return _sesionUsuario.ObtenerUsuarioActual();
    }

    // Cerrar sesión
    public void CerrarSesion()
    {
        _sesionUsuario.CerrarSesion();
    }

    // Método de hash (versión simplificada)
    private string ObtenerHashSHA256(string input)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
    }
}