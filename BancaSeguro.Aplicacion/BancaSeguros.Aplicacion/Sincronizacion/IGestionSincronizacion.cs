//-----------------------------------------------------------------------
// <copyright file="IGestionSincronizacion.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Sincronizacion
{
    using BancaSeguros.Entidades.General;

    /// <summary>
    /// Interface Management sync up
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 19/08/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IGestionSincronizacion
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
        //Resultado SincronizarOficinas();
        //BancaSeguros.Entidades.Catalogo.ListaOficinas SincronizarOficinas();
        Resultado SincronizarOficinas();
    }


}
