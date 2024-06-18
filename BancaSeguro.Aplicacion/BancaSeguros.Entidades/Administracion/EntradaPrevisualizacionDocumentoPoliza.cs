//-----------------------------------------------------------------------
// <copyright file="EntradaPrevisualizacionDocumentoPoliza.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Administracion
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Entity entry review document policy
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 13/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class EntradaPrevisualizacionDocumentoPoliza
    {
        /// <summary>
        /// The template
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private byte[] plantilla;

        /// <summary>
        /// The data XML
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string datosXML;

        /// <summary>
        /// The fields
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string campos;

        /// <summary>
        /// The route archive
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string rutaArchivo;

        /// <summary>
        /// Gets or sets the template.
        /// </summary>
        /// <value>
        /// The template.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public byte[] Plantilla
        {
            get { return this.plantilla; }
            set { this.plantilla = value; }
        }

        /// <summary>
        /// Gets or sets the data XML.
        /// </summary>
        /// <value>
        /// The data XML.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string DatosXML
        {
            get { return this.datosXML; }
            set { this.datosXML = value; }
        }

        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Campos
        {
            get { return this.campos; }
            set { this.campos = value; }
        }

        /// <summary>
        /// Gets or sets the route archive.
        /// </summary>
        /// <value>
        /// The route archive.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string RutaArchivo
        {
            get { return this.rutaArchivo; }
            set { this.rutaArchivo = value; }
        }
    }
}
