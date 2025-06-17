using System;
using System.Collections.Generic;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IRepositorioPersona
{
    void Agregar(Persona persona);
    Persona? ObtenerPorId(int id);
    Persona? ObtenerPorDNI(string dni);
    Persona? ObtenerPorEmail(string email);
    List<Persona> ObtenerTodas();
    void Actualizar(Persona persona);
    void Eliminar(int id);
}

