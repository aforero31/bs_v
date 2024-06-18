//-----------------------------------------------------------------------
// <copyright file="Mapeador.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Venta
{
    using System;
    using System.Data;
    using BAC.EntidadesSeguridad;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Repositorio.Configuraciones;

    /// <summary>
    /// Class Map
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 14/06/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public class Mapeador
    {
        /// <summary>
        /// Data the reader a sure.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Entity sure</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Seguro DataReaderASeguro(IDataReader reader)
        {
            Seguro seguro = new Seguro();
            seguro.Aseguradora = new Aseguradora();

            seguro.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? false : (bool)reader[Campos.activo];
            seguro.Beneficiario = reader.IsDBNull(reader.GetOrdinal(Campos.beneficiario)) ? false : (bool)reader[Campos.beneficiario];
            seguro.Codigo = reader.IsDBNull(reader.GetOrdinal(Campos.codigo)) ? string.Empty : (string)reader[Campos.codigo];
            seguro.Conyuge = reader.IsDBNull(reader.GetOrdinal(Campos.conyuge)) ? false : (bool)reader[Campos.conyuge];
            seguro.Descripcion = reader.IsDBNull(reader.GetOrdinal(Campos.descripcion)) ? string.Empty : (string)reader[Campos.descripcion];
            seguro.EdadMaximaHombre = reader.IsDBNull(reader.GetOrdinal(Campos.edadMaximaHombre)) ? 0 : (int)reader[Campos.edadMaximaHombre];
            seguro.EdadMaximaMujer = reader.IsDBNull(reader.GetOrdinal(Campos.edadMaximaMujer)) ? 0 : (int)reader[Campos.edadMaximaMujer];
            seguro.EdadMinimaHombre = reader.IsDBNull(reader.GetOrdinal(Campos.edadMinimaHombre)) ? 0 : (int)reader[Campos.edadMinimaHombre];
            seguro.EdadMinimaMujer = reader.IsDBNull(reader.GetOrdinal(Campos.edadMinimaMujer)) ? 0 : (int)reader[Campos.edadMinimaMujer];
            seguro.Aseguradora.IdAseguradora = reader.IsDBNull(reader.GetOrdinal(Campos.idAseguradora)) ? 0 : (int)reader[Campos.idAseguradora];
            seguro.Aseguradora.Nombre = reader.IsDBNull(reader.GetOrdinal(Campos.nombreAseguradora)) ? string.Empty : (string)reader[Campos.nombreAseguradora];
            seguro.Aseguradora.CodigoSuperintendencia = reader.IsDBNull(reader.GetOrdinal(Campos.codigoSuperintendencia)) ? string.Empty : (string)reader[Campos.codigoSuperintendencia];
            seguro.Aseguradora.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activoAseguradora)) ? false : (bool)reader[Campos.activoAseguradora];
            seguro.IdSeguro = reader.IsDBNull(reader.GetOrdinal(Campos.idSeguro)) ? 0 : (int)reader[Campos.idSeguro];
            seguro.Nombre = reader.IsDBNull(reader.GetOrdinal(Campos.nombre)) ? string.Empty : (string)reader[Campos.nombre];
            seguro.EdadMinimaConyuge = reader.IsDBNull(reader.GetOrdinal(Campos.EdadMinimaConyugue)) ? 0 : (int)reader[Campos.EdadMinimaConyugue];
            seguro.EdadMaximaConyuge = reader.IsDBNull(reader.GetOrdinal(Campos.EdadMaximaConyugue)) ? 0 : (int)reader[Campos.EdadMaximaConyugue];
            seguro.MaximoBeneficiarios = reader.IsDBNull(reader.GetOrdinal(Campos.MaximoBeneficiarios)) ? 0 : (int)reader[Campos.MaximoBeneficiarios];
            seguro.NumeroMaximoSegurosPorCliente = reader.IsDBNull(reader.GetOrdinal(Campos.NumeroMaximoSegurosPorCliente)) ? 0 : (int)reader[Campos.NumeroMaximoSegurosPorCliente];
            seguro.NumeroMaximoVentaSegurosPorCuentaCliente = reader.IsDBNull(reader.GetOrdinal(Campos.NumeroMaximoVentaSegurosPorCuentaCliente)) ? 0 : (int)reader[Campos.NumeroMaximoVentaSegurosPorCuentaCliente];

            return seguro;
        }

        /// <summary>
        /// Data the reader a plan.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Entity plan</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Plan DataReaderAPlan(IDataReader reader)
        {
            Plan plan = new Plan();

            plan.IdPlan = reader.IsDBNull(reader.GetOrdinal(Campos.idPlan)) ? 0 : (int)reader[Campos.idPlan];
            plan.IdSeguro = reader.IsDBNull(reader.GetOrdinal(Campos.idSeguro)) ? 0 : (int)reader[Campos.idSeguro];
            plan.IdPeriodicidad = reader.IsDBNull(reader.GetOrdinal(Campos.idPeriodicidad)) ? 0 : (int)reader[Campos.idPeriodicidad];
            plan.NombrePeriodicidad = reader.IsDBNull(reader.GetOrdinal(Campos.nombrePeriodicidad)) ? string.Empty : (string)reader[Campos.nombrePeriodicidad];
            plan.Valor = reader.IsDBNull(reader.GetOrdinal(Campos.valor)) ? 0 : (decimal)reader[Campos.valor];
            plan.ValorMoneda = reader.IsDBNull(reader.GetOrdinal(Campos.valor)) ? String.Format("{0:C}", 0) : String.Format("{0:C0}", (decimal)reader[Campos.valor]);
            plan.NombrePlan = reader.IsDBNull(reader.GetOrdinal(Campos.nombrePlan)) ? string.Empty : (string)reader[Campos.nombrePlan];
            plan.Descripcion = reader.IsDBNull(reader.GetOrdinal(Campos.descripcion)) ? string.Empty : (string)reader[Campos.descripcion];
            plan.CodigoPlan = reader.IsDBNull(reader.GetOrdinal(Campos.CodigoPlan)) ? 0 : (int)reader[Campos.CodigoPlan];
            plan.CodigoConvenio = reader.IsDBNull(reader.GetOrdinal(Campos.codigoConvenio)) ? 0 : (int)reader[Campos.codigoConvenio];
            plan.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? false : (bool)reader[Campos.activo];

            return plan;
        }

        /// <summary>
        /// Lee un dataReader y retorna un documento poliza.
        /// </summary>
        /// <param name="reader">Data reader con la informacion.</param>
        /// <returns>DocumentoPoliza</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 09/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DocumentoPoliza DataReaderADocumentoPoliza(IDataReader reader)
        {
            DocumentoPoliza resultado = new DocumentoPoliza();
            resultado.IdSeguro = reader.IsDBNull(reader.GetOrdinal(Campos.idSeguro)) ? 0 : (int)reader[Campos.idSeguro];
            resultado.Plantilla = reader.IsDBNull(reader.GetOrdinal(Campos.plantilla)) ? null : (byte[])reader[Campos.plantilla];
            resultado.IdDocumentoPoliza = reader.IsDBNull(reader.GetOrdinal(Campos.idDocumentoPoliza)) ? 0 : (int)reader[Campos.idDocumentoPoliza];
            resultado.PlantillaXml = reader.IsDBNull(reader.GetOrdinal(Campos.datosPolizaXML)) ? null : System.Xml.Linq.XElement.Parse(reader[Campos.datosPolizaXML].ToString());
            resultado.CamposPlantilla = reader.IsDBNull(reader.GetOrdinal(Campos.CamposPlantilla)) ? string.Empty : reader[Campos.CamposPlantilla].ToString();
            resultado.NombreArchivo = reader.IsDBNull(reader.GetOrdinal(Campos.NombreArchivo)) ? string.Empty : reader[Campos.NombreArchivo].ToString();
            resultado.VersionDocumento = reader.IsDBNull(reader.GetOrdinal(Campos.VersionDocumento)) ? string.Empty : reader[Campos.VersionDocumento].ToString();
            return resultado;
        }

        /// <summary>
        /// Lee un dataReader y retorna un documento poliza.
        /// </summary>
        /// <param name="reader">Data reader con la informacion.</param>
        /// <returns>DocumentoPoliza</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 09/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DocumentoPoliza DataReaderADocumentosPolizaPorSeguro(IDataReader reader)
        {
            DocumentoPoliza resultado = new DocumentoPoliza();
            resultado.IdSeguro = reader.IsDBNull(reader.GetOrdinal(Campos.idSeguro)) ? 0 : (int)reader[Campos.idSeguro];
            resultado.IdDocumentoPoliza = reader.IsDBNull(reader.GetOrdinal(Campos.idDocumentoPoliza)) ? 0 : (int)reader[Campos.idDocumentoPoliza];
            resultado.Activa = reader.IsDBNull(reader.GetOrdinal(Campos.Activa)) ? false : (bool)reader[Campos.Activa];
            resultado.Eliminado = reader.IsDBNull(reader.GetOrdinal(Campos.Eliminado)) ? false : (bool)reader[Campos.Eliminado];
            resultado.VersionDocumento = reader.IsDBNull(reader.GetOrdinal(Campos.VersionDocumento)) ? string.Empty : reader[Campos.VersionDocumento].ToString();
            resultado.FechaCreacion = reader.IsDBNull(reader.GetOrdinal(Campos.fechaCreacion)) ? new DateTime() : (DateTime)reader[Campos.fechaCreacion];
            resultado.NombreArchivo = reader.IsDBNull(reader.GetOrdinal(Campos.NombreArchivo)) ? string.Empty : reader[Campos.NombreArchivo].ToString();
            return resultado;
        }

        public ProductoNoPermitido DataReaderAProductoNoPermitido(IDataReader reader)
        {
            ProductoNoPermitido productoNoPermitido = new ProductoNoPermitido();
            productoNoPermitido.Producto = new Producto();
            productoNoPermitido.SubProducto = new SubProducto();
            productoNoPermitido.Categoria = new Categoria();

            productoNoPermitido.IdSeguro = reader.IsDBNull(reader.GetOrdinal(Campos.idSeguro)) ? 0 : (int)reader[Campos.idSeguro];
            productoNoPermitido.Producto.Codigo = reader.IsDBNull(reader.GetOrdinal(Campos.codigoProducto)) ? 0 : (int)reader[Campos.codigoProducto];
            productoNoPermitido.Producto.IdProductos = reader.IsDBNull(reader.GetOrdinal(Campos.idProductos)) ? 0 : (int)reader[Campos.idProductos];
            productoNoPermitido.SubProducto.Codigo = reader.IsDBNull(reader.GetOrdinal(Campos.codigoSubProducto)) ? 0 : (int)reader[Campos.codigoSubProducto];
            productoNoPermitido.SubProducto.IdSubProductos = reader.IsDBNull(reader.GetOrdinal(Campos.idSubProductos)) ? 0 : (int)reader[Campos.idSubProductos];
            productoNoPermitido.Categoria.Codigo = reader.IsDBNull(reader.GetOrdinal(Campos.codigoCategoria)) ? string.Empty : (string)reader[Campos.codigoCategoria];
            productoNoPermitido.Categoria.IdCategoria = reader.IsDBNull(reader.GetOrdinal(Campos.IdCategoria)) ? 0 : (int)reader[Campos.IdCategoria];

            return productoNoPermitido;
        }

        /// <summary>
        /// Mapeador de datos poliza.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Objeto con la informacion de datos de poliza</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public EncabezadoPolizaDocumento DataReaderADatosEncabezadoPoliza(IDataReader reader)
        {
            EncabezadoPolizaDocumento resultado = new EncabezadoPolizaDocumento();
            resultado.FechaSolicitud = reader.IsDBNull(reader.GetOrdinal(Campos.FechaSolicitud)) ? string.Empty : (string)reader[Campos.FechaSolicitud];
            resultado.PrimerNombreCliente = reader.IsDBNull(reader.GetOrdinal(Campos.PrimerNombreCliente)) ? string.Empty : (string)reader[Campos.PrimerNombreCliente];
            resultado.SegundoNombreCliente = reader.IsDBNull(reader.GetOrdinal(Campos.SegundoNombreCliente)) ? string.Empty : (string)reader[Campos.SegundoNombreCliente];
            resultado.PrimerApellidoCliente = reader.IsDBNull(reader.GetOrdinal(Campos.PrimerApellidoCliente)) ? string.Empty : (string)reader[Campos.PrimerApellidoCliente];
            resultado.SegundoApellidoCliente = reader.IsDBNull(reader.GetOrdinal(Campos.SegundoApellidoCliente)) ? string.Empty : (string)reader[Campos.SegundoApellidoCliente];
            resultado.NumeroIdentificacionCliente = reader.IsDBNull(reader.GetOrdinal(Campos.NumeroIdentificacionCliente)) ? string.Empty : (string)reader[Campos.NumeroIdentificacionCliente];
            resultado.TipoIdentificacionAbreviadoCliente = reader.IsDBNull(reader.GetOrdinal(Campos.TipoIdentificacionAbreviadoCliente)) ? string.Empty : (string)reader[Campos.TipoIdentificacionAbreviadoCliente];
            resultado.TipoIdentificacionDescripcionCliente = reader.IsDBNull(reader.GetOrdinal(Campos.TipoIdentificacionDescripcionCliente)) ? string.Empty : (string)reader[Campos.TipoIdentificacionDescripcionCliente];
            resultado.FechaNacimientoCliente = reader.IsDBNull(reader.GetOrdinal(Campos.FechaNacimientoCliente)) ? string.Empty : (string)reader[Campos.FechaNacimientoCliente];
            resultado.ActividadEconomicaCliente = reader.IsDBNull(reader.GetOrdinal(Campos.ActividadEconomicaCliente)) ? string.Empty : (string)reader[Campos.ActividadEconomicaCliente];
            resultado.CiudadNacimientoCliente = reader.IsDBNull(reader.GetOrdinal(Campos.CiudadNacimientoCliente)) ? string.Empty : (string)reader[Campos.CiudadNacimientoCliente];
            resultado.GeneroCliente = reader.IsDBNull(reader.GetOrdinal(Campos.GeneroCliente)) ? string.Empty : (string)reader[Campos.GeneroCliente];
            resultado.DireccionCliente = reader.IsDBNull(reader.GetOrdinal(Campos.DireccionCliente)) ? string.Empty : (string)reader[Campos.DireccionCliente];
            resultado.TelefonoCliente = reader.IsDBNull(reader.GetOrdinal(Campos.TelefonoCliente)) ? string.Empty : (string)reader[Campos.TelefonoCliente];
            resultado.CiudadResidenciaCliente = reader.IsDBNull(reader.GetOrdinal(Campos.CiudadResidenciaCliente)) ? string.Empty : (string)reader[Campos.CiudadResidenciaCliente];
            resultado.DepartamenoCliente = reader.IsDBNull(reader.GetOrdinal(Campos.DepartamenoCliente)) ? string.Empty : (string)reader[Campos.DepartamenoCliente];
            resultado.NacionalidadCliente = reader.IsDBNull(reader.GetOrdinal(Campos.NacionalidadCliente)) ? string.Empty : (string)reader[Campos.NacionalidadCliente];
            resultado.CelularCliente = reader.IsDBNull(reader.GetOrdinal(Campos.CelularCliente)) ? string.Empty : (string)reader[Campos.CelularCliente];
            resultado.TipoCuentaCliente = reader.IsDBNull(reader.GetOrdinal(Campos.TipoCuentaCliente)) ? string.Empty : (string)reader[Campos.TipoCuentaCliente];
            resultado.NumeroCuentaCliente = reader.IsDBNull(reader.GetOrdinal(Campos.NumeroCuentaCliente)) ? string.Empty : (string)reader[Campos.NumeroCuentaCliente];
            resultado.FechaVencimientoTarjetaCliente = reader.IsDBNull(reader.GetOrdinal(Campos.FechaVencimientoTarjetaCliente)) ? string.Empty : (string)reader[Campos.FechaVencimientoTarjetaCliente];
            resultado.ConsecutivoPoliza = reader.IsDBNull(reader.GetOrdinal(Campos.ConsecutivoPoliza)) ? string.Empty : (string)reader[Campos.ConsecutivoPoliza];
            resultado.ValorPolizaSinIva = reader.IsDBNull(reader.GetOrdinal(Campos.ValorPolizaSinIva)) ? string.Empty : (string)reader[Campos.ValorPolizaSinIva];
            resultado.ValorIvaPoliza = reader.IsDBNull(reader.GetOrdinal(Campos.ValorIvaPoliza)) ? string.Empty : (string)reader[Campos.ValorIvaPoliza];
            resultado.ValorPrimaConIva = reader.IsDBNull(reader.GetOrdinal(Campos.ValorPrimaConIva)) ? string.Empty : (string)reader[Campos.ValorPrimaConIva];
            resultado.Periodicidad = reader.IsDBNull(reader.GetOrdinal(Campos.Periodicidad)) ? string.Empty : (string)reader[Campos.Periodicidad];
            resultado.PlanPoliza = reader.IsDBNull(reader.GetOrdinal(Campos.PlanPoliza)) ? string.Empty : (string)reader[Campos.PlanPoliza];
            resultado.NombreOficina = reader.IsDBNull(reader.GetOrdinal(Campos.NombreOficina)) ? string.Empty : (string)reader[Campos.NombreOficina];
            resultado.CiudadOficina = reader.IsDBNull(reader.GetOrdinal(Campos.CiudadOficina)) ? string.Empty : (string)reader[Campos.CiudadOficina];
            resultado.IdentificacionAsesor = reader.IsDBNull(reader.GetOrdinal(Campos.IdentificacionAsesor)) ? string.Empty : (string)reader[Campos.IdentificacionAsesor];
            resultado.NombreAsesor = reader.IsDBNull(reader.GetOrdinal(Campos.NombreAsesor)) ? string.Empty : (string)reader[Campos.NombreAsesor];

            return resultado;
        }

        /// <summary>
        /// Mapea la informacion del beneficiario de una poliza
        /// </summary>
        /// <param name="reader">IDataReader.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 22/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public BeneficiariosPolizaDocumento DataReaderDatosBeneficiariosPoliza(IDataReader reader)
        {
            BeneficiariosPolizaDocumento resultado = new BeneficiariosPolizaDocumento();
            resultado.NombreCompletoBeneficiario = reader.IsDBNull(reader.GetOrdinal(Campos.NombreCompletoBeneficiario)) ? string.Empty : (string)reader[Campos.NombreCompletoBeneficiario];
            resultado.NombreBeneficiario = reader.IsDBNull(reader.GetOrdinal(Campos.NombreBeneficiario)) ? string.Empty : (string)reader[Campos.NombreBeneficiario];
            resultado.ApellidoBeneficiario = reader.IsDBNull(reader.GetOrdinal(Campos.ApellidoBeneficiario)) ? string.Empty : (string)reader[Campos.ApellidoBeneficiario];
            resultado.TipoNumeroIdentificacionBeneficiario = reader.IsDBNull(reader.GetOrdinal(Campos.TipoNumeroIdentificacionBeneficiario)) ? string.Empty : (string)reader[Campos.TipoNumeroIdentificacionBeneficiario];
            resultado.TipoIdentificacionAbreviaturaBeneficiario = reader.IsDBNull(reader.GetOrdinal(Campos.TipoIdentificacionAbreviaturaBeneficiario)) ? string.Empty : (string)reader[Campos.TipoIdentificacionAbreviaturaBeneficiario];
            resultado.NumeroIdentificacionBeneficiario = reader.IsDBNull(reader.GetOrdinal(Campos.NumeroIdentificacionBeneficiario)) ? string.Empty : reader[Campos.NumeroIdentificacionBeneficiario].ToString();
            resultado.PorcentajeParticipacion = reader.IsDBNull(reader.GetOrdinal(Campos.PorcentajeParticipacion)) ? string.Empty : (string)reader[Campos.PorcentajeParticipacion];
            return resultado;
        }

         /// <summary>
        /// Mapea la informacion del beneficiario de una poliza
        /// </summary>
        /// <param name="reader">IDataReader.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 22/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public VariableVentaPolizaDocumento DataReaderDatosVariableVentaPoliza(IDataReader reader)
        {
            VariableVentaPolizaDocumento resultado = new VariableVentaPolizaDocumento();
            resultado.Orden = reader.IsDBNull(reader.GetOrdinal(Campos.orden)) ? 0 : (int)reader[Campos.orden]; 
            resultado.Valor = reader.IsDBNull(reader.GetOrdinal(Campos.valor)) ? string.Empty : (string)reader[Campos.valor];            
            return resultado;
        }

        /// <summary>
        /// Mapea la informacion del conyuge de una poliza
        /// </summary>
        /// <param name="reader">IDataReader.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 22/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public ConyugePolizaDocumento DataReaderDatosConyugePoliza(IDataReader reader)
        {
            ConyugePolizaDocumento resultado = new ConyugePolizaDocumento();
            resultado.PrimerNombreConyuge = reader.IsDBNull(reader.GetOrdinal(Campos.PrimerNombreConyuge)) ? string.Empty : (string)reader[Campos.PrimerNombreConyuge];
            resultado.SegundoNombreConyuge = reader.IsDBNull(reader.GetOrdinal(Campos.SegundoNombreConyuge)) ? string.Empty : (string)reader[Campos.SegundoNombreConyuge];
            resultado.PrimerApellidoConyuge = reader.IsDBNull(reader.GetOrdinal(Campos.PrimerApellidoConyuge)) ? string.Empty : (string)reader[Campos.PrimerApellidoConyuge];
            resultado.SegundoApellidoConyuge = reader.IsDBNull(reader.GetOrdinal(Campos.SegundoApellidoConyuge)) ? string.Empty : (string)reader[Campos.SegundoApellidoConyuge];
            resultado.TipoIdentificacionAbreviaturaConyuge = reader.IsDBNull(reader.GetOrdinal(Campos.TipoIdentificacionAbreviatura)) ? string.Empty : (string)reader[Campos.TipoIdentificacionAbreviatura];
            resultado.NumeroIdentificacionConyuge = reader.IsDBNull(reader.GetOrdinal(Campos.NumeroIdentificacionConyuge)) ? string.Empty : (string)reader[Campos.NumeroIdentificacionConyuge];
            resultado.FechaNacimientoConyuge = reader.IsDBNull(reader.GetOrdinal(Campos.FechaNacimientoConyuge)) ? string.Empty : (string)reader[Campos.FechaNacimientoConyuge];
            resultado.CiudadNacimientoConyuge = reader.IsDBNull(reader.GetOrdinal(Campos.CiudadNacimientoConyuge)) ? string.Empty : (string)reader[Campos.CiudadNacimientoConyuge];
            resultado.GeneroConyuge = reader.IsDBNull(reader.GetOrdinal(Campos.GeneroConyuge)) ? string.Empty : (string)reader[Campos.GeneroConyuge];
            resultado.DireccionConyuge = reader.IsDBNull(reader.GetOrdinal(Campos.DireccionConyuge)) ? string.Empty : (string)reader[Campos.DireccionConyuge];
            resultado.CiudadResidenciaConyuge = reader.IsDBNull(reader.GetOrdinal(Campos.CiudadResidenciaConyuge)) ? string.Empty : (string)reader[Campos.CiudadResidenciaConyuge];
            resultado.TelefonoConyuge = reader.IsDBNull(reader.GetOrdinal(Campos.TelefonoConyuge)) ? string.Empty : (string)reader[Campos.TelefonoConyuge];
            return resultado;
        }

        /// <summary>
        /// Data the reader a get sale.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Enity get sale</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public ConsultarVenta DataReaderAConsultarVenta(IDataReader reader)
        {
            ConsultarVenta consultarVenta = new ConsultarVenta();

            consultarVenta.Resultado = new Entidades.General.Resultado();
            consultarVenta.DatosVenta = new RegistrarVenta();
            consultarVenta.DatosVenta.IdVenta = reader.IsDBNull(reader.GetOrdinal(Campos.idVenta)) ? 0 : (int)reader[Campos.idVenta];
            consultarVenta.Seguro = new Seguro();
            consultarVenta.Seguro.EstadoPoliza = new EstadoPoliza();
            consultarVenta.Seguro.EstadoPoliza.DescripcionEstadoPoliza = reader.IsDBNull(reader.GetOrdinal(Campos.DescripcionEstadoPoliza)) ? string.Empty : (string)reader[Campos.DescripcionEstadoPoliza];
            consultarVenta.FechaCreacion = reader.IsDBNull(reader.GetOrdinal(Campos.fechaCreacion)) ? new DateTime() : (DateTime)reader[Campos.fechaCreacion];
            consultarVenta.DetalleCancelacionPoliza = new DetalleCancelacionPoliza();
            consultarVenta.DetalleCancelacionPoliza.FechaCancelacion = reader.IsDBNull(reader.GetOrdinal(Campos.FechaCancelacion)) ? new DateTime() : (DateTime)reader[Campos.FechaCancelacion];
            consultarVenta.DetalleCancelacionPoliza.CausalRechazo = new CausalRechazo();
            consultarVenta.DetalleCancelacionPoliza.CausalRechazo.NombreCausalRechazo = reader.IsDBNull(reader.GetOrdinal(Campos.Novedad)) ? string.Empty : (string)reader[Campos.Novedad];
            consultarVenta.Seguro.Nombre = reader.IsDBNull(reader.GetOrdinal(Campos.NombreSeguro)) ? string.Empty : (string)reader[Campos.NombreSeguro];
            consultarVenta.Seguro.Descripcion = reader.IsDBNull(reader.GetOrdinal(Campos.DescripcionProducto)) ? string.Empty : (string)reader[Campos.DescripcionProducto];
            consultarVenta.Seguro.Plan = new Plan();
            consultarVenta.Seguro.Plan.NombrePlan = reader.IsDBNull(reader.GetOrdinal(Campos.nombrePlan)) ? string.Empty : (string)reader[Campos.nombrePlan];
            consultarVenta.Seguro.Plan.Descripcion = reader.IsDBNull(reader.GetOrdinal(Campos.DescripcionPlan)) ? string.Empty : (string)reader[Campos.DescripcionPlan];
            consultarVenta.Seguro.Plan.Periodicidad = new Periodicidad();
            consultarVenta.Seguro.Plan.Periodicidad.Nombre = reader.IsDBNull(reader.GetOrdinal(Campos.Periodicidad)) ? string.Empty : (string)reader[Campos.Periodicidad];
            consultarVenta.Seguro.Plan.Valor = reader.IsDBNull(reader.GetOrdinal(Campos.valor)) ? 0 : (decimal)reader[Campos.valor];
            consultarVenta.DatosVenta.ProductoBancario = new ProductoBancario();
            consultarVenta.DatosVenta.ProductoBancario.NumeroCuenta = reader.IsDBNull(reader.GetOrdinal(Campos.NumeroCuentaCliente)) ? string.Empty : (string)reader[Campos.NumeroCuentaCliente];
            consultarVenta.FechaCobroExitoso = reader.IsDBNull(reader.GetOrdinal(Campos.FechaCobroExitoso)) ? new DateTime() : (DateTime)reader[Campos.FechaCobroExitoso];
            consultarVenta.DatosVenta.Consecutivo = reader.IsDBNull(reader.GetOrdinal(Campos.consecutivo)) ? string.Empty : (string)reader[Campos.consecutivo];
            consultarVenta.DatosVenta.Cliente = new Cliente();
            consultarVenta.DatosVenta.Cliente.PrimerNombre = reader.IsDBNull(reader.GetOrdinal(Campos.primerNombre)) ? string.Empty : (string)reader[Campos.primerNombre];
            consultarVenta.DatosVenta.Cliente.SegundoNombre = reader.IsDBNull(reader.GetOrdinal(Campos.segundoNombre)) ? string.Empty : (string)reader[Campos.segundoNombre];
            consultarVenta.DatosVenta.Cliente.PrimerApellido = reader.IsDBNull(reader.GetOrdinal(Campos.primerApellido)) ? string.Empty : (string)reader[Campos.primerApellido];
            consultarVenta.DatosVenta.Cliente.SegundoApellido = reader.IsDBNull(reader.GetOrdinal(Campos.segundoApellido)) ? string.Empty : (string)reader[Campos.segundoApellido];
            consultarVenta.DatosVenta.Cliente.FechaNacimiento = reader.IsDBNull(reader.GetOrdinal(Campos.fechaNacimiento)) ? new DateTime() : (DateTime)reader[Campos.fechaNacimiento];
            consultarVenta.DatosVenta.Cliente.CiudadNacimiento = reader.IsDBNull(reader.GetOrdinal(Campos.ciudadNacimiento)) ? string.Empty : (string)reader[Campos.ciudadNacimiento];
            consultarVenta.DatosVenta.Cliente.Nacionalidad = reader.IsDBNull(reader.GetOrdinal(Campos.nacionalidad)) ? string.Empty : (string)reader[Campos.nacionalidad];
            consultarVenta.DatosVenta.Cliente.Genero = reader.IsDBNull(reader.GetOrdinal(Campos.GeneroCliente)) ? string.Empty : (string)reader[Campos.GeneroCliente];
            consultarVenta.DatosVenta.Cliente.Direccion = reader.IsDBNull(reader.GetOrdinal(Campos.direccion)) ? string.Empty : (string)reader[Campos.direccion];
            consultarVenta.DatosVenta.Cliente.CiudadResidencia = reader.IsDBNull(reader.GetOrdinal(Campos.ciudadResidencia)) ? string.Empty : (string)reader[Campos.ciudadResidencia];
            consultarVenta.DatosVenta.Cliente.Telefono = reader.IsDBNull(reader.GetOrdinal(Campos.telefono)) ? string.Empty : (string)reader[Campos.telefono];
            consultarVenta.DatosVenta.Cliente.Celular = reader.IsDBNull(reader.GetOrdinal(Campos.celular)) ? string.Empty : (string)reader[Campos.celular];
            consultarVenta.DatosVenta.Cliente.Correo = reader.IsDBNull(reader.GetOrdinal(Campos.correo)) ? string.Empty : (string)reader[Campos.correo];
            consultarVenta.DatosVenta.ProductoBancario.CodigoProducto = reader.IsDBNull(reader.GetOrdinal(Campos.codigoProducto)) ? string.Empty : (string)reader[Campos.codigoProducto];
            consultarVenta.DatosVenta.ProductoBancario.NombreProducto = reader.IsDBNull(reader.GetOrdinal(Campos.NombreProducto)) ? string.Empty : (string)reader[Campos.NombreProducto];
            consultarVenta.DatosVenta.Asesor = new Asesor();
            consultarVenta.DatosVenta.Asesor.IdAsesor = reader.IsDBNull(reader.GetOrdinal(Campos.idAsesor)) ? string.Empty : (string)reader[Campos.idAsesor];
            consultarVenta.Seguro.IdSeguro = reader.IsDBNull(reader.GetOrdinal(Campos.idSeguro)) ? 0 : (int)reader[Campos.idSeguro];

            return consultarVenta;
        }

        /// <summary>
        /// Map the reader to entity.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Aseguradora DataReaderAseguradora(IDataReader reader)
        {
            Aseguradora aseguradora = new Aseguradora();
            aseguradora.IdAseguradora = reader.IsDBNull(reader.GetOrdinal(Campos.idAseguradora)) ? 0 : (int)reader[Campos.idAseguradora];
            aseguradora.Nombre = reader.IsDBNull(reader.GetOrdinal(Campos.nombre)) ? string.Empty : (string)reader[Campos.nombre];
            aseguradora.CodigoSuperintendencia = reader.IsDBNull(reader.GetOrdinal(Campos.codigoSuperintendencia)) ? string.Empty : (string)reader[Campos.codigoSuperintendencia];
            aseguradora.TipoIdentificacion = new TipoIdentificacion();
            aseguradora.TipoIdentificacion.IdTipoIdentificacion = reader.IsDBNull(reader.GetOrdinal(Campos.idTipoIdentificacion)) ? 0 : (int)reader[Campos.idTipoIdentificacion];
            aseguradora.TipoIdentificacion.Abreviatura = reader.IsDBNull(reader.GetOrdinal(Campos.Abreviatura)) ? string.Empty : (string)reader[Campos.Abreviatura];
            aseguradora.Identificacion = reader.IsDBNull(reader.GetOrdinal(Campos.identificacion)) ? string.Empty : (string)reader[Campos.identificacion];
            aseguradora.Contacto = reader.IsDBNull(reader.GetOrdinal(Campos.contacto)) ? string.Empty : (string)reader[Campos.contacto];
            aseguradora.Telefono = reader.IsDBNull(reader.GetOrdinal(Campos.telefono)) ? string.Empty : (string)reader[Campos.telefono];
            aseguradora.Correo = reader.IsDBNull(reader.GetOrdinal(Campos.correo)) ? string.Empty : (string)reader[Campos.correo];
            aseguradora.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? false : (bool)reader[Campos.activo];
            aseguradora.ConsecutivoInicial = reader.IsDBNull(reader.GetOrdinal(Campos.consecutivoInicial)) ? 0 : (int)reader[Campos.consecutivoInicial];
            aseguradora.ConsecutivoActual = reader.IsDBNull(reader.GetOrdinal(Campos.consecutivoActual)) ? 0 : (int)reader[Campos.consecutivoActual];
            return aseguradora;
        }

        /// <summary>
        /// DataReader categoria.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>categoria object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Categoria DataReaderCategoria(IDataReader reader)
        {
            Categoria resultado = new Categoria();
            resultado.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? false : (bool)reader[Campos.activo];
            resultado.Codigo = reader.IsDBNull(reader.GetOrdinal(Campos.codigo)) ? string.Empty : reader[Campos.codigo].ToString();
            resultado.IdCategoria = reader.IsDBNull(reader.GetOrdinal(Campos.IdCategoria)) ? 0 : (int)reader[Campos.IdCategoria];
            resultado.Nombre = reader.IsDBNull(reader.GetOrdinal(Campos.nombre)) ? string.Empty : reader[Campos.nombre].ToString();
            return resultado;
        }

        /// <summary>
        /// DataReader SubProducto.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>SubProducto object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public SubProducto DataReaderSubProducto(IDataReader reader)
        {
            SubProducto resultado = new SubProducto();
            resultado.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? false : (bool)reader[Campos.activo];
            resultado.Codigo = reader.IsDBNull(reader.GetOrdinal(Campos.codigo)) ? 0 : (int)reader[Campos.codigo];
            resultado.IdSubProductos = reader.IsDBNull(reader.GetOrdinal(Campos.idSubProductos)) ? 0 : (int)reader[Campos.idSubProductos];
            resultado.Nombre = reader.IsDBNull(reader.GetOrdinal(Campos.nombre)) ? string.Empty : reader[Campos.nombre].ToString();
            return resultado;
        }

        /// <summary>
        /// Map the reader to group entity.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Group Entitity</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public GrupoBAC DataReaderGrupoBAC(IDataReader reader)
        {
            GrupoBAC resultado = new GrupoBAC();
            resultado.IdGrupo = reader.IsDBNull(reader.GetOrdinal(Campos.idGrupo)) ? 0 : (int)reader[Campos.idGrupo];
            resultado.NombreGrupo = reader.IsDBNull(reader.GetOrdinal(Campos.nombreGrupo)) ? string.Empty : reader[Campos.nombreGrupo].ToString();
            resultado.CodigoGrupo = reader.IsDBNull(reader.GetOrdinal(Campos.codigoGrupo)) ? string.Empty : reader[Campos.codigoGrupo].ToString();
            resultado.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? false : (bool)reader[Campos.activo];
            return resultado;
        }

        /// <summary>
        /// Data the reader periodicidad.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 06/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Producto DataReaderProducto(IDataReader reader)
        {
            Producto resultado = new Producto();
            resultado.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? false : (bool)reader[Campos.activo];
            resultado.IdProductos = reader.IsDBNull(reader.GetOrdinal(Campos.idProductos)) ? 0 : (int)reader[Campos.idProductos];
            resultado.CodigoCardif = reader.IsDBNull(reader.GetOrdinal(Campos.CodigoCardif)) ? string.Empty : reader[Campos.CodigoCardif].ToString();
            resultado.Nombre = reader.IsDBNull(reader.GetOrdinal(Campos.nombre)) ? string.Empty : reader[Campos.nombre].ToString();
            resultado.Codigo = reader.IsDBNull(reader.GetOrdinal(Campos.codigo)) ? 0 : (int)reader[Campos.codigo];
            return resultado;
        }

        /// <summary>
        /// Datas the reader to sale variable.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Sale variable object</returns>
        public VariableVenta DataReaderAVariableVenta(IDataReader reader)
        {
            VariableVenta resultado = new VariableVenta();

            resultado.IdVariableVenta = reader.IsDBNull(reader.GetOrdinal(Campos.idVariableVenta)) ? 0 : (int)reader[Campos.idVariableVenta];
            resultado.IdVenta = reader.IsDBNull(reader.GetOrdinal(Campos.idVenta)) ? 0 : (int)reader[Campos.idVenta];
            resultado.IdVariableProducto = reader.IsDBNull(reader.GetOrdinal(Campos.idVariableProducto)) ? 0 : (int)reader[Campos.idVariableProducto];
            resultado.Orden= reader.IsDBNull(reader.GetOrdinal(Campos.orden)) ? 0 : (int)reader[Campos.orden];
            resultado.Valor = reader.IsDBNull(reader.GetOrdinal(Campos.valor)) ? string.Empty : (string)reader[Campos.valor];
            resultado.ValorMaestra = reader.IsDBNull(reader.GetOrdinal(Campos.valorMaestra)) ? false : (bool)reader[Campos.valorMaestra];
            resultado.NombreValor = reader.IsDBNull(reader.GetOrdinal(Campos.nombre)) ? string.Empty : (string)reader[Campos.nombre];

            return resultado;
        }
    }
}
