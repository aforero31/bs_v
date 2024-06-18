//-----------------------------------------------------------------------
// <copyright file="Mapeador.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Repositorio.Administracion
{
    using System;
    using System.Data;
    using BancaSeguros.Entidades.Administracion;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Repositorio.Configuraciones;
    using BancaSeguros.Entidades.Planos;
    using System.Xml;
    using System.Globalization;
    
    /// <summary>
    /// entity mapper
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 02/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public class Mapeador
    {
        /// <summary>
        /// mapper for convention.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>convention object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 02/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Convenio DataReaderConvenio(IDataReader reader)
        {
            Convenio resultado = new Convenio();
            resultado.CodigoConvenio = reader.IsDBNull(reader.GetOrdinal(Campos.codigoConvenio)) ? 0 : (int)reader[Campos.codigoConvenio];
            resultado.Id = reader.IsDBNull(reader.GetOrdinal(Campos.id)) ? 0 : ((int)reader[Campos.id]);
            resultado.IdAseguradora = reader.IsDBNull(reader.GetOrdinal(Campos.idAseguradora)) ? 0 : (int)reader[Campos.idAseguradora];
            resultado.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? false : (bool)reader[Campos.activo];
            resultado.NombreConvenio = reader.IsDBNull(reader.GetOrdinal(Campos.nombreConvenio)) ? string.Empty : (string)reader[Campos.nombreConvenio];
            return resultado;
        }

        /// <summary>
        /// mapper for sale channel.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Sale channel object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public CanalVenta DataReaderCanalVenta(IDataReader reader)
        {
            CanalVenta resultado = new CanalVenta();
            resultado.Codigo = reader.IsDBNull(reader.GetOrdinal(Campos.codigo)) ? 0 : (int)reader[Campos.codigo];
            resultado.IdCanalVenta = reader.IsDBNull(reader.GetOrdinal(Campos.idCanalVenta)) ? 0 : (int)reader[Campos.idCanalVenta];
            resultado.Nombre = reader.IsDBNull(reader.GetOrdinal(Campos.nombre)) ? string.Empty : reader[Campos.nombre].ToString();
            resultado.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? false : (bool)reader[Campos.activo];
            return resultado;
        }

        /// <summary>
        /// Data the reader periodicity.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Periodicity object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 06/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Periodicidad DataReaderPeriodicidad(IDataReader reader)
        {
            Periodicidad resultado = new Periodicidad();
            resultado.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? false : (bool)reader[Campos.activo];
            resultado.IdPeriodicidad = reader.IsDBNull(reader.GetOrdinal(Campos.idPeriodicidad)) ? 0 : (int)reader[Campos.idPeriodicidad];
            resultado.Nombre = reader.IsDBNull(reader.GetOrdinal(Campos.nombre)) ? string.Empty : reader[Campos.nombre].ToString();
            resultado.NumeroMesesPeriodicidad = reader.IsDBNull(reader.GetOrdinal(Campos.numeroMesesPeriodicidad)) ? 0 : (int)reader[Campos.numeroMesesPeriodicidad];
            return resultado;
        }

        /// <summary>
        /// Map the reader plan code.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>plan code object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 11/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public CodigoPlan DataReaderCodigoPlan(IDataReader reader)
        {
            CodigoPlan resultado = new CodigoPlan();
            resultado.IdCodigoPlan = reader.IsDBNull(reader.GetOrdinal(Campos.IdCodigoPlan)) ? 0 : (int)reader[Campos.IdCodigoPlan];
            resultado.Codigo = reader.IsDBNull(reader.GetOrdinal(Campos.codigo)) ? string.Empty : reader[Campos.codigo].ToString();
            resultado.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? false : (bool)reader[Campos.activo];
            return resultado;
        }

        /// <summary>
        /// Map the reader audit.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>the audit object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Auditoria DataReaderAuditoria(IDataReader reader)
        {
            Auditoria resultado = new Auditoria();
            resultado.IdAuditoria = reader.IsDBNull(reader.GetOrdinal(Campos.AuditID)) ? 0 : (int)reader[Campos.AuditID];
            resultado.Tipo = reader.IsDBNull(reader.GetOrdinal(Campos.Type)) ? string.Empty : reader[Campos.Type].ToString();
            resultado.NombreTabla = reader.IsDBNull(reader.GetOrdinal(Campos.TableName)) ? string.Empty : reader[Campos.TableName].ToString();
            resultado.CampoLlave = reader.IsDBNull(reader.GetOrdinal(Campos.PrimaryKeyField)) ? string.Empty : reader[Campos.PrimaryKeyField].ToString();
            resultado.ValorLlave = reader.IsDBNull(reader.GetOrdinal(Campos.PrimaryKeyValue)) ? string.Empty : reader[Campos.PrimaryKeyValue].ToString();
            resultado.Campo = reader.IsDBNull(reader.GetOrdinal(Campos.FieldName)) ? string.Empty : reader[Campos.FieldName].ToString();
            resultado.ValorAnterior = reader.IsDBNull(reader.GetOrdinal(Campos.OldValue)) ? string.Empty : reader[Campos.OldValue].ToString();
            resultado.NuevoValor = reader.IsDBNull(reader.GetOrdinal(Campos.NewValue)) ? string.Empty : reader[Campos.NewValue].ToString();
            resultado.FechaActualizacion = reader.IsDBNull(reader.GetOrdinal(Campos.UpdateDate)) ? new DateTime() : (DateTime)reader[Campos.UpdateDate];
            resultado.Usuario = reader.IsDBNull(reader.GetOrdinal(Campos.UserName)) ? string.Empty : reader[Campos.UserName].ToString();
            return resultado;
        }

        /// <summary>
        /// mapper for IPC.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>IPC entity</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA   
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IPC DataReaderIPC(IDataReader reader)
        {
            IPC resultado = new IPC();
            resultado.Ano = reader.IsDBNull(reader.GetOrdinal(Campos.AnoIPC)) ? 0 : (int)reader[Campos.AnoIPC];
            resultado.IdIpc = reader.IsDBNull(reader.GetOrdinal(Campos.IdIPC)) ? 0 : (int)reader[Campos.IdIPC];
            resultado.Valor = reader.IsDBNull(reader.GetOrdinal(Campos.ValorIPC)) ? 0 : (decimal)reader[Campos.ValorIPC];
            resultado.AnoActual = reader.IsDBNull(reader.GetOrdinal(Campos.AnoActual)) ? 0 : (int)reader[Campos.AnoActual];
            return resultado;
        }

        /// <summary>
        /// mapper for Novelty.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns> Novelty entity</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA   
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Novedad DataReaderNovedad(IDataReader reader)
        {
            Novedad resultado = new Novedad();
            resultado.CodigoTipoNovedad = reader.IsDBNull(reader.GetOrdinal(Campos.CodigoNovedad)) ? 0 : (int)reader[Campos.CodigoNovedad];
            resultado.NombreTipoNovedad = reader.IsDBNull(reader.GetOrdinal(Campos.NombreNovedad)) ? string.Empty : reader[Campos.NombreNovedad].ToString();
            resultado.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.EstadoNovedad)) ? false : (bool)reader[Campos.EstadoNovedad];
            resultado.IdTipoNovedad = reader.IsDBNull(reader.GetOrdinal(Campos.IdNovedad)) ? 0 : (int)reader[Campos.IdNovedad];
            return resultado;
        }

        /// <summary>
        /// mapper for Causal Novelty.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Causal Novelty entity</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA   
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public CausalNovedad DataReaderCausalNovedad(IDataReader reader)
        {
            CausalNovedad resultado = new CausalNovedad();
            resultado.IdCausalNovedad = reader.IsDBNull(reader.GetOrdinal(Campos.IdCausalNovedad)) ? 0 : (int)reader[Campos.IdCausalNovedad];
            resultado.NombreCausalNovedad = reader.IsDBNull(reader.GetOrdinal(Campos.NombreCausalNovedad)) ? string.Empty : reader[Campos.NombreCausalNovedad].ToString();
            resultado.IdTipoNovedad = reader.IsDBNull(reader.GetOrdinal(Campos.IdNovedad)) ? 0 : (int)reader[Campos.IdNovedad];
            resultado.NombreTipoNovedad = reader.IsDBNull(reader.GetOrdinal(Campos.NombreNovedad)) ? string.Empty : reader[Campos.NombreNovedad].ToString();
            resultado.CodigoCausalNovedad = reader.IsDBNull(reader.GetOrdinal(Campos.CodigoCausalNovedad)) ? string.Empty : reader[Campos.CodigoCausalNovedad].ToString();
            resultado.EstadoCausalNovedad = reader.IsDBNull(reader.GetOrdinal(Campos.estadoCausalNovedad)) ? false : (bool)reader[Campos.estadoCausalNovedad];
            return resultado;
        }

        /// <summary>
        /// Map the reader to Message entity.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Message entity</returns>
        public Mensaje DataReaderMensaje(IDataReader reader)
        {
            Mensaje resultado = new Mensaje();
            resultado.Resultado = new Resultado();
            resultado.IdMensaje = reader.IsDBNull(reader.GetOrdinal(Campos.idMensaje)) ? 0 : (int)reader[Campos.idMensaje];
            resultado.Llave = reader.IsDBNull(reader.GetOrdinal(Campos.Llave)) ? string.Empty : reader[Campos.Llave].ToString();           
            resultado.IdTipoMensaje = reader.IsDBNull(reader.GetOrdinal(Campos.idTipoMensaje)) ? 0 : (int)reader[Campos.idTipoMensaje];
            resultado.IdEvento = reader.IsDBNull(reader.GetOrdinal(Campos.idEvento)) ? 0 : (int)reader[Campos.idEvento];
            resultado.DescripcionMensaje = reader.IsDBNull(reader.GetOrdinal(Campos.Mensaje)) ? string.Empty : reader[Campos.Mensaje].ToString();
            resultado.Eventos = reader.IsDBNull(reader.GetOrdinal(Campos.Eventos)) ? string.Empty : reader[Campos.Eventos].ToString();
            return resultado;
        }

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
            seguro.Aseguradora.Convenio = new Convenio();

            seguro.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? false : (bool)reader[Campos.activo];
            seguro.Beneficiario = reader.IsDBNull(reader.GetOrdinal(Campos.beneficiario)) ? false : (bool)reader[Campos.beneficiario];
            seguro.Codigo = reader.IsDBNull(reader.GetOrdinal(Campos.codigo)) ? string.Empty : (string)reader[Campos.codigo];
            seguro.Conyuge = reader.IsDBNull(reader.GetOrdinal(Campos.conyuge)) ? false : (bool)reader[Campos.conyuge];
            seguro.Descripcion = reader.IsDBNull(reader.GetOrdinal(Campos.descripcion)) ? string.Empty : (string)reader[Campos.descripcion];
            seguro.EdadMaximaHombre = reader.IsDBNull(reader.GetOrdinal(Campos.edadMaximaHombre)) ? 0 : (int)reader[Campos.edadMaximaHombre];
            seguro.EdadMaximaMujer = reader.IsDBNull(reader.GetOrdinal(Campos.edadMaximaMujer)) ? 0 : (int)reader[Campos.edadMaximaMujer];
            seguro.EdadMinimaHombre = reader.IsDBNull(reader.GetOrdinal(Campos.edadMinimaHombre)) ? 0 : (int)reader[Campos.edadMinimaHombre];
            seguro.EdadMinimaMujer = reader.IsDBNull(reader.GetOrdinal(Campos.edadMinimaMujer)) ? 0 : (int)reader[Campos.edadMinimaMujer];
            seguro.NumeroMaximoSegurosPorCliente = reader.IsDBNull(reader.GetOrdinal(Campos.NumeroMaximoSegurosPorCliente)) ? 0 : (int)reader[Campos.NumeroMaximoSegurosPorCliente];
            seguro.NumeroMaximoVentaSegurosPorCuentaCliente = reader.IsDBNull(reader.GetOrdinal(Campos.NumeroMaximoVentaSegurosPorCuentaCliente)) ? 0 : (int)reader[Campos.NumeroMaximoVentaSegurosPorCuentaCliente];
            seguro.IdAseguradora = reader.IsDBNull(reader.GetOrdinal(Campos.idAseguradora)) ? 0 : (int)reader[Campos.idAseguradora];
            seguro.Aseguradora.IdAseguradora = reader.IsDBNull(reader.GetOrdinal(Campos.idAseguradora)) ? 0 : (int)reader[Campos.idAseguradora];
            seguro.Aseguradora.Nombre = reader.IsDBNull(reader.GetOrdinal(Campos.nombreAseguradora)) ? string.Empty : (string)reader[Campos.nombreAseguradora];
            seguro.Aseguradora.CodigoSuperintendencia = reader.IsDBNull(reader.GetOrdinal(Campos.codigoSuperintendencia)) ? string.Empty : (string)reader[Campos.codigoSuperintendencia];
            seguro.Aseguradora.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activoAseguradora)) ? false : (bool)reader[Campos.activoAseguradora];
            seguro.IdSeguro = reader.IsDBNull(reader.GetOrdinal(Campos.idSeguro)) ? 0 : (int)reader[Campos.idSeguro];
            seguro.Nombre = reader.IsDBNull(reader.GetOrdinal(Campos.nombre)) ? string.Empty : (string)reader[Campos.nombre];
            seguro.EdadMinimaConyuge = reader.IsDBNull(reader.GetOrdinal(Campos.EdadMinimaConyugue)) ? 0 : (int)reader[Campos.EdadMinimaConyugue];
            seguro.EdadMaximaConyuge = reader.IsDBNull(reader.GetOrdinal(Campos.EdadMaximaConyugue)) ? 0 : (int)reader[Campos.EdadMaximaConyugue];
            seguro.MaximoBeneficiarios = reader.IsDBNull(reader.GetOrdinal(Campos.MaximoBeneficiarios)) ? 0 : (int)reader[Campos.MaximoBeneficiarios];
            seguro.IdCanalVenta = reader.IsDBNull(reader.GetOrdinal(Campos.idCanalVenta)) ? 0 : (int)reader[Campos.idCanalVenta];

            return seguro;
        }

        /// <summary>
        /// maps the reader to approval dual object.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Object dual approval</returns>
        public AprobacionDual DataReaderAprobacionDual(IDataReader reader)
        {
            AprobacionDual resultado = new AprobacionDual();
            resultado.IdAprobacionDual = reader.IsDBNull(reader.GetOrdinal(Campos.idAprobacionDual)) ? 0 : (int)reader[Campos.idAprobacionDual];
            resultado.IdMenu = reader.IsDBNull(reader.GetOrdinal(Campos.idMenu)) ? 0 : (int)reader[Campos.idMenu];
            resultado.NombreMenu = reader.IsDBNull(reader.GetOrdinal(Campos.nombre)) ? string.Empty : reader[Campos.nombre].ToString();
            resultado.Estado = reader.IsDBNull(reader.GetOrdinal(Campos.estado)) ? string.Empty : reader[Campos.estado].ToString();
            resultado.Accion = reader.IsDBNull(reader.GetOrdinal(Campos.Accion)) ? string.Empty : reader[Campos.Accion].ToString();
            resultado.UsuarioEnvia = reader.IsDBNull(reader.GetOrdinal(Campos.usuarioEnvia)) ? string.Empty : reader[Campos.usuarioEnvia].ToString();
            resultado.UsuarioAprueba = reader.IsDBNull(reader.GetOrdinal(Campos.usuarioAprueba)) ? string.Empty : reader[Campos.usuarioAprueba].ToString();
            resultado.FechaSolicitud = reader.IsDBNull(reader.GetOrdinal(Campos.FechaSolicitud)) ? new DateTime() : (DateTime)reader[Campos.FechaSolicitud];
            resultado.FechaAprobacion = reader.IsDBNull(reader.GetOrdinal(Campos.fechaAprobacion)) ? new DateTime() : (DateTime)reader[Campos.fechaAprobacion];
            resultado.NombreObjeto = reader.IsDBNull(reader.GetOrdinal(Campos.nombreObjeto)) ? string.Empty : reader[Campos.nombreObjeto].ToString();
            resultado.DatosObjeto = reader.IsDBNull(reader.GetOrdinal(Campos.datosObjeto)) ? string.Empty : reader[Campos.datosObjeto].ToString();
            resultado.Descripcion = reader.IsDBNull(reader.GetOrdinal(Campos.descripcion)) ? string.Empty : reader[Campos.descripcion].ToString();
            return resultado;
        }

        /// <summary>
        /// maps the reader to plan object.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Entity plan</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 17/06/2016
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
            plan.ValorIVA = reader.IsDBNull(reader.GetOrdinal(Campos.ValorIVA)) ? 0 : (decimal)reader[Campos.ValorIVA];
            plan.ValorSinIVA = reader.IsDBNull(reader.GetOrdinal(Campos.ValorSinIVA)) ? 0 : (decimal)reader[Campos.ValorSinIVA];
            plan.NombrePlan = reader.IsDBNull(reader.GetOrdinal(Campos.nombrePlan)) ? string.Empty : (string)reader[Campos.nombrePlan];
            plan.Descripcion = reader.IsDBNull(reader.GetOrdinal(Campos.descripcion)) ? string.Empty : (string)reader[Campos.descripcion];
            plan.CodigoPlan = reader.IsDBNull(reader.GetOrdinal(Campos.CodigoPlan)) ? 0 : (int)reader[Campos.CodigoPlan];
            plan.CodigoConvenio = reader.IsDBNull(reader.GetOrdinal(Campos.codigoConvenio)) ? 0 : (int)reader[Campos.codigoConvenio];
            plan.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? false : (bool)reader[Campos.activo];

            return plan;
        }

        /// <summary>
        /// maps the reader to plan object.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Entity plan</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 17/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public TipoIdentificacion DataReaderATipoIdentificacion(IDataReader reader)
        {
            TipoIdentificacion tipoIdentificacion = new TipoIdentificacion();

            tipoIdentificacion.IdTipoIdentificacion = reader.IsDBNull(reader.GetOrdinal(Campos.idTipoIdentificacion)) ? 0 : (int)reader[Campos.idTipoIdentificacion];
            tipoIdentificacion.Nombre = reader.IsDBNull(reader.GetOrdinal(Campos.nombre)) ? string.Empty : (string)reader[Campos.nombre];

            return tipoIdentificacion;
        }

        /// <summary>
        /// maps the reader to product variable.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Product variable object</returns>
        public VariableProducto DataReaderAVariableProducto(IDataReader reader)
        {
            VariableProducto resultado = new VariableProducto();

            resultado.IdVariableProducto = reader.IsDBNull(reader.GetOrdinal(Campos.idVariableProducto)) ? 0 : (int)reader[Campos.idVariableProducto];
            resultado.IdSeguro = reader.IsDBNull(reader.GetOrdinal(Campos.idSeguro)) ? 0 : (int)reader[Campos.idSeguro];
            resultado.NombreCampo = reader.IsDBNull(reader.GetOrdinal(Campos.nombreCampo)) ? string.Empty : (string)reader[Campos.nombreCampo];
            resultado.IdTipoDato = reader.IsDBNull(reader.GetOrdinal(Campos.idTipoDato)) ? 0 : (int)reader[Campos.idTipoDato];
            resultado.Longitud = reader.IsDBNull(reader.GetOrdinal(Campos.longitud)) ? 0 : (int)reader[Campos.longitud];
            resultado.IdMaestra = reader.IsDBNull(reader.GetOrdinal(Campos.idMaestra)) ? (int?)null : (int)reader[Campos.idMaestra];
            resultado.Orden = reader.IsDBNull(reader.GetOrdinal(Campos.orden)) ? 0 : (int)reader[Campos.orden];
            resultado.Estado = reader.IsDBNull(reader.GetOrdinal(Campos.estado)) ? false : (bool)reader[Campos.estado];

            return resultado;
        }

        /// <summary>
        /// Maps the reader a master.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Master object</returns>
        public Maestra DataReaderAMaestra(IDataReader reader)
        {
            Maestra resultado = new Maestra();

            resultado.IdMaestra= reader.IsDBNull(reader.GetOrdinal(Campos.idMaestra)) ? 0 : (int)reader[Campos.idMaestra];
            resultado.Nombre = reader.IsDBNull(reader.GetOrdinal(Campos.nombre)) ? string.Empty : (string)reader[Campos.nombre];
            resultado.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? false : (bool)reader[Campos.activo];

            return resultado;
        }

        /// <summary>
        /// Maps the reader to item master.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Item Master object</returns>
        public ItemMaestra DataReaderAItemMaestra(IDataReader reader)
        {
            ItemMaestra resultado = new ItemMaestra();
            resultado.IdMaestra = reader.IsDBNull(reader.GetOrdinal(Campos.idMaestra)) ? 0 : (int)reader[Campos.idMaestra];
            resultado.Codigo = reader.IsDBNull(reader.GetOrdinal(Campos.codigo)) ? string.Empty : (string)reader[Campos.codigo];
            resultado.Valor = reader.IsDBNull(reader.GetOrdinal(Campos.valor)) ? string.Empty : (string)reader[Campos.valor];
            resultado.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? false : (bool)reader[Campos.activo];

            return resultado;
        }

        /// <summary>
        /// mapper for Aseguradora.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Aseguradora entity</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA   
        /// CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Aseguradora DataReaderAseguradora(IDataReader reader)
        {
            Aseguradora resultado = new Aseguradora();
            resultado.IdAseguradora = reader.IsDBNull(reader.GetOrdinal(Campos.idAseguradora)) ? 0 : (int)reader[Campos.idAseguradora];
            resultado.Nombre = reader.IsDBNull(reader.GetOrdinal(Campos.nombreAseguradora)) ? string.Empty : reader[Campos.nombreAseguradora].ToString();
            return resultado;
        }

        /// <summary>
        /// mapper for Campos Poliza.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>CamposPoliza entity</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA   
        /// CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public CamposPoliza DataReaderCamposPoliza(IDataReader reader)
        {
            CamposPoliza campos = new CamposPoliza();
            campos.Campos = reader.IsDBNull(reader.GetOrdinal(Campos.CampoPoliza)) ? string.Empty : reader[Campos.CampoPoliza].ToString();
            //campos.Consecutivo = reader.IsDBNull(reader.GetOrdinal(Campos.consecutivo)) ? string.Empty : reader[0].ToString();
            //campos.FechaCreacion = reader.IsDBNull(reader.GetOrdinal("Fecha creación")) ? string.Empty : reader["Fecha creación"].ToString();
            //campos.Nacionalidad = reader.IsDBNull(reader.GetOrdinal(Campos.nacionalidad)) ? string.Empty : reader[Campos.nacionalidad].ToString();
            //campos.TipoIdentificacion = reader.IsDBNull(reader.GetOrdinal(Campos.TipoIdentificacion)) ? string.Empty : reader[Campos.TipoIdentificacion].ToString();
            //campos.NumeroIdentificacion = reader.IsDBNull(reader.GetOrdinal(Campos.NumeroIdentificacion)) ? string.Empty : reader[Campos.NumeroIdentificacion].ToString();
            //campos.Genero = reader.IsDBNull(reader.GetOrdinal(Campos.Genero)) ? string.Empty : reader[Campos.Genero].ToString();
            //campos.PrimerNombre = reader.IsDBNull(reader.GetOrdinal(Campos.primerNombre)) ? string.Empty : reader[Campos.primerNombre].ToString();
            //campos.SegundoNombre = reader.IsDBNull(reader.GetOrdinal(Campos.segundoNombre)) ? string.Empty : reader[Campos.segundoNombre].ToString();
            //campos.PrimerApellido = reader.IsDBNull(reader.GetOrdinal(Campos.primerApellido)) ? string.Empty : reader[Campos.primerApellido].ToString();
            //campos.SegundoApellido = reader.IsDBNull(reader.GetOrdinal(Campos.segundoApellido)) ? string.Empty : reader[Campos.segundoApellido].ToString();
            //campos.FechaNacimiento = reader.IsDBNull(reader.GetOrdinal(Campos.fechaNacimiento)) ? string.Empty : reader[Campos.fechaNacimiento].ToString();
            //campos.CiudadNacimiento = reader.IsDBNull(reader.GetOrdinal(Campos.ciudadNacimiento)) ? string.Empty : reader[Campos.ciudadNacimiento].ToString();
            //campos.DepartamentoResidencia = reader.IsDBNull(reader.GetOrdinal(Campos.DepartamentoResidencia)) ? string.Empty : reader[Campos.DepartamentoResidencia].ToString();
            //campos.CiudadResidencia = reader.IsDBNull(reader.GetOrdinal(Campos.ciudadResidencia)) ? string.Empty : reader[Campos.ciudadResidencia].ToString();
            //campos.Direccion = reader.IsDBNull(reader.GetOrdinal(Campos.direccion)) ? string.Empty : reader[Campos.direccion].ToString();
            //campos.Telefono = reader.IsDBNull(reader.GetOrdinal(Campos.telefono)) ? string.Empty : reader[Campos.telefono].ToString();
            //campos.Celular = reader.IsDBNull(reader.GetOrdinal(Campos.celular)) ? string.Empty : reader[Campos.celular].ToString();
            //campos.Correo = reader.IsDBNull(reader.GetOrdinal(Campos.correo)) ? string.Empty : reader[Campos.correo].ToString();
            //campos.IdentificacionAseguradora = reader.IsDBNull(reader.GetOrdinal(Campos.IdentificacionAseguradora)) ? string.Empty : reader[Campos.IdentificacionAseguradora].ToString();
            //campos.NombreAseguradora = reader.IsDBNull(reader.GetOrdinal(Campos.nombreAseguradora)) ? string.Empty : reader[Campos.nombreAseguradora].ToString();
            //campos.ValorPoliza = reader.IsDBNull(reader.GetOrdinal(Campos.ValorPoliza)) ? string.Empty : reader[Campos.ValorPoliza].ToString();
            //campos.CodigoPlan = reader.IsDBNull(reader.GetOrdinal(Campos.CodigoPlan)) ? string.Empty : reader[Campos.CodigoPlan].ToString();
            //campos.NombrePlan = reader.IsDBNull(reader.GetOrdinal(Campos.nombrePlan)) ? string.Empty : reader[Campos.nombrePlan].ToString();
            //campos.CodigoProducto = reader.IsDBNull(reader.GetOrdinal(Campos.codigoProducto)) ? string.Empty : reader[Campos.codigoProducto].ToString();
            //campos.NombreProducto = reader.IsDBNull(reader.GetOrdinal(Campos.NombreProducto)) ? string.Empty : reader[Campos.NombreProducto].ToString();
            //campos.CodigoTipoCuenta = reader.IsDBNull(reader.GetOrdinal(Campos.CodigoTipoCuenta)) ? string.Empty : reader[Campos.CodigoTipoCuenta].ToString();
            //campos.NombreTipoCuenta = reader.IsDBNull(reader.GetOrdinal(Campos.NombreTipoCuenta)) ? string.Empty : reader[Campos.NombreTipoCuenta].ToString();
            //campos.NumeroCuenta = reader.IsDBNull(reader.GetOrdinal(Campos.NumeroCuenta)) ? string.Empty : reader[Campos.NumeroCuenta].ToString();
            //campos.CanalVenta = reader.IsDBNull(reader.GetOrdinal(Campos.CanalVenta)) ? string.Empty : reader[Campos.CanalVenta].ToString();
            //campos.NombreCanalVenta = reader.IsDBNull(reader.GetOrdinal(Campos.NombreCanalVenta)) ? string.Empty : reader[Campos.NombreCanalVenta].ToString();
            //campos.Convenio = reader.IsDBNull(reader.GetOrdinal(Campos.Convenio)) ? string.Empty : reader[Campos.Convenio].ToString();
            //campos.Periodicidad = reader.IsDBNull(reader.GetOrdinal(Campos.Periodicidad)) ? string.Empty : reader[Campos.Periodicidad].ToString();
            //campos.MesesPeriodicidad = reader.IsDBNull(reader.GetOrdinal(Campos.MesesPeriodicidad)) ? string.Empty : reader[Campos.MesesPeriodicidad].ToString();
            //campos.CodigoOficina = reader.IsDBNull(reader.GetOrdinal(Campos.CodigoOficina)) ? string.Empty : reader[Campos.CodigoOficina].ToString();
            //campos.CiudadOficina = reader.IsDBNull(reader.GetOrdinal(Campos.CiudadOficina)) ? string.Empty : reader[Campos.CiudadOficina].ToString();
            //campos.NombreOficina = reader.IsDBNull(reader.GetOrdinal(Campos.NombreOficina)) ? string.Empty : reader[Campos.NombreOficina].ToString();
            //campos.CodigoAsesor = reader.IsDBNull(reader.GetOrdinal(Campos.CodigoAsesor)) ? string.Empty : reader[Campos.CodigoAsesor].ToString();
            //campos.IdentificacionAsesor = reader.IsDBNull(reader.GetOrdinal(Campos.IdentificacionAsesor)) ? string.Empty : reader[Campos.IdentificacionAsesor].ToString();
            //campos.NombreAsesor = reader.IsDBNull(reader.GetOrdinal(Campos.NombreAsesor)) ? string.Empty : reader[Campos.NombreAsesor].ToString();
            //campos.EstadoPoliza = reader.IsDBNull(reader.GetOrdinal(Campos.EstadoPoliza)) ? string.Empty : reader[Campos.EstadoPoliza].ToString();
            //campos.UltimoIPC = reader.IsDBNull(reader.GetOrdinal(Campos.UltimoIPC)) ? string.Empty : reader[Campos.UltimoIPC].ToString();
            //campos.Altura = reader.IsDBNull(reader.GetOrdinal(Campos.Altura)) ? string.Empty : reader[Campos.Altura].ToString();
            return campos;
        }

        public CamposCobros DatareaderCamposCobros(IDataReader reader)
        {
            CamposCobros campos = new CamposCobros();
            campos.Campos = reader.IsDBNull(reader.GetOrdinal(Campos.CampoPoliza)) ? string.Empty : reader[Campos.CampoPoliza].ToString();

            return campos;
        }

        public CamposCancelaciones DatareaderCamposCancelaciones(IDataReader reader)
        {
            CamposCancelaciones campos = new CamposCancelaciones();
            campos.Campos = reader.IsDBNull(reader.GetOrdinal(Campos.CampoPoliza)) ? string.Empty : reader[Campos.CampoPoliza].ToString();
            return campos;
        }

        public CamposCancelaciones DatareaderFiltrosCancelaciones(IDataReader reader)
        {
            CamposCancelaciones campos = new CamposCancelaciones();
            campos.IdCausalNovedad = reader.IsDBNull(reader.GetOrdinal(Campos.IdCausalNovedad)) ? string.Empty : reader[Campos.IdCausalNovedad].ToString();
            campos.Campos = reader.IsDBNull(reader.GetOrdinal(Campos.CampoPoliza)) ? string.Empty : reader[Campos.CampoPoliza].ToString();

            return campos;
        }

        public ArchivoPlano DataReaderFilaArchivosPlanos(IDataReader reader)
        {
            ArchivoPlano fila = new ArchivoPlano();
            fila.IdProgramacion = reader.IsDBNull(reader.GetOrdinal("idProgramacion")) ? 0 : (int)reader["idProgramacion"];
            fila.NombreArchivo = reader.IsDBNull(reader.GetOrdinal("nombre")) ? string.Empty : reader["nombre"].ToString();
            fila.Objetivo = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? string.Empty : reader["descripcion"].ToString();
            fila.FrecuenciaTipoProgramacion = reader.IsDBNull(reader.GetOrdinal("tipoProgramacion")) ? string.Empty : reader["tipoProgramacion"].ToString();
            fila.Estado = reader.IsDBNull(reader.GetOrdinal("estado")) ? string.Empty : reader["estado"].ToString();
            fila.RutaFTP = reader.IsDBNull(reader.GetOrdinal("rutaDestinoFTP")) ? string.Empty : reader["rutaDestinoFTP"].ToString();
            fila.UltimaEjecucion = reader.IsDBNull(reader.GetOrdinal("ultimaEjecucion")) ? string.Empty : reader["ultimaEjecucion"].ToString();
            fila.FechaInicio = reader.IsDBNull(reader.GetOrdinal("fechaInicio")) ? DateTime.Now : (DateTime)reader["fechaInicio"];
            fila.FechaFin = reader.IsDBNull(reader.GetOrdinal("fechaFin")) ? DateTime.Now : (DateTime)reader["fechaFin"];
            fila.Campos = reader.IsDBNull(reader.GetOrdinal("camposConsulta")) ? string.Empty : reader["camposConsulta"].ToString();
            fila.Filtros = reader.IsDBNull(reader.GetOrdinal("criterioFiltro")) ? string.Empty : reader["criterioFiltro"].ToString();
            fila.CodigoFiltro = reader.IsDBNull(reader.GetOrdinal("codigoFiltro")) ? string.Empty : reader["codigoFiltro"].ToString();
            fila.Separador = reader.IsDBNull(reader.GetOrdinal("separador")) ? string.Empty : reader["separador"].ToString();
            fila.IdAseguradora = reader.IsDBNull(reader.GetOrdinal("idAseguradora")) ? string.Empty : reader["idAseguradora"].ToString();

            var xml = reader.IsDBNull(reader.GetOrdinal("programacion")) ? string.Empty : reader["programacion"].ToString();
            string valorXML = (string)xml;
            int intervaloDiario = 0;
            int posicion = 0;
            bool bandError = false;
            bool valorBool = false;
            bool activoUnavez = false;
            DateTime fechaUnaVez = DateTime.Now;
            XmlDocument xmlConfig = new XmlDocument();
            xmlConfig.LoadXml(valorXML);
            bool[] diasSemana = new bool[7];
            bool[] diasMes = new bool[32];
            bool[] numSemanaMes = new bool[5];
            bool[] diaSemanaMes = new bool[7];

            XmlNodeList xmlConfigUnaVez = xmlConfig.SelectNodes("/ConfiguracionTarea/UnaVez");
            XmlNodeList xmlConfigDiario = xmlConfig.SelectNodes("/ConfiguracionTarea/Diario");
            XmlNodeList xmlConfigSemanal = xmlConfig.SelectNodes("/ConfiguracionTarea/Semanal/DiaSemana/boolean");
            XmlNodeList xmlConfigMensualDiaMes = xmlConfig.SelectNodes("/ConfiguracionTarea/Mensual/DiaMes/boolean");
            XmlNodeList xmlConfigMensualNumeroSemana = xmlConfig.SelectNodes("/ConfiguracionTarea/Mensual/SemanaMes/NumeroSemana/boolean");
            XmlNodeList xmlConfigMensualDiaMesSemana = xmlConfig.SelectNodes("/ConfiguracionTarea/Mensual/SemanaMes/DiaSemana/boolean");



            foreach (XmlNode xn in xmlConfigUnaVez)
            {
                bandError = bool.TryParse(xn["Activo"].InnerText, out activoUnavez);
                bandError = DateTime.TryParseExact(xn["Fecha"].InnerText.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaUnaVez);
                if (bandError)
                {
                    fila.FechaEjecucion = fechaUnaVez.ToString();
                }
            }

            foreach (XmlNode xn in xmlConfigDiario)
            {
                bandError = int.TryParse(xn["Intervalo"].InnerText, out intervaloDiario);
            }

            posicion = 0;
            foreach (XmlNode xn in xmlConfigSemanal)
            {
                bandError = bool.TryParse(xn.InnerText, out valorBool);
                diasSemana[posicion] = valorBool;
                if (valorBool)
                {
                    fila.DiaSemanal = posicion.ToString();
                }
                posicion++;
            }

            posicion = 0;
            foreach (XmlNode xn in xmlConfigMensualDiaMes)
            {
                bandError = bool.TryParse(xn.InnerText, out valorBool);
                diasMes[posicion] = valorBool;
                if (valorBool)
                {
                    fila.DiaMes = (posicion + 1).ToString();
                }
                posicion++;
            }

            posicion = 0;
            foreach (XmlNode xn in xmlConfigMensualNumeroSemana)
            {
                bandError = bool.TryParse(xn.InnerText, out valorBool);
                numSemanaMes[posicion] = valorBool;
                if (valorBool)
                {
                    fila.NumeroSemana = posicion.ToString();
                }
                posicion++;
            }

            posicion = 0;
            foreach (XmlNode xn in xmlConfigMensualDiaMesSemana)
            {
                bandError = bool.TryParse(xn.InnerText, out valorBool);
                diaSemanaMes[posicion] = valorBool;
                if (valorBool)
                {
                    fila.DiaSemana = posicion.ToString();
                }
                posicion++;
            }

            fila.FechaIni = fila.FechaInicio.ToString("dd/MM/yyyy");

            //fila.FechaFinal = fila.FechaFin.ToString("dd/MM/yyyy hh:mm:ss");
            


            return fila;
        }
    }
}
