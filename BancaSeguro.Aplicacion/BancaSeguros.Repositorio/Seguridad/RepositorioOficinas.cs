using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Common;
using BAC.EntidadesSeguridad;
using BancaSeguros.Repositorio.Configuraciones;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace BancaSeguros.Repositorio.Seguridad
{
    public class RepositorioOficinas : IRepositorioOficinas
    {
        #region Variables

        private Database db;

        #endregion 

        #region Constructor

        public RepositorioOficinas(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        public Entidades.Catalogo.ListaOficinas ConsultarOficinas(int Opcion)
        {
           // Resultado resultado = new Resultado();
            string nombreProcedimiento = Procedimientos.ConsultarOficinas;
            Entidades.Catalogo.ListaOficinas oficinas = new Entidades.Catalogo.ListaOficinas();
            Mapeador mapeador = new Mapeador();
            oficinas.ListOficinas = new List<Entidades.Catalogo.Oficina>();
            oficinas.Resultado = new BancaSeguros.Entidades.General.Resultado();

            using (DbCommand cmd = this.db.GetStoredProcCommand(nombreProcedimiento))
            {
                this.db.AddInParameter(cmd, ParametrosEntradaProcedimientos.opcion, DbType.Int32, Opcion);
                IDataReader reader = this.db.ExecuteReader(cmd);
                while (reader.Read())
                {
                    Entidades.Catalogo.Oficina Oficina = new Entidades.Catalogo.Oficina();
                    Oficina = mapeador.DataReaderAOficinas(reader);
                    oficinas.ListOficinas.Add(Oficina);
                }

                return oficinas;
            }
        }

        public BancaSeguros.Entidades.General.Resultado ActualizarOficinas(BancaSeguros.Entidades.Catalogo.Oficina oficina)
        {
            BancaSeguros.Entidades.General.Resultado resultado = new BancaSeguros.Entidades.General.Resultado();
            string nombreProcedimiento = Procedimientos.ActualizarOficina;

            using (DbCommand cmd = this.db.GetStoredProcCommand(nombreProcedimiento))
            {
                this.db.AddInParameter(cmd, "@opcion", DbType.String, oficina.Opcion);
                this.db.AddInParameter(cmd, "@idOficina", DbType.Int32, oficina.IdOficina);
                this.db.AddInParameter(cmd, "@nombre", DbType.String, oficina.Nombre);
                this.db.AddInParameter(cmd, "@ciudad", DbType.String, oficina.Ciudad);
                this.db.AddInParameter(cmd, "@activo", DbType.Boolean, Convert.ToBoolean(oficina.Activo));

                if (this.db.ExecuteNonQuery(cmd) > 0)
                {
                    resultado.Error = false;
                    resultado.Mensaje = "Actualización exitosa.";
                }
                else
                {
                    resultado.Error = true;
                    resultado.Mensaje = "Actualización fallida.";
                }
            }

            return resultado;

        }

        public BancaSeguros.Entidades.General.Resultado LOGOficinas(BancaSeguros.Entidades.Catalogo.Oficina oficina)
        {
            BancaSeguros.Entidades.General.Resultado resultado = new BancaSeguros.Entidades.General.Resultado();
            string nombreProcedimiento = Procedimientos.GuardarLogOficinas;

            using (DbCommand cmd = this.db.GetStoredProcCommand(nombreProcedimiento))
            {
                this.db.AddInParameter(cmd, "@fecha", DbType.DateTime, oficina.Fecha);
                this.db.AddInParameter(cmd, "@usuario", DbType.String, oficina.Usuario);
                this.db.AddInParameter(cmd, "@tipoevento", DbType.String, oficina.Tipoevento);
                this.db.AddInParameter(cmd, "@inicial", DbType.String, oficina.Inicial);
                this.db.AddInParameter(cmd, "@final", DbType.String, oficina.Final);
                this.db.AddOutParameter(cmd, "@num_transac", DbType.Decimal, 1);

                if (this.db.ExecuteNonQuery(cmd) != 0)
                {
                    resultado.Error = false;
                    resultado.Mensaje = "Actualización exitosa.";
                }
                else
                {
                    resultado.Error = true;
                    resultado.Mensaje = "Actualización fallida.";
                }
            }

            return resultado;

        }

        #endregion

    }
}
