using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

////
///unidades de pesos en kg
///unidades de longitudes en cm y cm^2
///


namespace tp_final.Properties
{
    public class Class_Vehiculo
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

        public List<Class_Pedido> Pedidos { get; set; }

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
            this.Pedidos = new List<Class_Pedido>();
        }

        public void recorrido()
        {
            float min, distanciatot = 0;
            for (int i = 0; i < pedidos.count - 1; i++)
            {
                for (int j = 0; j < pedidos.count - 1; j++)
                {
                    if (distanciakm() < min || i == 0)
                    {
                        min = distanciakm(coordenadas[recorrido[k]], lista - getlista()[i]);
                        int k = 1;
                        recorrido[k] = aux->listaprod->getlista()[i];
                        k++;
                        aux->listaprod->eliminar(i);
                    }
                }
                distanciatot += min;
            }

        }

        public static float distanciakm()
        {
            float radtierra = 6378.0f;

            var diflatitud = (posdestino.latitud – posorigen.latitud).enradianes();
            var diflongitud = (posdestino.longitud - posorigen.longitud).enradianes();


            var a = math.sin(diflatitud / 2).alcuadrado() +
                      math.cos(posorigen.latitud.enradianes()) *
                      math.cos(posdestino.latitud.enradianes()) *
                      math.sin(diflongitud / 2).alcuadrado();
            var c = 2 * math.atan2(math.sqrt(a), math.sqrt(1 – a));
            return radtierra * c;
        }
    }
}
