using System;
using System.Collections.Generic;
using BAC.EntidadesSeguridad;
using BancaSeguros.Entidades;
using BancaSeguros.Entidades.Catalogo;

namespace BancaSeguros.Repositorio
{
    public interface IRepositorioGenerico
    {
       DtoCatalogo ConsultarCatalogo(string NombreTabla);

       Int64 GuardarError(string exc);
    }
}
