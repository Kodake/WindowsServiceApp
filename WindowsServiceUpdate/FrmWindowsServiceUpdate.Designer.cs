
namespace WindowsServiceUpdate
{
    partial class FrmWindowsServiceUpdate
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDetener = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDetener
            // 
            this.btnDetener.Location = new System.Drawing.Point(108, 12);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(90, 50);
            this.btnDetener.TabIndex = 3;
            this.btnDetener.Text = "DETENER";
            this.btnDetener.UseVisualStyleBackColor = true;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(12, 12);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(90, 50);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "INICIAR";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // FrmWindowsServiceUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 136);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.btnIniciar);
            this.Name = "FrmWindowsServiceUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmWindowsServiceUpdate";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.Button btnIniciar;
    }
}