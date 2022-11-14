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

        public Queue<string> Recorrido { get; set; }

        public static uint Max_ID = 0;

        public Dictionary<string, (string, string)> Coordenadas { get; }
        
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
            this.Recorrido = new Queue<string>();
            Coordenadas = CargarCoordenadas();
        }
        
        public void Recorrido()
        {
            float min, DistanciaTot = 0;
            for(int i = 0; i < Pedidos.Count - 1; i++)
            {
                for(int j = 0; j < Pedidos.Count - 1; j++)
                {
                    if(DistanciaKm() < min || i == 0)
                    {
                        min = DistanciaKm(coordenadas[recorrido[k]], lista - getlista()[i]);
                        int k = 1;
                        recorrido[k] = aux->listaProd->getLista()[i];
                        k++;
                        aux->listaProd->Eliminar(i);
                    }
                }
                DistanciaTot += min;
            }

        }

        public static float DistanciaKm()
        {
            float RadTierra = 6378.0F;

        //    var difLatitud = (posDestino.Latitud – posOrigen.Latitud).EnRadianes();
        //    var difLongitud = (posDestino.Longitud - posOrigen.Longitud).EnRadianes();


            var a = Math.Sin(difLatitud / 2).AlCuadrado() +
                      Math.Cos(posOrigen.Latitud.EnRadianes()) *
                      Math.Cos(posDestino.Latitud.EnRadianes()) *
                      Math.Sin(difLongitud / 2).AlCuadrado();
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 – a));
            return RadTierra * c;
        }
    }
}
