using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ObtenerUsuarioPorId
{
    private readonly IRepositorioUsuario repositorioUsuario;

    public ObtenerUsuarioPorId(IRepositorioUsuario repo)
    {
        repositorioUsuario = repo;
    }
    public Usuario Ejecutar(int id)
    {
        var usuario = repositorioUsuario.ObtenerPorId(id);
        if (usuario == null)
            throw new EntidadNotFoundException("Usuario no econtrado");
        return usuario;
    }
}
