//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Sincronizacion
{
    using System.ServiceProcess;

    /// <summary>
    /// Main program
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main()
        {
            ServiceBase[] servicesToRun;
            servicesToRun = new ServiceBase[] 
            { 
                new Sincronizacion() 
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
