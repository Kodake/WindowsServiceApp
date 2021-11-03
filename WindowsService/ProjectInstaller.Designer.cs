
namespace WindowsService
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
            this.ProcessInstallerWindowsServiceApp = new System.ServiceProcess.ServiceProcessInstaller();
            this.InstallerWindowsServiceApp = new System.ServiceProcess.ServiceInstaller();
            // 
            // ProcessInstallerWindowsServiceApp
            // 
            this.ProcessInstallerWindowsServiceApp.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.ProcessInstallerWindowsServiceApp.Password = null;
            this.ProcessInstallerWindowsServiceApp.Username = null;
            // 
            // InstallerWindowsServiceApp
            // 
            this.InstallerWindowsServiceApp.ServiceName = "WindowsServiceApp";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.ProcessInstallerWindowsServiceApp,
            this.InstallerWindowsServiceApp});

        }

        #endregion
        public System.ServiceProcess.ServiceInstaller InstallerWindowsServiceApp;
        public System.ServiceProcess.ServiceProcessInstaller ProcessInstallerWindowsServiceApp;
    }
}