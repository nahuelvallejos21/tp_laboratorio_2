using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Instancia el formulario con todas sus ocurrencias
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            this.Text = "Calculadora de Nahuel Vallejos del curso 2°A";

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
            this.cmbOperador.SelectedItem = "/";
            this.cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;
            this.lblResultado.AutoSize = true; ;
            this.cmbOperador.IntegralHeight = true;

            this.lblResultado.Font = new Font("familyName", 21.2f);
            this.cmbOperador.Font = new Font("familyName", 25.2f);
            this.txtNumero1.Font = new Font("familyName", 21.2f);
            this.txtNumero2.Font = new Font("familyName", 21.2f);
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Método que opera 2 Numeros
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            return Calculadora.Operar(num1, num2, operador);
        }
        /// <summary>
        /// Realiza la operacion entre 2 Numeros y lo muestra en el lblRespuesta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Operar_Click_1(object sender, EventArgs e)
        {
            double resultado = this.Operar(this.txtNumero1.Text, this.txtNumero2.Text, (string)(this.cmbOperador.SelectedItem));
            this.lblResultado.ForeColor = Color.Black;
            this.lblResultado.Text = resultado.ToString();
        }
        /// <summary>
        /// Convierte un decimal en binario y lo muestra en el lblRespuesta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConvertirABinario_Click(object sender, EventArgs e)
        {
           this.lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
        }
        /// <summary>
        /// Convierte un binario en decimal y lo muestra en el lblRespuesta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
        }
        /// <summary>
        /// Limpia los distintos textsBoxs y el label, para el reingreso de nuevos datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = "";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "/";
        }

        
    }
}
