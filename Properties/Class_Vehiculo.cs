using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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
        protected double DistanciaTot;

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
            this.ID = Max_ID++;
            this.Consumo_Tanque = Consumo_Tanque;
            this.Capacidad_Tanque = Capacidad_Tanque;
            this.Ancho_Max = Ancho_Max;
            this.Largo_Max = Largo_Max;
            this.Alto_Max = Alto_Max;
            this.Peso_Max = Peso_Max;
            this.Vol_Max = Convert.ToInt32(Alto_Max * Largo_Max * Ancho_Max);
            this.Pedidos = new List<Pedido>();
            this.Recorrido = new Queue<string>();
            this.Coordenadas = new Dictionary<string, (string, string)>();
            this.Coordenadas = CargarCoordenadas();
            this.DistanciaTot = 0;
        }
        public void setLista(List<Pedido> Aux)
        {
            this.Pedidos = Aux;
        }

        public void MostrarLista()
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
            double min = 0;
            string aux = "";
            float autonomia= CalculoAutonomia();
            if(Nodos.Count != 0)
            {
                for (int i = 0; i < Nodos.Count; i++)
                {
                    if (DistanciaKm(Inicial, Nodos[i]) < min || i == 0)
                    {
                        min = DistanciaKm(Inicial, Nodos[i]);
                        aux = Nodos[i];
                    }
                }
            }
            else
            {
                DistanciaTot += DistanciaKm(Inicial, "Liniers");
            }
            DistanciaTot += min;
            if (DistanciaTot > autonomia)
            {
                Console.WriteLine("En el barrio: {0} se debera cargar combustible", Inicial);
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
            string ubicacionArchivo = "D:\\Repos\\TP_Final_Grupo_2\\Coordenadas.csv";
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
        public double DistanciaKm(string Origen, string Destino)
        {

            
            double PI = 3.1416;
            (string v1, string v2) = Coordenadas[Origen];
            float LatOri = float.Parse(v1, CultureInfo.InvariantCulture.NumberFormat);
            float LongOri = float.Parse(v2, CultureInfo.InvariantCulture.NumberFormat);
            (string v3, string v4) = Coordenadas[Destino];
            float LatFin = float.Parse(v3, CultureInfo.InvariantCulture.NumberFormat);
            float LongFin = float.Parse(v4, CultureInfo.InvariantCulture.NumberFormat);

            
            float RadTierra = 6378.0F;

            double difLatitud = (LatFin - LatOri) * (PI/180);
            double difLongitud = (LongFin - LongOri) * (PI / 180);


            double a = Math.Sin(difLatitud / 2) * Math.Sin(difLatitud / 2) +
                      Math.Cos(LatOri * (PI / 180)) *
                      Math.Cos(LatFin * (PI / 180)) *
                      Math.Sin(difLongitud / 2) * Math.Sin(difLongitud / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return RadTierra * c;
            
        }

        public float CalculoAutonomia()
        {
            float autonomia = (Capacidad_Tanque * 100) / Consumo_Tanque;

            return autonomia;
        }
    }
}