//-----------------------------------------------------------------------
// <copyright file="RegistrarVenta.aspx.cs" company="UT">
//     Copyright (c) UT. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Venta
{
    using BancaSeguros.Entidades;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Linq;

    public class RepositorioDocumentoPoliza : IRepositorioDocumentoPoliza
    {
        private Database dataBase;

        public RepositorioDocumentoPoliza(string nombreConexion)
        {
            this.dataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        /// <summary>
        /// Obtiene el documento poliza por idSeguro.
        /// </summary>
        /// <param name="idSeguro">idSeguro.</param>
        /// <returns>Plantilla y estructura para generar el documento de la poliza</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 09/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DocumentoPoliza ObtenerDocumentoPolizaPorIdSeguro(int idSeguro)
        {
            DocumentoPoliza resultado = new DocumentoPoliza();
            Mapeador mapeador = new Mapeador();
            using (DbCommand dataBaseCommand = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarDocumentoPlantillaPoliza))
            {
                dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idSeguro, DbType.Int32, idSeguro);
                using (IDataReader reader = dataBase.ExecuteReader(dataBaseCommand))
                {
                    while (reader.Read())
                    {
                        var documentoPoliza = mapeador.DataReaderADocumentoPoliza(reader);
                        resultado = documentoPoliza;
                    }
                }
            }
            return resultado;
        }

  

        /// <summary>
        /// Obtiene la informacion del documento de la poliza.
        /// </summary>
        /// <param name="idPoliza">IdPoliza.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public EncabezadoPolizaDocumento ObtenerInformacionEncabezadoDocumentoPoliza(string consecutivoPoliza)
        {
            EncabezadoPolizaDocumento resultado = new EncabezadoPolizaDocumento();
            Mapeador mapeador = new Mapeador();
            using (DbCommand dataBaseCommand = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarInformacionPolizaPorConsecutivo))
            {
                dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Consecutivo, DbType.String, consecutivoPoliza);
                using (IDataReader reader = dataBase.ExecuteReader(dataBaseCommand))
                {
                    while (reader.Read())
                    {
                        resultado = mapeador.DataReaderADatosEncabezadoPoliza(reader);
                    }
                }
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene la informacion beneficiarios documento poliza.
        /// </summary>
        /// <param name="consecutivoPoliza">Consecutivo de la poliza.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 22/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<BeneficiariosPolizaDocumento> ObtenerInformacionBeneficiariosDocumentoPoliza(string consecutivoPoliza)
        {
            List<BeneficiariosPolizaDocumento> resultado = new List<BeneficiariosPolizaDocumento>();
            Mapeador mapeador = new Mapeador();
            using (DbCommand dataBaseCommand = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarInformacionBeneficiarioPorConsecutivoPoliza))
            {
                dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Consecutivo, DbType.String, consecutivoPoliza);
                using (IDataReader reader = dataBase.ExecuteReader(dataBaseCommand))
                {
                    while (reader.Read())
                    {
                        var documentoPoliza = mapeador.DataReaderDatosBeneficiariosPoliza(reader);
                        resultado.Add(documentoPoliza);

                    }
                }
            }
            return resultado;
        }


        /// <summary>
        /// Obtiene la informacion de los campos dinamicos de la poliza.
        /// </summary>
        /// <param name="consecutivoPoliza">Id de la venta.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\Enrique Rivera
        /// CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        /// <summary>
        /// Search the product variables.
        /// </summary>
        /// <param name="variable">The variable to search.</param>
        /// <returns>List of variables</returns>
        public List<VariableVenta> ObtenerInformacionVariableVentaDocumentoPoliza(VariableVenta variable)
        {
            List<VariableVenta> resultados = new List<VariableVenta>();

            VariableVenta resultadoVariableVenta = null;
            BancaSeguros.Repositorio.Venta.Mapeador mapeador = new BancaSeguros.Repositorio.Venta.Mapeador();

            using (DbCommand comandoBaseDatos = this.dataBase.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarVariableVenta))
            {
                this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idVariableVenta, DbType.Int32, variable.IdVariableVenta != 0 ? variable.IdVariableVenta : (int?)null);
                this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idVenta, DbType.Int32, variable.IdVenta != 0 ? variable.IdVenta : (int?)null);
                this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idVariableProducto, DbType.Int32, variable.IdVariableProducto != 0 ? variable.IdVariableProducto : (int?)null);
                this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Valor, DbType.Int32, variable.Valor);
                this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Consecutivo, DbType.String, variable.ConsecutivoPoliza);
                using (IDataReader reader = this.dataBase.ExecuteReader(comandoBaseDatos))
                {
                    while (reader.Read())
                    {
                        resultados.Add(resultadoVariableVenta = mapeador.DataReaderAVariableVenta(reader));
                    }
                }
            }

            return resultados;
        }


        /// <summary>
        /// Obtiene la informacion conyuge documento poliza.
        /// </summary>
        /// <param name="consecutivoPoliza">Consecutivo de la poliza.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 22/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public ConyugePolizaDocumento ObtenerInformacionConyugeDocumentoPoliza(string consecutivoPoliza)
        {
            ConyugePolizaDocumento resultado = new ConyugePolizaDocumento();
            Mapeador mapeador = new Mapeador();
            using (DbCommand dataBaseCommand = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarInformacionConyugePorConsecutivoPoliza))
            {
                dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Consecutivo, DbType.String, consecutivoPoliza);
                using (IDataReader reader = dataBase.ExecuteReader(dataBaseCommand))
                {
                    while (reader.Read())
                    {
                        resultado = mapeador.DataReaderDatosConyugePoliza(reader);
                    }
                }
            }
            return resultado;
        }

        /// <summary>
        /// Insertar documento plantilla seguro.
        /// </summary>
        /// <param name="documentoPoliza">Documento poliza.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 24/02/2016
        /// ModifiedBy:   INTERGRUPO\CPIZA
        /// ModifiedDate: 09/03/2016
        /// PropositoCambio: Se agregaron los nuevos campos
        /// ModifiedBy:  
        /// ModifiedDate: 
        /// </remarks>
        public Resultado InsertarDocumentoPlantillaSeguro(DocumentoPoliza documentoPoliza)
        {
            Resultado resultado = new Resultado();

            DbCommand dataBaseCommand = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_InsertarPlantillaSeguro);
            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idSeguro, DbType.Int32, documentoPoliza.IdSeguro);
            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Plantilla, DbType.Binary, documentoPoliza.Plantilla);
            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.VersionDocumento, DbType.String, documentoPoliza.VersionDocumento);
            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.FechaCreacion, DbType.DateTime, documentoPoliza.FechaCreacion);
            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.UsuarioCreacion, DbType.String, documentoPoliza.UsuarioCreacion);
            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Activa, DbType.Boolean, documentoPoliza.Activa);
            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.NombreArchivo, DbType.String, documentoPoliza.NombreArchivo);
            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.CamposPlantilla, DbType.String, documentoPoliza.CamposPlantilla);
            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Eliminado, DbType.Boolean, documentoPoliza.Eliminado);
            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.usuario, DbType.String, documentoPoliza.Usuario);
            this.dataBase.ExecuteNonQuery(dataBaseCommand);
            resultado.Error = false;

            return resultado;
        }

        /// <summary>
        /// Insertar documento plantilla seguro.
        /// </summary>
        /// <param name="documentoPoliza">Documento poliza.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 24/02/2016
        /// ModifiedBy:  
        /// ModifiedDate: 
        /// </remarks>
        public Resultado GuardarPolizaVendidaImpresion(System.Xml.Linq.XElement plantillaXml, int IdDocumentoPoliza, string consecutivoPoliza)
        {
            Resultado resultado = new Resultado();
            try
            {
                DbCommand dataBaseCommand = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_GuardarPolizaVendidaImpresion);

                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.PlantillaXML, DbType.Xml, plantillaXml.ToString());
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.IdDocumentoPoliza, DbType.Int32, IdDocumentoPoliza);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Consecutivo, DbType.String, consecutivoPoliza);

                this.dataBase.ExecuteNonQuery(dataBaseCommand);

                resultado.Error = false;
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ex.Message;
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene las plantillas por idseguro.
        /// </summary>
        /// <param name="idSeguro">IdSeguro.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 22/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<DocumentoPoliza> ObtenerPlantillasPorIdSeguro(int idSeguro)
        {
            List<DocumentoPoliza> resultado = new List<DocumentoPoliza>();
            Mapeador mapeador = new Mapeador();
            using (DbCommand dataBaseCommand = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarPlantillaPorIdSeguro))
            {
                dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idSeguro, DbType.Int32, idSeguro);
                using (IDataReader reader = dataBase.ExecuteReader(dataBaseCommand))
                {
                    while (reader.Read())
                    {
                        var documentoPoliza = mapeador.DataReaderADocumentosPolizaPorSeguro(reader);
                        resultado.Add(documentoPoliza);
                    }
                }
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene la informacion del documento de la poliza para reimpresion.
        /// </summary>
        /// <param name="consecutivoPoliza">consecutivoPoliza</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 23/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DocumentoPoliza ConsultarInformacionReimpresion(string consecutivoPoliza)
        {
            DocumentoPoliza resultado = new DocumentoPoliza();
            Mapeador mapeador = new Mapeador();
            using (DbCommand dataBaseCommand = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarInformacionReimpresion))
            {
                dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Consecutivo, DbType.String, consecutivoPoliza);
                using (IDataReader reader = dataBase.ExecuteReader(dataBaseCommand))
                {
                    while (reader.Read())
                    {
                        var documentoPoliza = mapeador.DataReaderADocumentoPoliza(reader);
                        resultado = documentoPoliza;
                    }
                }
            }
            return resultado;
        }


        /// <summary>
        /// Obtiene el id seguro por el consecutivo poliza
        /// </summary>
        /// <param name="consecutivoPoliza">consecutivoPoliza</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CALVAREZP
        /// CreationDate: 29/09/2020
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int ConsultarSeguroPorConsecutivoPoliza(string consecutivoPoliza)
        {
            int resultado = 0;
            Mapeador mapeador = new Mapeador();
            using (DbCommand dataBaseCommand = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarSeguroPorConsecutivoPoliza))
            {
                dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Consecutivo, DbType.String, consecutivoPoliza);
                using (IDataReader reader = dataBase.ExecuteReader(dataBaseCommand))
                {
                    while (reader.Read())
                    {
                        resultado = Int32.Parse(reader[0].ToString());
                    }
                }
            }
            return resultado;
        }
        /// <summary>
        /// Elimina una plantilla.
        /// </summary>
        /// <param name="idDocumentoPlantilla">idDocumentoPlantilla.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 23/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 23/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado EliminarPlantilla(int idDocumentoPoliza)
        {
            Resultado resultado = new Resultado();
            try
            {
                DbCommand dataBaseCommand = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizarEstadoEliminadoPlantilla);

                dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.IdDocumentoPoliza, DbType.Int32, idDocumentoPoliza);
                dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Eliminado, DbType.Boolean, true);
                this.dataBase.ExecuteNonQuery(dataBaseCommand);
                resultado.Error = false;

            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ex.Message;
            }
            return resultado;
        }

        /// <summary>
        /// Estadoes the plantilla.
        /// </summary>
        /// <param name="idDocumentoPoliza">The identifier documento poliza.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 23/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActivarEstadoPlantilla(int idDocumentoPoliza)
        {
            Resultado resultado = new Resultado();

            DbCommand dataBaseCommand = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizarEstadoActivoPlantilla);
            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.IdDocumentoPoliza, DbType.Int32, idDocumentoPoliza);
            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Activa, DbType.Boolean, true);
            this.dataBase.ExecuteNonQuery(dataBaseCommand);
            resultado.Error = false;
            return resultado;
        }

        /// <summary>
        /// Validars the plantillas creadas por identifier plantilla.
        /// </summary>
        /// <param name="idDocumentoPoliza">The identifier documento poliza.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 23/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Resultado ValidarPlantillasCreadasPorIdPlantilla(int idDocumentoPoliza)
        {
            Resultado resultado = new Resultado();
            try
            {
                using (DbCommand dataBaseCommand = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ObtenerPolizasCreadasPorIdDocumentoPoliza))
                {
                    dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.IdDocumentoPoliza, DbType.Int32, idDocumentoPoliza);
                    using (IDataReader reader = dataBase.ExecuteReader(dataBaseCommand))
                    {
                        List<int> listaPolizas = new List<int>();
                        while (reader.Read())
                        {
                            listaPolizas.Add(reader.IsDBNull(reader.GetOrdinal(Campos.idImpresionPoliza)) ? 0 : (int)reader[Campos.idImpresionPoliza]);
                        }
                        resultado.Error = listaPolizas.Any();
                        resultado.Mensaje = resultado.Error ? "La plantilla que desea eliminar tiene polizas asociadas" : string.Empty;
                    }
                }
            }
            catch (Exception exception)
            {
                resultado.Error = true;
                resultado.Mensaje = exception.Message;
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene el documento poliza por idSeguro.
        /// </summary>
        /// <param name="idSeguro">idSeguro.</param>
        /// <returns>Plantilla y estructura para generar el documento de la poliza</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 09/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DocumentoPoliza ObtenerDocumentoPolizaPorIdDocumentoPoliza(int idDocumentoPoliza)
        {
            DocumentoPoliza resultado = new DocumentoPoliza();
            Mapeador mapeador = new Mapeador();
            using (DbCommand dataBaseCommand = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarDocumentoPlantillaPolizaPorId))
            {
                dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.IdDocumentoPoliza, DbType.Int32, idDocumentoPoliza);
                using (IDataReader reader = dataBase.ExecuteReader(dataBaseCommand))
                {
                    while (reader.Read())
                    {
                        var documentoPoliza = mapeador.DataReaderADocumentoPoliza(reader);
                        resultado = documentoPoliza;
                    }
                }
            }
            return resultado;
        }

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
            List<DocumentoPoliza> documentoPolizas = new List<DocumentoPoliza>();
            Mapeador mapeador = new Mapeador();
            using (DbCommand dataBaseCommand = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarPlnatillasActivas))
            {
                using (IDataReader reader = dataBase.ExecuteReader(dataBaseCommand))
                {
                    while (reader.Read())
                    {
                        DocumentoPoliza documento = new DocumentoPoliza();
                        documento = mapeador.DataReaderADocumentoPoliza(reader);
                        documentoPolizas.Add(documento);
                    }
                }
            }
            return documentoPolizas;
        }


        /// <summary>
        /// Insert the template sure.
        /// </summary>
        /// <param name="documentoPoliza">The document policy.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 11/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado InsertarPlantillaSeguroDuplicada(DocumentoPoliza documentoPoliza)
        {
            Resultado resultado = new Resultado();

            DbCommand dataBaseCommand = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_InsertarPlantillaSeguroDuplicada);
            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.IdDocumentoPoliza, DbType.Int32, documentoPoliza.IdDocumentoPoliza);
            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idSeguro, DbType.Int32, documentoPoliza.IdSeguro);
            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Login, DbType.String, documentoPoliza.UsuarioCreacion);
            this.dataBase.ExecuteNonQuery(dataBaseCommand);

            resultado.Error = false;

            return resultado;
        }

        /// <summary>
        /// update the template.
        /// </summary>
        /// <param name="documentoPoliza">The document policy.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizarPlantilla(DocumentoPoliza documentoPoliza)
        {
            Resultado resultado = new Resultado();

            DbCommand dataBaseCommand = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizarPlantilla);

            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.IdDocumentoPoliza, DbType.Int32, documentoPoliza.IdDocumentoPoliza);
            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idSeguro, DbType.Int32, documentoPoliza.IdSeguro);
            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Login, DbType.String, documentoPoliza.UsuarioCreacion);
            this.dataBase.ExecuteNonQuery(dataBaseCommand);

            return resultado;
        }

        public Resultado DesActivarPlantillasPorIdSeguro(int idSeguro)
        {
            Resultado resultado = new Resultado();

            DbCommand dataBaseCommand = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_DesActivarPlantillasPorIdSeguro);

            this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idSeguro, DbType.Int32, idSeguro);
            this.dataBase.ExecuteNonQuery(dataBaseCommand);

            return resultado;
        }
    }
}
