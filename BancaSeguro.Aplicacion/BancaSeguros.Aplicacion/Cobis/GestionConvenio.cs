//-----------------------------------------------------------------------
// <copyright file="GestionConvenio.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Cobis
{
    using Configuraciones;
    using Entidades.General;
    using Entidades.Seguro;
    using Entidades.Venta;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ServicioCobisConvenio;
    using System.IO;
    using System.Xml.Serialization;
    using BancaSeguros.Repositorio.Venta;
    using System.ServiceModel;

    /// <summary>
    /// Management agreement
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 11/07/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Aplicacion.Cobis.IGestionConvenio" />
    public class GestionConvenio : IGestionConvenio
    {
        #region Metodos Publicos
        public List<Entidades.Seguro.Convenio> ConsultarConveniosActivos(Aseguradora aseguradora)
        {
            bool Control = false;
            int iteracion = 0;
            List<ServicioCobisConvenio.Convenio> convenios = new List<ServicioCobisConvenio.Convenio>();
            List<ServicioCobisConvenio.Convenio> convenio = new List<ServicioCobisConvenio.Convenio>();
            List<Entidades.Seguro.Convenio> convenioUnidos = new List<Entidades.Seguro.Convenio>();            
            ServicioCobisConvenio.Paginacion paginacion = new ServicioCobisConvenio.Paginacion();
            paginacion.valTamPagina = int.Parse(ConfigurationManager.AppSettings.Get(Parametros.TamanoPaginacionCobis));
            paginacion.valTamPaginaSpecified = true;
            paginacion.valOrdenacion = true;
            paginacion.valOrdenacionSpecified = true;
            ServicioCobisConvenio.ProductoResumen productoResumen = new ServicioCobisConvenio.ProductoResumen();

            ServicioCobisConvenio.ContextoTransaccional contextoTransaccional = this.ContextoTransaccional();
            ServicioCobisConvenio.IdentidadPersona identidadPersona = this.IdentidadPersona(aseguradora);

            do
            {
                if (iteracion == 0)
                {
                    using (ServicioCobisConvenio.SrvAplCobisConvenioClient servicio = new ServicioCobisConvenio.SrvAplCobisConvenioClient())
                    {
                        convenio = servicio.OpBuscarConvenio(contextoTransaccional, paginacion, identidadPersona, productoResumen).ToList();
                        convenios.AddRange(convenio);
                        iteracion++;
                    }
                }
                else
                {
                    if (convenio.Count > 0)
                    {
                        var item = convenio[convenio.Count - 1];
                        paginacion.valUltimoRegistroAlterno = int.Parse(item.codFormato);
                        paginacion.valUltimoRegistroAlternoSpecified = true;
                        paginacion.valUltimoRegistroEntero = int.Parse(item.codConvenio);
                        paginacion.valUltimoRegistroEnteroSpecified = true;

                        using (ServicioCobisConvenio.SrvAplCobisConvenioClient servicio = new ServicioCobisConvenio.SrvAplCobisConvenioClient())
                        {
                            convenio = servicio.OpBuscarConvenio(contextoTransaccional, paginacion, identidadPersona, productoResumen).ToList();
                            convenios.AddRange(convenio);
                            iteracion++;
                        }
                    }
                    else
                        Control = true;
                }

            } while (Control == false);

            foreach (var con in convenios)
            {
                Entidades.Seguro.Convenio item = new Entidades.Seguro.Convenio();

                if (con.codFormato == "2" && con.codEstadoConvenio == "V")
                {
                    item.CodigoConvenio = int.Parse(con.codConvenio);
                    convenioUnidos.Add(item);
                }
            }
            return convenioUnidos;
        }

        #endregion

        #region Metodos Privados

        /// <summary>
        /// Serializa a XML un objeto.
        /// </summary>
        /// <param name="parametro">Parametro object.</param>
        /// <returns>Objeto StringWriter</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private StringWriter SerializaXml(object parametro)
        {
            XmlSerializer serializaXml = new XmlSerializer(parametro.GetType());
            StringWriter strWriterReq = new StringWriter();
            serializaXml.Serialize(strWriterReq, parametro);
            strWriterReq.Close();

            return strWriterReq;
        }

        private ServicioCobisConvenio.ContextoTransaccional ContextoTransaccional()
        {
            ServicioCobisConvenio.ContextoTransaccional contextoTransaccional = new ServicioCobisConvenio.ContextoTransaccional();

            contextoTransaccional.identificadorTransaccional = ConfigurationManager.AppSettings.Get(Parametros.IdentificadorTransaccional);
            contextoTransaccional.codCanalOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoCanalOriginador);
            contextoTransaccional.codProcesoOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoProcesoOriginador);
            contextoTransaccional.codFuncionalidadOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoFuncionalidadOriginador);
            contextoTransaccional.ipConsumidor = ConfigurationManager.AppSettings.Get(Parametros.ipConsumidor);
            contextoTransaccional.fecTransaccion = DateTime.Now;

            return contextoTransaccional;
        }

        private ServicioCobisConvenio.IdentidadPersona IdentidadPersona(Aseguradora aseguradora)
        {
            ServicioCobisConvenio.IdentidadPersona identidadPersona = new ServicioCobisConvenio.IdentidadPersona();
            identidadPersona.codTipoIdentidadPersona = aseguradora.TipoIdentificacion.Abreviatura;
            identidadPersona.valIdentidadPersona = aseguradora.Identificacion;

            return identidadPersona;
        }

        #endregion
    }
}
