﻿
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
            this.ServiceProcess1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.WindowsServiceApp1 = new System.ServiceProcess.ServiceInstaller();
            // 
            // ServiceProcess1
            // 
            this.ServiceProcess1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.ServiceProcess1.Password = null;
            this.ServiceProcess1.Username = null;
            // 
            // WindowsServiceApp1
            // 
            this.WindowsServiceApp1.ServiceName = "WindowsServiceApp1";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.WindowsServiceApp1,
            this.ServiceProcess1});

        }

        #endregion
        public System.ServiceProcess.ServiceInstaller WindowsServiceApp1;
        public System.ServiceProcess.ServiceProcessInstaller ServiceProcess1;
    }
}