//-----------------------------------------------------------------------
// <copyright file="IGestionConvenio.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Cobis
{
    using Entidades.General;
    using Entidades.Seguro;
    using Entidades.Venta;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface Management agreement
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 11/07/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IGestionConvenio
    {
        List<Entidades.Seguro.Convenio> ConsultarConveniosActivos(Aseguradora aseguradora);
    }
}
