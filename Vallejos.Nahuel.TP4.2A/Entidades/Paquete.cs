using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        private string dirreccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado InformarEstado;
        
        public enum EEstado
        {
            Ingresado,EnViaje,Entregado
        }
        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura del atributo DireccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get { return this.dirreccionEntrega; }
            set { this.dirreccionEntrega = value; }
        }
        /// <summary>
        ///Propiedad de lectura y escritura del atributo estado
        /// </summary>
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo trackingID
        /// </summary>
        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }
        #endregion
        /// <summary>
        /// Constructor parametrizado que instancia el obj Paquete
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega,string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;

        }
        /// <summary>
        /// Retorna los datos del paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0}  para  {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }
        /// <summary>
        /// Sobrecarga del operador ==, un Paquete sera igual a otro Paquete si tienen el mismo trackingID
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1,Paquete p2)
        {
            bool retorno = false;
            if(p1.TrackingID == p2.TrackingID)
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga del operador != ,un Paquete sera distinto a otro Paquete si tienen distinto trackingID
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1,Paquete p2)
        {
            return !(p1 == p2);
        }
        /// <summary>
        /// Metodo que va cambiando el estado del Paquete
        /// </summary>
        public void MockCicloDeVida()
        {
            Thread.Sleep(4000);
            this.Estado = EEstado.EnViaje;
            this.InformarEstado(this,EventArgs.Empty);
            Thread.Sleep(4000);
            this.Estado = EEstado.Entregado;
            this.InformarEstado(this,EventArgs.Empty);

            try
            {
              PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
           

        }
        /// <summary>
        /// Muestra todos los datos del paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
           return this.MostrarDatos(this);
        }

        public delegate void DelegadoEstado(Paquete p ,EventArgs ea);


    }
    
}
