using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

////
///unidades de pesos en kg
///unidades de longitudes en cm y cm^2
namespace tp_final.Properties
{
    public class Class_Vehiculo
    {
        public readonly uint ID;

        protected float Ancho_Max;
        protected float Largo_Max;
        protected float Alto_Max;
        protected int Capacidad_Tanque;
        protected int Consumo;
       
        public int Peso_Max { get; set; }
        public int Vol_Max { get; set; }
        public int Capacidad_Tanque { get; }
        public int Consumo_Tanque { get; }



        public static uint maxID = 0;

        public cVehiculo(float Ancho_Max, float Largo_Max, float Alto_Max, int Peso_Max, int Capacidad_Tanque)
        {
            ID = maxID++;
            
            this.Capacidad_Tanque = Capacidad_Tanque;
            this.Ancho_Max = anchoMax;
            this.Largo_Max = largoMax;
            this.Alto_Max = altoMax;
            this.Peso_Max = pesoMax;
            this.Vol_Max = Convert.ToInt32(Alto_Max * Largo_Max * Ancho_Max);
            
        }
    }
}
