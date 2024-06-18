//-----------------------------------------------------------------------
// <copyright file="ServicioSincronizacion.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.ServiciosWCF.Sincronizacion
{
    using Aplicacion.Cobis;
    using Aplicacion.Sincronizacion;
    using Entidades.General;
    using Repositorio.Administracion;
    using Repositorio.Sincronizacion;
    using BancaSeguros.Aplicacion;

    /// <summary>
    /// Service sync up
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 09/08/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.ServiciosWCF.Sincronizacion.IServicioSincronizacion" />
    public class ServicioSincronizacion : IServicioSincronizacion
    {
        /// <summary>
        /// The management sync up
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 09/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionSincronizacion gestionSincronizacion;

        /// <summary>
        /// The management intarface transaction
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionTransaccion gestionTransaccion;

        /// <summary>
        /// The management intarface catalogs
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionCatalogos gestionCatalogos;

        /// <summary>
        /// interface repository
        /// </summary>
        private IRepositorioDiaHabil repositorioDiaHabil;

        /// <summary>
        /// interface repository
        /// </summary>
        private IRepositorioSincronizacion repositorioSincronizacion;

        /// <summary>
        /// The management intarface oficinas
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 08/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionSincronizacion gestionOficinas;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServicioSincronizacion"/> class.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 09/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public ServicioSincronizacion()
        {
            this.gestionTransaccion = new GestionTransaccion();
            this.gestionCatalogos = new GestionCatalogos();
            this.repositorioDiaHabil = new RepositorioDiaHabil(Global.nombreConexionTeradata);
            this.repositorioSincronizacion = new RepositorioSincronizacion(Global.nombreConexionTeradata);

            this.gestionSincronizacion = new GestionSincronizacion(this.repositorioDiaHabil, this.repositorioSincronizacion, this.gestionTransaccion, this.gestionCatalogos);

            //this.gestionOficinas = new Entidades().Catalogo().ListaOficinas();
        }

        /// <summary>
        /// sync up catalogs.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 09/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado SincronizarCatalogos()
        {
            return this.gestionSincronizacion.SincronizarCatalogos();
        }

        /// <summary>
        /// sync up oficinas.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 08/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado SincronizarOficinas()
        {
            Resultado Resp = new Resultado();
            Resp = new GestionSincronizacion(null,null,null,null).SincronizarOficinas();
            return Resp;
        }

    }
}
