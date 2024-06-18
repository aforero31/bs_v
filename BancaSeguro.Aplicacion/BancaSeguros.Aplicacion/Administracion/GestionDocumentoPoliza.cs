//-----------------------------------------------------------------------
// <copyright file="GestionDocumentoPoliza.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Repositorio.Venta;

    public class GestionDocumentoPoliza : IGestionDocumentoPoliza
    {

        #region Variables

        /// <summary>
        /// The repository document policy
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 08/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioDocumentoPoliza repositorioDocumentoPoliza;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionDocumentoPoliza"/> class.
        /// </summary>
        /// <param name="repositorioDocumentoPoliza">The repository document policy.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 08/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public GestionDocumentoPoliza(IRepositorioDocumentoPoliza repositorioDocumentoPoliza)
        {
            this.repositorioDocumentoPoliza = repositorioDocumentoPoliza;
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// gets the list template active.
        /// </summary>
        /// <returns>list entity</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 08/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<DocumentoPoliza> ConsultarPlantillasActivas()
        {
            return this.repositorioDocumentoPoliza.ConsultarPlantillasActivas();
        }

        #endregion
    }
}
