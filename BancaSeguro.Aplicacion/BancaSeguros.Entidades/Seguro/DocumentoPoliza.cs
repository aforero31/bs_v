//-----------------------------------------------------------------------
// <copyright file="DocumentoPoliza.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Seguro
{
    using System;

    /// <summary>
    /// Entity Document Policy
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 03/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class DocumentoPoliza
    {
        /// <summary>
        /// Gets or sets the identifier secure.
        /// </summary>
        /// <value>
        /// The identifier secure.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdSeguro { get; set; }

        /// <summary>
        /// Gets or sets the template.
        /// </summary>
        /// <value>
        /// The template.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public byte[] Plantilla { get; set; }

        /// <summary>
        /// Gets or sets the identifier document policy.
        /// </summary>
        /// <value>
        /// The identifier document policy.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdDocumentoPoliza { get; set; }

        /// <summary>
        /// Gets or sets the version document.
        /// </summary>
        /// <value>
        /// The version document.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string VersionDocumento { get; set; }

        /// <summary>
        /// Gets or sets the date creation.
        /// </summary>
        /// <value>
        /// The date creation.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Gets or sets the user creation.
        /// </summary>
        /// <value>
        /// The user creation.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string UsuarioCreacion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DocumentoPoliza"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Activa { get; set; }

        /// <summary>
        /// Gets or sets the name archive.
        /// </summary>
        /// <value>
        /// The name archive.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NombreArchivo { get; set; }

        /// <summary>
        /// Gets or sets the fields template.
        /// </summary>
        /// <value>
        /// The fields template.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string CamposPlantilla { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DocumentoPoliza"/> is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if deleted; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Eliminado { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DocumentoPoliza"/> is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if deleted; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Usuario { get; set; }
        /// <summary>
        /// Gets or sets the template XML.
        /// </summary>
        /// <value>
        /// The template XML.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public System.Xml.Linq.XElement PlantillaXml { get; set; }
    }
}