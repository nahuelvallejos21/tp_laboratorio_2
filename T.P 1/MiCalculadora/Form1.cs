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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "Calculadora de Nahuel Vallejos del curso 2°A";

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.comboBox1.Items.Add("+");
            this.comboBox1.Items.Add("-");
            this.comboBox1.Items.Add("*");
            this.comboBox1.Items.Add("/");
            this.comboBox1.SelectedItem = "/";
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.label1.AutoSize = false;
            this.comboBox1.IntegralHeight = true;

            this.label1.Font = new Font("familyName", 21.2f);
            this.comboBox1.Font = new Font("familyName", 25.2f);
            this.textBox1.Font = new Font("familyName", 21.2f);
            this.textBox2.Font = new Font("familyName", 21.2f);





        }

        //Boton de operacion de numeros
        private void button1_Click(object sender, EventArgs e)
        {
            double resultado = this.Operar(this.textBox1.Text, this.textBox2.Text, (string)(this.comboBox1.SelectedItem));
            this.label1.ForeColor = Color.Black;
            this.label1.Text = resultado.ToString();
        }

        //Boton Limpiar
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox || item is ComboBox || item is Label)
                {
                    item.Visible = false;
                }
            }
        }
        //Boton de cierre
        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        //Boton de conversor DecimalABinario
        private void button4_Click(object sender, EventArgs e)
        {
            string numB = Numero.DecimalBinario(this.label1.Text);
            this.label1.ForeColor = Color.Black;
            this.label1.Text = numB;
        }
        //Boton de conversor BinarioADecimal
        private void button5_Click(object sender, EventArgs e)
        {
            string numD = Numero.BinarioDecimal(this.label1.Text);
            this.label1.ForeColor = Color.Black;
            this.label1.Text = numD;

        }
        private void label1_Click(object sender, EventArgs e)
        {
            

        }
        //Funcion Operar
        private double Operar(string numero1, string numero2, string operador)
        {
                Numero num1 = new Numero(numero1);
                Numero num2 = new Numero(numero2);
                return Calculadora.Operar(num1, num2, operador);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
