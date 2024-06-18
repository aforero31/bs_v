//-----------------------------------------------------------------------
// <copyright file="IRepositorioSincronizacion.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Sincronizacion
{
    using Entidades.General;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepositorioSincronizacion
    {
        Resultado GuardarDatosEnBaseDatos(string nombreCatalogo, DataTable datos);
    }
}
