//-----------------------------------------------------------------------
// <copyright file="IGestionCatalogos.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Cobis
{
    using Entidades.Catalogo;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IGestionCatalogos
    {
        DtoCatalogo ConsultarCatalogo(string nombreCatalogo);
    }
}
