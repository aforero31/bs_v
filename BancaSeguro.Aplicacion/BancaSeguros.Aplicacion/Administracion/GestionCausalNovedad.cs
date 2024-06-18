
namespace BancaSeguros.Aplicacion.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using BancaSeguros.Aplicacion.Configuraciones;
    using BancaSeguros.Entidades.Administracion;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Infraestructura.ManejoDocumentos;
    using BancaSeguros.Repositorio.Administracion;
    using BancaSeguros.Repositorio.Venta;

    /// <summary>
    /// Interface Management Causal Novelty
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA   
    /// CreationDate: 27/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionCausalNovedad" />

    public class GestionCausalNovedad : IGestionCausalNovedad
    {
        #region Variables
        /// <summary>
        /// The repository Causal Novelty
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioCausalNovedad repositorioCausalNovedad;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionCausalNovedad"/> class.
        /// </summary>
        /// <param name="interfazRepositorioCausalNovedad">The interface repository Causal Novelty.</param>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public GestionCausalNovedad(IRepositorioCausalNovedad interfazRepositorioCausalNovedad)
        {
            this.repositorioCausalNovedad = interfazRepositorioCausalNovedad;
        }

        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Save the Causal Novelty.
        /// </summary>
        /// <param name="causal novelty">The Causal Novelty.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado InsertarCausalNovedad(CausalNovedad causalNovedad)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioCausalNovedad.InsertarCausalNovedad(causalNovedad);
                if (resultado.Error == false)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(Configuraciones.LlavesAplicacion.EventoGuardarCausalNovedad), Configuraciones.LlavesAplicacion.InsertarCausalNovedad); 
                    resultado.Error = false;
                }
                else
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(Configuraciones.LlavesAplicacion.EventoGuardarCausalNovedad), Configuraciones.LlavesAplicacion.InsertarCausalNovedadNoExitoso); 
                    resultado.Error = true;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(Configuraciones.LlavesAplicacion.EventoGuardarCausalNovedad), ex, Configuraciones.LlavesAplicacion.CatchInsertarCausalNovedad).Mensaje;
            }

            return resultado;
        }

        /// <summary>
        /// Update the Causal Novelty.
        /// </summary>
        /// <param name="causal novelty">The Causal Novelty.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizarCausalNovedad(CausalNovedad causalNovedad)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioCausalNovedad.ActualizarCausalNovedad(causalNovedad);
                if (resultado.Error == false)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(Configuraciones.LlavesAplicacion.EventoActualizarCausalNovedad), Configuraciones.LlavesAplicacion.ActualizarCausalNovedad);
                    resultado.Error = false;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(Configuraciones.LlavesAplicacion.EventoActualizarCausalNovedad), ex, Configuraciones.LlavesAplicacion.CatchActualizarCausalNovedad).Mensaje;
            }

            return resultado;
        }

        /// <summary>
        /// Obtain the Causal Novelty.
        /// </summary>
        /// <param name="causal novelty">The Causal Novelty.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<CausalNovedad> ConsultarCausalNovedad(CausalNovedad causalNovedad)
        {
            return this.repositorioCausalNovedad.ConsultarCausalNovedad();
        }
        #endregion
    }
}
