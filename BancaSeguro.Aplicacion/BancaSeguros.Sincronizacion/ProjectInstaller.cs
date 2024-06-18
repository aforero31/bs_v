//-----------------------------------------------------------------------
// <copyright file="ProjectInstaller.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Sincronizacion
{
    using System.ComponentModel;

    /// <summary>
    /// class installer
    /// </summary>
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        /// <summary>
        /// constructor installer
        /// </summary>
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}
