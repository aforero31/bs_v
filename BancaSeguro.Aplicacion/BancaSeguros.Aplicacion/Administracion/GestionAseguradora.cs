//-----------------------------------------------------------------------
// <copyright file="GestionAseguradora.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Administracion
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Repositorio.Administracion;
    using System;
    
    /// <summary>
    /// Class Insurance Management
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 18/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionAseguradora" />
    public class GestionAseguradora : IGestionAseguradora
    {
        #region Variables

        /// <summary>
        /// The interface insurance repository
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioAseguradora repositorioAseguradora;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionAseguradora"/> class.
        /// </summary>
        /// <param name="interfazRepositorioAseguradora">The interface insurance repository.</param>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public GestionAseguradora(IRepositorioAseguradora interfazRepositorioAseguradora)
        {
            this.repositorioAseguradora = interfazRepositorioAseguradora;
        }

        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Search insurances.
        /// </summary>
        /// <param name="aseguradora">The insurance to search.</param>
        /// <returns>List of insurances</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Aseguradora> ConsultarAseguradoras(Aseguradora aseguradora)
        {
           return this.repositorioAseguradora.ConsultarAseguradoras(aseguradora);
        }

        /// <summary>
        /// gets actives insurances.
        /// </summary>
        /// <returns>list of actives insurances </returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Aseguradora> ConsultarAseguradorasActivas()
        {
            Aseguradora aseguradora = new Aseguradora();

            aseguradora.Activo = true;
            aseguradora.Nombre = null;
            aseguradora.TipoIdentificacion = null;
            aseguradora.Identificacion = null;
            aseguradora.CodigoSuperintendencia = null;

            return this.repositorioAseguradora.ConsultarAseguradoras(aseguradora);
        }

        /// <summary>
        /// Search Insurance by identifier.
        /// </summary>
        /// <param name="idAseguradora">The identifier.</param>
        /// <returns>Entity Insurance</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Aseguradora ConsultarAseguradoraPorId(int idAseguradora)
        {
            return this.repositorioAseguradora.ConsultarAseguradoraPorId(idAseguradora);
        }

        /// <summary>
        /// Inserts the Insurance.
        /// </summary>
        /// <param name="aseguradora">The Insurance</param>
        /// <returns>Result operation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado InsertarAseguradora(Aseguradora aseguradora)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado =  this.repositorioAseguradora.InsertarAseguradora(aseguradora);
                if (resultado.Error)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(Configuraciones.LlavesAplicacion.EventoParametrizacionAseguradoraInsertar), Configuraciones.LlavesAplicacion.AseguradoraExisteInsertar);  //Mensajes.CodigoAseguradoraExistente; 
                    resultado.Error = true;
                }
                else if (!resultado.Error)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(Configuraciones.LlavesAplicacion.EventoParametrizacionAseguradoraInsertar), Configuraciones.LlavesAplicacion.InsertarAseguradora);
                    resultado.Error = false;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(Configuraciones.LlavesAplicacion.EventoParametrizacionAseguradoraInsertar), ex, Configuraciones.LlavesAplicacion.CatchInsertaAseguradora).Mensaje;
            }
            return resultado;
        }

        /// <summary>
        /// Update Insurance.
        /// </summary>
        /// <param name="aseguradora">The insurance.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizarAseguradora(Aseguradora aseguradora)
        {
            Resultado resultado = new Resultado();
            try 
            {
                resultado = this.repositorioAseguradora.ActualizarAseguradora(aseguradora);
                if (resultado.Error)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(Configuraciones.LlavesAplicacion.EventoParametrizarAseguradoraActualizar), Configuraciones.LlavesAplicacion.AseguradoraNoActualiza); //Mensajes.CodigoAseguradoraExistente;
                    resultado.Error = true;
                }
                else if (!resultado.Error)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(Configuraciones.LlavesAplicacion.EventoParametrizarAseguradoraActualizar), Configuraciones.LlavesAplicacion.ActualizaAseguradora);
                    resultado.Error = false;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(Configuraciones.LlavesAplicacion.EventoParametrizarAseguradoraActualizar), ex, Configuraciones.LlavesAplicacion.CatchActualizaAseguradora).Mensaje;
            }
            return resultado;
        }



        #endregion
    }
}
