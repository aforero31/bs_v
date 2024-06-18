//-----------------------------------------------------------------------
// <copyright file="GestionGenerico.cs" company="UT">
//     Copyright (c) UT. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion
{
    using System;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Repositorio;

    /// <summary>
    /// Management generic
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 05/08/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Aplicacion.IGestionGenerico" />
    public class GestionGenerico : IGestionGenerico
    {
        /// <summary>
        /// The repository generic
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 05/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioGenerico repositorioGenerico;

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionGenerico"/> class.
        /// </summary>
        /// <param name="repositorioGenerico">The repository generic.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 05/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public GestionGenerico(IRepositorioGenerico repositorioGenerico)
        {
            this.repositorioGenerico = repositorioGenerico;
        }

        /// <summary>
        /// Get the catalog.
        /// </summary>
        /// <param name="nombreTabla">The name table.</param>
        /// <returns>Entity catalog</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 05/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DtoCatalogo ConsultarCatalogo(string nombreTabla)
        {
            return this.repositorioGenerico.ConsultarCatalogo(nombreTabla);
        }

        /// <summary>
        /// Save the error.
        /// </summary>
        /// <param name="exc">The exception.</param>
        /// <returns>number number</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 05/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Int64 GuardarError(string exc)
        {
            return this.repositorioGenerico.GuardarError(exc);
        }

        /// <summary>
        /// Save the error.
        /// </summary>
        /// <param name="exc">The exception.</param>
        /// <returns>number number</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 05/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Int64 GuardarError(Exception exc)
        {
            Int64 retorno = 0;

            try
            {
                System.Text.StringBuilder s = new System.Text.StringBuilder();
                while (exc != null)
                {
                    s.AppendLine("Exception type: " + exc.GetType().FullName);
                    s.AppendLine("Message       : " + exc.Message);
                    s.AppendLine("Stacktrace:");
                    s.AppendLine(exc.StackTrace);
                    s.AppendLine();
                    exc = exc.InnerException;
                }

                return this.repositorioGenerico.GuardarError(s.ToString());
            }
            catch (Exception ex)
            {
                string mensaje = ex.ToString();
            }

            return retorno;
        }
    }
}
