using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BancaSeguros.Entidades.Catalogo;

namespace BancaSeguros.Repositorio.Catalogo
{
    class Mapeador
    {
        public TipoIdentificacion DataReaderATipoIdentificacion(IDataReader reader)
        {
            TipoIdentificacion tipoIdentificacion = new TipoIdentificacion();

            tipoIdentificacion.IdTipoIdentificacion = reader.IsDBNull(reader.GetOrdinal("idTipoIdentificacion")) ? 0 : (int)reader["idTipoIdentificacion"];
            tipoIdentificacion.Nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? string.Empty : (string)reader["nombre"];
            tipoIdentificacion.TipoPersona = reader.IsDBNull(reader.GetOrdinal("tipoPersona")) ? 0 : (int)reader["tipoPersona"];
            tipoIdentificacion.Activo = reader.IsDBNull(reader.GetOrdinal("activo")) ? false : (bool)reader["activo"];

            return tipoIdentificacion;
        }
    }
}
