//-----------------------------------------------------------------------
// <copyright file="IServicioSincronizacion.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.ServiciosWCF.Sincronizacion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Catalogo;

    [ServiceContract]
    public interface IServicioSincronizacion
    {
        /// <summary>
        /// sync up catalogs.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 09/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        Resultado SincronizarCatalogos();

        /// <summary>
        /// sync up oficinas.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 08/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        Resultado SincronizarOficinas();

    }


}
