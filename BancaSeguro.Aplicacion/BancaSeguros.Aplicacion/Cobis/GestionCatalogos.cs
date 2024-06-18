//-----------------------------------------------------------------------
// <copyright file="GestionCatalogos.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Cobis
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.ServiceModel;
    using Configuraciones;
    using Entidades.Catalogo;
    using Entidades.General;
    using ServicioCobisCatalogos;

    /// <summary>
    /// Management catalogs
    /// </summary>
    public class GestionCatalogos : IGestionCatalogos
    {
        #region Metodos Publicos

        /// <summary>
        /// Get catalog
        /// </summary>
        /// <param name="nombreCatalogo">name catalog</param>
        /// <returns>Entity catalog</returns>
        public DtoCatalogo ConsultarCatalogo(string nombreCatalogo)
        {
            DtoCatalogo dtoCatalogo = new DtoCatalogo();
            dtoCatalogo.Resultado = new Resultado();

            try
            {
                ServicioCobisCatalogos.ContextoRespuesta contextoRespuesta = new ServicioCobisCatalogos.ContextoRespuesta();
                ServicioCobisCatalogos.Catalogo[] catalogos = new ServicioCobisCatalogos.Catalogo[1];
                catalogos[0] = new ServicioCobisCatalogos.Catalogo { codTabla = nombreCatalogo, codEstado = "V" };
                ServicioCobisCatalogos.ContextoTransaccional contextoTransaccional = new ServicioCobisCatalogos.ContextoTransaccional
                {
                    identificadorTransaccional = ConfigurationManager.AppSettings.Get(Parametros.IdentificadorTransaccional),
                    fecTransaccion = DateTime.Now,
                    fecTransaccionSpecified = true,
                    codCanalOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoCanalOriginador),
                    codProcesoOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoProcesoOriginador),
                    codFuncionalidadOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoFuncionalidadOriginador),
                    ipConsumidor = ConfigurationManager.AppSettings.Get(Parametros.ipConsumidor)
                };

                ServicioCobisCatalogos.Paginacion paginacion = new ServicioCobisCatalogos.Paginacion
                {
                    valTamPagina = int.Parse(Parametros.ParametroPaginacionCobis),
                    valTamPaginaSpecified = true
                };

                using (ServicioCobisCatalogos.SrvAplCobisGeneralesClient cliente = new ServicioCobisCatalogos.SrvAplCobisGeneralesClient())
                {
                    contextoRespuesta = cliente.OpBuscarCatalogo(contextoTransaccional, paginacion, ref catalogos);
                }

                if (contextoRespuesta.codTipoRespuesta == Parametros.CobisRespuestaSatisfactoria)
                {
                    dtoCatalogo = this.MapearCatalogoCobis(nombreCatalogo, catalogos);
                }
            }
            catch (FaultException<ServicioCobisCatalogos.ContextoRespuesta> faultException)
            {
                dtoCatalogo.Resultado.Error = true;
                dtoCatalogo.Resultado.IdTipoMensaje = int.Parse(Parametros.IdMensajerError);

                if (faultException.Detail.detalleRespuesta != null && faultException.Detail.detalleRespuesta.Count() > 0)
                {
                    dtoCatalogo.Resultado.Mensaje = string.Format(Mensajes.ErrorCobis, faultException.Detail.detalleRespuesta[0].codTipoDetalleRespuesta, faultException.Detail.detalleRespuesta[0].valDescripcionDetalleRespuesta);
                }
                else
                {
                    dtoCatalogo.Resultado.Mensaje = string.Format(Mensajes.ErrorCobis, faultException.Detail.codTipoRespuesta, faultException.Detail.valDescripcionRespuesta);
                }
            }
            catch (Exception exc)
            {
                dtoCatalogo.Resultado.Error = true;
                dtoCatalogo.Resultado.IdTipoMensaje = int.Parse(Parametros.IdMensajerError);
                dtoCatalogo.Resultado.Mensaje = string.Format(Mensajes.ErrorInterno, exc.Message);
            }

            return dtoCatalogo;
        }

        #endregion

        #region Metodos Privados

        /// <summary>
        /// Map catalog
        /// </summary>
        /// <param name="nombreCatalogo">name catalog</param>
        /// <param name="catalogos">the catalog</param>
        /// <returns>Entity catalog</returns>
        private DtoCatalogo MapearCatalogoCobis(string nombreCatalogo, Catalogo[] catalogos)
        {
            DtoCatalogo dtoCatalogo = new DtoCatalogo { Resultado = new Resultado() };

            switch (nombreCatalogo)
            {
                case EnumCatalogo.CobisTipoIdentificacion:
                    dtoCatalogo.ListTipoIdentificacion = this.MapearCatalogoATipoIdentificacion(catalogos);
                    break;

                case EnumCatalogo.CobisPeriodicidad:
                    dtoCatalogo.ListPeriodicidad = this.MapearCatalogoAPeriodicidad(catalogos);
                    break;

                case EnumCatalogo.CobisParentesco:
                    dtoCatalogo.ListParentesco = this.MapearCatalogoAParentesco(catalogos);
                    break;

                case EnumCatalogo.CobisProducto:
                    dtoCatalogo.TablaProducto = this.MapearCatalogoAProducto(catalogos);
                    break;
                case EnumCatalogo.CobisSubProductoCC:
                case EnumCatalogo.CobisSubProductoCA:
                    dtoCatalogo.TablaSubProducto = this.MapearCatalogoASubProducto(nombreCatalogo, catalogos);
                    break;
                case EnumCatalogo.CobisCategoriaCC:
                case EnumCatalogo.CobisCategoriaCA:
                    dtoCatalogo.TablaCategoria = this.MapearCatalogoACategoria(nombreCatalogo, catalogos);
                    break;

                default:
                    dtoCatalogo.Resultado = new Resultado { Error = true };
                    break;
            }

            return dtoCatalogo;
        }

        /// <summary>
        /// Map catalog a identification
        /// </summary>
        /// <param name="catalogos">the catalog</param>
        /// <returns>Entity list identification</returns>
        private List<TipoIdentificacion> MapearCatalogoATipoIdentificacion(Catalogo[] catalogos)
        {
            List<TipoIdentificacion> tiposIdentificacion = new List<TipoIdentificacion>();

            for (int i = 0; i < catalogos.Length; i++)
            {
                TipoIdentificacion tipo = new TipoIdentificacion();
                tipo.Nombre = catalogos[i].valCatalogo.Trim();
                tipo.Abreviatura = catalogos[i].codCatalogo.Trim();
                tipo.Activo = catalogos[i].codEstado.Trim() == Parametros.EstadoCatalogo ? true : false;
                tipo.CodigoCardif = ListaGeneroPublica.ObtenerListaCardifIdentificacion().FirstOrDefault(r => catalogos[i].valCatalogo.Trim().Contains(r.Key)).Value.ToString();

                if (string.IsNullOrEmpty(tipo.CodigoCardif))
                {
                    tipo.CodigoCardif = Parametros.CodigoCardifDefecto;
                }

                tiposIdentificacion.Add(tipo);
            }

            return tiposIdentificacion;
        }

        /// <summary>
        /// Map catalog a periodicity
        /// </summary>
        /// <param name="catalogos">the catalog</param>
        /// <returns>Entity list periodicity</returns>
        private List<Periodicidad> MapearCatalogoAPeriodicidad(Catalogo[] catalogos)
        {
            List<Periodicidad> periodicidades = new List<Periodicidad>();

            for (int i = 0; i < catalogos.Length; i++)
            {
                Periodicidad periodicidad = new Periodicidad();
                periodicidad.Nombre = catalogos[i].valCatalogo.Trim();
                periodicidad.Activo = catalogos[i].codEstado.Trim() == Parametros.EstadoCatalogo ? true : false;
                periodicidades.Add(periodicidad);
            }

            return periodicidades;
        }

        /// <summary>
        /// Map catalog a relationship
        /// </summary>
        /// <param name="catalogos">the catalog</param>
        /// <returns>Entity list relationship</returns>
        private List<Parentesco> MapearCatalogoAParentesco(Catalogo[] catalogos)
        {
            List<Parentesco> parentescos = new List<Parentesco>();

            for (int i = 0; i < catalogos.Length; i++)
            {
                Parentesco parentesco = new Parentesco();
                parentesco.Nombre = catalogos[i].valCatalogo.Trim();
                parentesco.Activo = catalogos[i].codEstado.Trim() == Parametros.EstadoCatalogo ? true : false;
                parentesco.Alias = catalogos[i].codCatalogo.Trim();
                parentescos.Add(parentesco);
            }

            return parentescos;
        }

        /// <summary>
        /// Map catalog a product
        /// </summary>
        /// <param name="catalogos">the catalog</param>
        /// <returns>Entity list product</returns>
        private List<Producto> MapearCatalogoAProducto(Catalogo[] catalogos)
        {
            List<Producto> productos = new List<Producto>();

            for (int i = 0; i < catalogos.Length; i++)
            {
                Producto producto = new Producto();
                producto.Nombre = catalogos[i].valCatalogo.Trim();
                producto.Codigo = int.Parse(catalogos[i].codCatalogo.Trim());
                producto.Activo = catalogos[i].codEstado.Trim() == Parametros.EstadoCatalogo ? true : false;
                productos.Add(producto);
            }

            return productos;
        }

        /// <summary>
        /// Map catalog a sub product
        /// </summary>
        /// <param name="catalogos">the catalog</param>
        /// <returns>Entity list sub product</returns>
        private List<SubProducto> MapearCatalogoASubProducto(string nombreCatalogo, Catalogo[] catalogos)
        {
            List<SubProducto> subProductos = new List<SubProducto>();

            for (int i = 0; i < catalogos.Length; i++)
            {
                SubProducto subProducto = new SubProducto();
                subProducto.Nombre = catalogos[i].valCatalogo.Trim();
                subProducto.Codigo = int.Parse(catalogos[i].codCatalogo.Trim());
                subProducto.Activo = catalogos[i].codEstado.Trim() == Parametros.EstadoCatalogo ? true : false;
                switch (nombreCatalogo)
                {
                    case EnumCatalogo.CobisSubProductoCC:
                        subProducto.IdProducto = 3;
                        break;
                    case EnumCatalogo.CobisSubProductoCA:
                        subProducto.IdProducto = 4;
                        break;
                }
                subProductos.Add(subProducto);
            }

            return subProductos;
        }

        /// <summary>
        /// Map catalog a category.
        /// </summary>
        /// <param name="catalogos">the catalog</param>
        /// <returns>Entity list category</returns>
        private List<Categoria> MapearCatalogoACategoria(string nombreCatalogo, Catalogo[] catalogos)
        {
            List<Categoria> categorias = new List<Categoria>();

            for (int i = 0; i < catalogos.Length; i++)
            {
                Categoria categoria = new Categoria();
                categoria.Nombre = catalogos[i].valCatalogo.Trim().Replace("¥", "Ñ");
                categoria.Codigo = catalogos[i].codCatalogo.Trim();
                categoria.Activo = catalogos[i].codEstado.Trim() == Parametros.EstadoCatalogo ? true : false;

                switch (nombreCatalogo)
                {
                    case EnumCatalogo.CobisCategoriaCA:
                        categoria.IdProducto = 4;
                        break;

                    case EnumCatalogo.CobisCategoriaCC:
                        categoria.IdProducto = 3;
                        break;
                }
                categorias.Add(categoria);
            }

            return categorias;
        }

        #endregion
    }
}