using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Entidades
{
    public class Correo:IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        
        /// <summary>
        /// Propiedad de lectura y escritura del atributo paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }
        /// <summary>
        /// Constructor sin parametros que instancia los atributos
        /// </summary>
        public Correo()
        {
            this.Paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        
        /// <summary>
        /// Sobrecarga del operador +, permitira la suma ente un obj Correo y un obj Paquete
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c,Paquete p)
        {
            int flag = 0;
            foreach(Paquete item in c.Paquetes)
            {
                if(item == p)
                {
                    flag = 1;
                    throw new TrackingIdRepetidoException("ERROR!...paquete repetido");
                }
            }
            if(flag == 0)
            {
                c.Paquetes.Add(p);
                Thread hilo = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(hilo);
                hilo.Start();
            }
            return c;
        }
        /// <summary>
        /// Retorna todos los datos de la lista de paquetes
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> list = (List<Paquete>)((Correo)elementos).paquetes;
            string cadena = "";
            foreach (Paquete item in list)
            {
                cadena += string.Format("{0} para {1} ({2})", item.TrackingID, item.DireccionEntrega, item.Estado.ToString());
                cadena += "\r\n";
            }
            return cadena;
        }
        /// <summary>
        /// Cierra todos los hilos en ejecucion
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread item in this.mockPaquetes)
            {
                item.Abort();
            }
        }

        
    }
}
