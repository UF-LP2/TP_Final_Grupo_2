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
        protected float DistanciaTot;

        public int Peso_Max { get; set; }
        public int Vol_Max { get; set; }
        public int Capacidad_Tanque { get; }
        public float Consumo_Tanque { get; }

        public List<Pedido> Pedidos { get; set; }

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
            this.Pedidos = new List<Pedido>();
            this.Recorrido = new Queue<string>();
            Coordenadas = CargarCoordenadas();
            DistanciaTot = 0;
        }
        public void setLista(List<Pedido> Aux)
        {
            this.Pedidos = Aux;
        }

        public void setVol_Max(int volumen)
        {
            this.Vol_Max = volumen;
        }
        public void MostrarAlgo()
        {
            for (int i = 0; Recorrido.Count != 0; i++)
            {
                Console.Write(Recorrido.Dequeue());
                Console.WriteLine();
            }
        }
        public void CargarRecorrido()
        {
            List<string> Nodos = new List<string>();
            Nodos = FiltrarRepetidos();
            string Inicial = "Liniers";
            while (Nodos.Count > 0)
            {
                Recorrido.Enqueue(Inicial);
                Nodos.Remove(Inicial);
                Inicial = NodosMasCercano(Inicial, Nodos);
            }
            Recorrido.Enqueue("Liniers");
            DistanciaTot += DistanciaKm(Inicial, "Liniers");
            float autonomia = CalculoAutonomia();

            if(DistanciaTot > autonomia)
            {
                Console.WriteLine("El recorrido es muy largo debera cargar nafta para completarlo");
            }
            else
                Console.WriteLine("El recorrido se completara sin problemas");
        }
        public string NodosMasCercano(string Inicial, List<string> Nodos)
        {
            float min = 0;
            string aux = "error";
            float autonomia= CalculoAutonomia();

            for (int i = 0; i < Nodos.Count; i++)
            {
                if (DistanciaKm(Inicial, Nodos[i]) < min || i == 0)
                {
                    min = DistanciaKm(Inicial, Nodos[i]);
                    aux = Nodos[i];
                }
            }
            DistanciaTot += min;
            if(DistanciaTot > autonomia)
            {
                Console.WriteLine("En el barrio: {0} se debera cargar combustible",aux);
            }
            return aux;
        }
        public List<string> FiltrarRepetidos()
        {
            HashSet<string> Aux_No_Repetidos = new HashSet<string>();
            for (int i = 0; i < Pedidos.Count; i++)
            {
                Aux_No_Repetidos.Add(Pedidos[i].barrio);//si esta repetido no te lo agrega, funciona como un dictionary las claves no se repiten
            }
            return Aux_No_Repetidos.ToList<string>();
        }

        public Dictionary<string, (string, string)> CargarCoordenadas()
        {
            Dictionary<string, (string, string)> Coordenadas = new Dictionary<string, (string, string)>();
            string ubicacionArchivo = "C:\\Users\\Dolo\\source\\repos\\TP_Final_Grupo_2--\\Coordenadas.csv";
            System.IO.StreamReader archivo = new System.IO.StreamReader(ubicacionArchivo);
            string separador = ",";
            string linea;

            // Si el archivo no tiene encabezado, elimina la siguiente línea
            archivo.ReadLine(); // Leer la primera línea pero descartarla porque es el encabezado
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(separador);
                Coordenadas.Add(fila[0], (fila[1], fila[2]));
            }
            return Coordenadas;
        }
        public static float DistanciaKm(string Origen, string Destino)
        {

            var random = new Random();

            var value = random.Next(1, 1000);
            /*float RadTierra = 6378.0F;

            var difLatitud = (posDestino.Latitud – posOrigen.Latitud).EnRadianes();
            var difLongitud = (posDestino.Longitud - posOrigen.Longitud).EnRadianes();


            var a = Math.Sin(difLatitud / 2).AlCuadrado() +
                      Math.Cos(posOrigen.Latitud.EnRadianes()) *
                      Math.Cos(posDestino.Latitud.EnRadianes()) *
                      Math.Sin(difLongitud / 2).AlCuadrado();
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 – a));
            return RadTierra * c;*/
            return value;
        }

        public float CalculoAutonomia()
        {
            float autonomia = (Capacidad_Tanque * 100) / Consumo_Tanque;

            return autonomia;
        }
    }
}