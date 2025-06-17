using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorUsuario
{
    public void Validar(Usuario usuario)
    {
        if (string.IsNullOrWhiteSpace(usuario.Nombre)) throw new Exception("Nombre requerido");
        if (string.IsNullOrWhiteSpace(usuario.Apellido)) throw new Exception("Apellido requerido");
        if (string.IsNullOrWhiteSpace(usuario.Email)) throw new Exception("Email requerido");
        if (string.IsNullOrWhiteSpace(usuario.Contrasenia)) throw new Exception("Contraseña requerida");
    }
}
