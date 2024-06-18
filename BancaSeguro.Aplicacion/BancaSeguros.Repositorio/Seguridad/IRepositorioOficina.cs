using System;
using System.Collections.Generic;
using BAC.EntidadesSeguridad;

namespace BancaSeguros.Repositorio.Seguridad
{
    public interface IRepositorioOficina
    {
        Oficina ConsultarOficinaPorCodigo(int idOficina);
    }
}
