namespace BancaSeguros.Sincronizacion
{
    partial class Sincronizacion
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tmrServicio = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.tmrServicio)).BeginInit();
            // 
            // tmrServicio
            // 
            this.tmrServicio.Enabled = true;
            this.tmrServicio.Elapsed += new System.Timers.ElapsedEventHandler(this.Servicio_Elapsed);
            // 
            // Sincronizacion
            // 
            this.CanPauseAndContinue = true;
            this.ServiceName = "UT-BancaSeguros.Sincronizacion";
            ((System.ComponentModel.ISupportInitialize)(this.tmrServicio)).EndInit();

        }

        #endregion

        internal System.Timers.Timer tmrServicio;

    }
}
