using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorUsuario
{
    public void Validar(Usuario usuario)
    {
        if (string.IsNullOrWhiteSpace(usuario.Nombre)) throw new ValidacionException("Nombre requerido");
        if (string.IsNullOrWhiteSpace(usuario.Apellido)) throw new ValidacionException("Apellido requerido");
        if (string.IsNullOrWhiteSpace(usuario.Email)) throw new ValidacionException("Email requerido");
        if (string.IsNullOrWhiteSpace(usuario.Contrasenia)) throw new ValidacionException("Contraseña requerida");
    }
}
