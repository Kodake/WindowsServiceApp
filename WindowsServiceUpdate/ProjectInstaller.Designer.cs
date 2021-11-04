
namespace WindowsServiceUpdate
{
    partial class ProjectInstaller
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
            this.ServiceProcess2 = new System.ServiceProcess.ServiceProcessInstaller();
            this.WindowsServiceApp2 = new System.ServiceProcess.ServiceInstaller();
            // 
            // ServiceProcess2
            // 
            this.ServiceProcess2.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.ServiceProcess2.Password = null;
            this.ServiceProcess2.Username = null;
            // 
            // WindowsServiceApp2
            // 
            this.WindowsServiceApp2.ServiceName = "WindowsServiceApp2";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.WindowsServiceApp2,
            this.ServiceProcess2});

        }

        #endregion
        public System.ServiceProcess.ServiceProcessInstaller ServiceProcess2;
        public System.ServiceProcess.ServiceInstaller WindowsServiceApp2;
    }
}