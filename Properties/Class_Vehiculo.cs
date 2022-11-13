using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

////
///unidades de pesos en kg
///unidades de longitudes en cm y cm^2
///


namespace tp_final.Properties
{
    internal class Class_Vehiculo
    {
        //todo declarar las dos listas de longitud y latitud
        //todo hacer ambos algoritmos aca y que el recorrido se vaya guardando en una pila
        //todo ver como hacer el algoritmo dinamico
        public readonly uint ID;

        protected float Ancho_Max;
        protected float Largo_Max;
        protected float Alto_Max;
        
       
        public int Peso_Max { get; set; }
        public int Vol_Max { get; set; }
        public int Capacidad_Tanque { get; }
        public float Consumo_Tanque { get; }

        protected Stack<eBarrios> = new Stack<eBarrios>();


        

        public static uint Max_ID = 0;

        public Class_Vehiculo(float Ancho_Max, float Largo_Max, float Alto_Max, int Peso_Max, int Capacidad_Tanque, float Consumo_Tanque)
        {
            ID = Max_ID++;
            this.Consumo_Tanque = Consumo_Tanque;
            this.Capacidad_Tanque = Capacidad_Tanque;
            this.Ancho_Max = Ancho_Max;
            this.Largo_Max = Largo_Max;
            this.Alto_Max = Alto_Max;
            this.Peso_Max = Peso_Max;
            this.Vol_Max = Convert.ToInt32(Alto_Max * Largo_Max * Ancho_Max);
            
        }

        public void Recorrido()
        {

        }

    }
}
