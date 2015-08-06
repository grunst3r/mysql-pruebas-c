namespace Nicsmedia
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.datos = new System.Windows.Forms.Label();
            this.usuarios = new System.Windows.Forms.ComboBox();
            this.reportes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // datos
            // 
            this.datos.AutoSize = true;
            this.datos.Location = new System.Drawing.Point(142, 28);
            this.datos.Name = "datos";
            this.datos.Size = new System.Drawing.Size(44, 13);
            this.datos.TabIndex = 0;
            this.datos.Text = "MYSQL";
            // 
            // usuarios
            // 
            this.usuarios.FormattingEnabled = true;
            this.usuarios.Location = new System.Drawing.Point(15, 25);
            this.usuarios.Name = "usuarios";
            this.usuarios.Size = new System.Drawing.Size(121, 21);
            this.usuarios.TabIndex = 1;
            this.usuarios.SelectedIndexChanged += new System.EventHandler(this.usuarios_SelectedIndexChanged);
            // 
            // reportes
            // 
            this.reportes.FormattingEnabled = true;
            this.reportes.Location = new System.Drawing.Point(15, 53);
            this.reportes.Name = "reportes";
            this.reportes.Size = new System.Drawing.Size(257, 199);
            this.reportes.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.reportes);
            this.Controls.Add(this.usuarios);
            this.Controls.Add(this.datos);
            this.Name = "Form1";
            this.Text = "Nicsmedia";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label datos;
        private System.Windows.Forms.ComboBox usuarios;
        private System.Windows.Forms.ListBox reportes;
    }
}

