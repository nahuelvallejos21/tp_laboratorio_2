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
using System.Threading;
namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        Correo correo;
        /// <summary>
        /// Instancia el formulario
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            this.mtxtTrackingID.Mask = "000-000-0000";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Correo UTN por Nahuel Vallejos 2°A";
            this.correo = new Correo();
        }
        /// <summary>
        /// Agrega los paquetes al atributo correo y va informando del evento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            paquete.InformarEstado += this.paq_InformaEstado;

            try
            {
                this.correo += paquete;
            }
            catch (TrackingIdRepetidoException t)
            {
                MessageBox.Show(t.Message);

            }
            this.ActualizarEstados();

        }
        /// <summary>
        /// Actualiza los estados del paquete sobre el ListBox
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete item in this.correo.Paquetes)
            {
                if(item.Estado == Paquete.EEstado.Ingresado)
                {
                    this.lstEstadoIngresado.Items.Add(item);
                }
                else if(item.Estado == Paquete.EEstado.EnViaje)
                {
                    
                    this.lstEstadoEnViaje.Items.Add(item);
                }
                else if(item.Estado == Paquete.EEstado.Entregado)
                {
                    this.lstEstadoEntregado.Items.Add(item);
                    
                }
            }
        }
        /// <summary>
        /// Informa el estado del determinado paquete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
                
            }
            
        }
        /// <summary>
        /// Cierra todos los hilos en ejecucion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender,FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Muestra todos los paquetes en la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Muestra informacion del obj Paquete
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T>elemento)
        {
            if(elemento != null)
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    elemento.MostrarDatos(elemento).Guardar("salida.txt");
                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message);
                }
                
            }
        }
        /// <summary>
        /// Muestra la informacion de un solo paquete que esta en estado de "Entregado"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        
    }
}
