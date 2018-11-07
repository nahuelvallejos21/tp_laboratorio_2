namespace MiCalculadora
{
    partial class FormCalculadora
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_ConvertirABinario = new System.Windows.Forms.Button();
            this.btn_ConvertirADecimal = new System.Windows.Forms.Button();
            this.txtNumero1 = new System.Windows.Forms.TextBox();
            this.cmbOperador = new System.Windows.Forms.ComboBox();
            this.txtNumero2 = new System.Windows.Forms.TextBox();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btn_Operar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Location = new System.Drawing.Point(427, 155);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(166, 44);
            this.btn_Cerrar.TabIndex = 0;
            this.btn_Cerrar.Text = "Cerrar";
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Location = new System.Drawing.Point(224, 155);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(181, 44);
            this.btn_Limpiar.TabIndex = 2;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_ConvertirABinario
            // 
            this.btn_ConvertirABinario.Location = new System.Drawing.Point(19, 222);
            this.btn_ConvertirABinario.Name = "btn_ConvertirABinario";
            this.btn_ConvertirABinario.Size = new System.Drawing.Size(274, 38);
            this.btn_ConvertirABinario.TabIndex = 3;
            this.btn_ConvertirABinario.Text = "Convertir a Binario";
            this.btn_ConvertirABinario.UseVisualStyleBackColor = true;
            this.btn_ConvertirABinario.Click += new System.EventHandler(this.btn_ConvertirABinario_Click);
            // 
            // btn_ConvertirADecimal
            // 
            this.btn_ConvertirADecimal.Location = new System.Drawing.Point(320, 222);
            this.btn_ConvertirADecimal.Name = "btn_ConvertirADecimal";
            this.btn_ConvertirADecimal.Size = new System.Drawing.Size(273, 38);
            this.btn_ConvertirADecimal.TabIndex = 4;
            this.btn_ConvertirADecimal.Text = "Convertir a Decimal";
            this.btn_ConvertirADecimal.UseVisualStyleBackColor = true;
            this.btn_ConvertirADecimal.Click += new System.EventHandler(this.btn_ConvertirADecimal_Click);
            // 
            // txtNumero1
            // 
            this.txtNumero1.Location = new System.Drawing.Point(19, 68);
            this.txtNumero1.Multiline = true;
            this.txtNumero1.Name = "txtNumero1";
            this.txtNumero1.Size = new System.Drawing.Size(181, 53);
            this.txtNumero1.TabIndex = 5;
            // 
            // cmbOperador
            // 
            this.cmbOperador.FormattingEnabled = true;
            this.cmbOperador.Location = new System.Drawing.Point(225, 74);
            this.cmbOperador.Name = "cmbOperador";
            this.cmbOperador.Size = new System.Drawing.Size(180, 24);
            this.cmbOperador.TabIndex = 6;
            // 
            // txtNumero2
            // 
            this.txtNumero2.Location = new System.Drawing.Point(427, 68);
            this.txtNumero2.Multiline = true;
            this.txtNumero2.Name = "txtNumero2";
            this.txtNumero2.Size = new System.Drawing.Size(166, 53);
            this.txtNumero2.TabIndex = 7;
            // 
            // lblResultado
            // 
            this.lblResultado.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblResultado.Location = new System.Drawing.Point(16, 11);
            this.lblResultado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(596, 54);
            this.lblResultado.TabIndex = 8;
            this.lblResultado.Text = "Resultado";
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Operar
            // 
            this.btn_Operar.Location = new System.Drawing.Point(19, 155);
            this.btn_Operar.Name = "btn_Operar";
            this.btn_Operar.Size = new System.Drawing.Size(181, 44);
            this.btn_Operar.TabIndex = 9;
            this.btn_Operar.Text = "Operar";
            this.btn_Operar.UseVisualStyleBackColor = true;
            this.btn_Operar.Click += new System.EventHandler(this.btn_Operar_Click_1);
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 297);
            this.Controls.Add(this.btn_Operar);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.txtNumero2);
            this.Controls.Add(this.cmbOperador);
            this.Controls.Add(this.txtNumero1);
            this.Controls.Add(this.btn_ConvertirADecimal);
            this.Controls.Add(this.btn_ConvertirABinario);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.btn_Cerrar);
            this.Name = "FormCalculadora";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_ConvertirABinario;
        private System.Windows.Forms.Button btn_ConvertirADecimal;
        private System.Windows.Forms.TextBox txtNumero1;
        private System.Windows.Forms.ComboBox cmbOperador;
        private System.Windows.Forms.TextBox txtNumero2;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Button btn_Operar;
    }
}

