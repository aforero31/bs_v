
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
    /// Interface Management Novelty
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA   
    /// CreationDate: 24/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionNovedad" />
    public class GestionNovedad : IGestionNovedad
    {
        #region Variables
        /// <summary>
        /// The repository Novelty
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioNovedad repositorioNovedad;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionNovedad"/> class.
        /// </summary>
        /// <param name="interfazRepositorioNovedad">The interface repository Novelty.</param>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public GestionNovedad(IRepositorioNovedad interfazRepositorioNovedad)
        {
            this.repositorioNovedad = interfazRepositorioNovedad;
        }

        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Save the Novelty.
        /// </summary>
        /// <param name="ipc">The Novelty.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public Resultado InsertarNovedad(Novedad novedad)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioNovedad.InsertarNovedad(novedad);
                if (resultado.Error)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(Configuraciones.LlavesAplicacion.EventoParametrizarNovedadInsertar), Configuraciones.LlavesAplicacion.NovedadExisteInsertar);
                    resultado.Error = true;
                }
                if (resultado.Error == false)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(Configuraciones.LlavesAplicacion.EventoParametrizarNovedadInsertar), Configuraciones.LlavesAplicacion.InsertarNovedad); //Mensajes.Guardado;
                }

            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(Configuraciones.LlavesAplicacion.EventoParametrizarNovedadInsertar), ex, Configuraciones.LlavesAplicacion.CatchInsertarNovedad).Mensaje;
            }
            return resultado;
        }

        /// <summary>
        /// Update the Novelty.
        /// </summary>
        /// <param name="ipc">The Novelty.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public Resultado ActualizarNovedad(Novedad novedad)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioNovedad.ActualizarNovedad(novedad);
                if (resultado.Error)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoParametrizarNovedadActualizar), LlavesAplicacion.NovedadNoActualiza);
                    resultado.Error = true;
                }
                else if (!resultado.Error)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoParametrizarNovedadActualizar), LlavesAplicacion.NovedadActualizada);
 
                }
 
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoParametrizarNovedadActualizar), ex, LlavesAplicacion.CatchActualizarNovedad).Mensaje;
            }
            return resultado;
        }

        /// <summary>
        /// Obtain the IPC.
        /// </summary>
        /// <param name="ipc">The IPC.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public IList<Novedad> ConsultarNovedades(Novedad novedad)
        {
            return this.repositorioNovedad.ConsultarNovedades(novedad);
        }
        #endregion
    }
}
