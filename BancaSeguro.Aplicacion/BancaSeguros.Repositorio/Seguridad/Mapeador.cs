//-----------------------------------------------------------------------
// <copyright file="Mapeador.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Seguridad
{
    using System;
    using System.Data;
    using BAC.EntidadesSeguridad;
    using BancaSeguros.Repositorio.Configuraciones;
    using BancaSeguros.Entidades.Administracion;
    
    /// <summary>
    /// Map Class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 26/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public class Mapeador
    {
        /// <summary>
        /// Map the reader to user.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Object User</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Usuario DataReaderAUsuario(IDataReader reader)
        {
            Usuario usuario = new Usuario();

            usuario.IdUsuario = reader.IsDBNull(reader.GetOrdinal("idUsuario")) ? 0 : (int)reader["idUsuario"];
            usuario.Login = reader.IsDBNull(reader.GetOrdinal("login")) ? string.Empty : (string)reader["login"];
            usuario.Nombres = reader.IsDBNull(reader.GetOrdinal("nombres")) ? string.Empty : (string)reader["nombres"];
            usuario.Apellidos = reader.IsDBNull(reader.GetOrdinal("apellidos")) ? string.Empty : (string)reader["apellidos"];
            usuario.Email = reader.IsDBNull(reader.GetOrdinal("email")) ? string.Empty : (string)reader["email"];
            usuario.Activo = reader.IsDBNull(reader.GetOrdinal("activo")) ? false : (bool)reader["activo"];
                        
            return usuario;
        }

        /// <summary>
        /// Map the reader a menu.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Object Menu</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Menu DataReaderAMenu(IDataReader reader)
        {
            Menu menu = new Menu();

            menu.IdMenu = reader.IsDBNull(reader.GetOrdinal("idMenu")) ? 0 : (int)reader["idMenu"];
            menu.IdPadre = reader.IsDBNull(reader.GetOrdinal("idPadre")) ? 0 : (int)reader["idPadre"];
            menu.Nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? string.Empty : (string)reader["nombre"];
            menu.Posicion = reader.IsDBNull(reader.GetOrdinal("posicion")) ? 0 : (int)reader["posicion"];
            menu.Url = reader.IsDBNull(reader.GetOrdinal("URL")) ? string.Empty : (string)reader["URL"];
            menu.Activo = reader.IsDBNull(reader.GetOrdinal("activo")) ? false : (bool)reader["activo"];

            return menu;
        }

        /// <summary>
        /// Map the reader to role.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Object Role</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Rol DataReaderARol(IDataReader reader)
        {
            Rol rol = new Rol();

            rol.IdRol = reader.IsDBNull(reader.GetOrdinal("idRol")) ? 0 : (int)reader["idRol"];
            rol.Nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? string.Empty : (string)reader["nombre"];
            rol.Activo = reader.IsDBNull(reader.GetOrdinal("activo")) ? false : (bool)reader["activo"]; 

            return rol;
        }

        /// <summary>
        /// Map the reader to office.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Object office</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Oficina DataReaderAOficina(IDataReader reader)
        {
            Oficina oficina = new Oficina();

            oficina.IdOficina = reader.IsDBNull(reader.GetOrdinal(Campos.idOficina)) ? 0 : (int)reader[Campos.idOficina];
            oficina.Codigo = reader.IsDBNull(reader.GetOrdinal(Campos.idOficina)) ? string.Empty : ((int)reader[Campos.idOficina]).ToString();
            oficina.Nombre = reader.IsDBNull(reader.GetOrdinal(Campos.nombre)) ? string.Empty : (string)reader[Campos.nombre];
            oficina.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? false : (bool)reader[Campos.activo];

            return oficina;
        }

        /// <summary>
        /// Map the reader to office.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Object office</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public BancaSeguros.Entidades.Catalogo.Oficina DataReaderAOficinas(IDataReader reader)
        {
            Entidades.Catalogo.Oficina oficina = new Entidades.Catalogo.Oficina();

            oficina.IdOficina = reader.IsDBNull(reader.GetOrdinal(Campos.idOficina)) ? 0 : (int)reader[Campos.idOficina];
            oficina.Nombre = reader.IsDBNull(reader.GetOrdinal(Campos.nombre)) ? string.Empty : (string)reader[Campos.nombre];
            oficina.Ciudad = reader.IsDBNull(reader.GetOrdinal("ciudad")) ? string.Empty : (string)reader["ciudad"];
            oficina.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? 0 : Convert.ToInt32(reader[Campos.activo]);

            return oficina;
        }

        /// <summary>
        /// Map the reader to group entity.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Group entity</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public GrupoBAC DataReaderAGrupoBAC(IDataReader reader)
        {
            GrupoBAC resultado = new GrupoBAC();
            resultado.IdGrupo = reader.IsDBNull(reader.GetOrdinal(Campos.idGrupo)) ? 0 : (int)reader[Campos.idGrupo];
            resultado.NombreGrupo = reader.IsDBNull(reader.GetOrdinal(Campos.nombreGrupo)) ? string.Empty : reader[Campos.nombreGrupo].ToString();
            resultado.CodigoGrupo = reader.IsDBNull(reader.GetOrdinal(Campos.codigoGrupo)) ? string.Empty : reader[Campos.codigoGrupo].ToString();
            resultado.Activo = reader.IsDBNull(reader.GetOrdinal(Campos.activo)) ? false : (bool)reader[Campos.activo];
            return resultado;
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
        /// Map the reader to menu for Combo Control Dual.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Menu</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Menu DataReaderMenuControlDual(IDataReader reader)
        {
            Menu resultado = new Menu();
            resultado.IdMenu = reader.IsDBNull(reader.GetOrdinal("idMenu")) ? 0 : (int)reader["idMenu"];
            resultado.Nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? string.Empty : (string)reader["nombre"];
            return resultado;
        }

        /// <summary>
        /// Map the reader to menu for Combo Control Dual.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Menu</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public BancaSeguros.Entidades.Seguridad.AdministracionControlDual DataReaderAdmonControlDual(IDataReader reader)
        {
            BancaSeguros.Entidades.Seguridad.AdministracionControlDual resultado = new Entidades.Seguridad.AdministracionControlDual();
            resultado.IdControlDual = reader.IsDBNull(reader.GetOrdinal("idControlDual")) ? 0 : (int)reader["idControlDual"];
            resultado.IdMenu = reader.IsDBNull(reader.GetOrdinal("id_Menu")) ? 0 : (int)reader["id_Menu"];
            resultado.IdRol = reader.IsDBNull(reader.GetOrdinal("idRol")) ? 0 : (int)reader["idRol"];
            resultado.NombreRol = reader.IsDBNull(reader.GetOrdinal("nombre")) ? string.Empty : (string)reader["nombre"];
            resultado.Requiere = reader.IsDBNull(reader.GetOrdinal("Requiere")) ? false : (bool)reader["Requiere"];
            resultado.Autoriza = reader.IsDBNull(reader.GetOrdinal("Autoriza")) ? false : (bool)reader["Autoriza"];
            return resultado;
 
 
        }
    }
}
