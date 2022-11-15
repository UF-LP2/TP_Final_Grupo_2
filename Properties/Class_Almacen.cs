using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*enum eBarrios
{
    Agronomia, Almagro, Almirante_Brown, Balbastro, Balvanera, Barracas, Barrio_Norte,
    Belgrano, Boca, Boedo, Bonorino, Buenos_Aires, Caballito, Cafferata, Calaza, Centro, Chacarita,
    Ciudad_Autonoma_de_Buenos_Aires, Coghlan, Colegiales, Colelache, Colhue_Huapi, Comandante_L_Piedrabuena,
    Congreso, Constitucion, Dolavon, Dos_Pozos, El_Maiten, El_Sombrero, Emilio_Mitre, Epuyen, Escalante,
    Facundo, Flores, Floresta, Gan_Gan, General_Jose_de_San_Martin, Isla_Demarchi, Lacarra, Liniers,
    Los_Perales, Luis_J_Garcia, Marcelo_Torcuato_de_Alvear, Mataderos, Monte_Castro, Montserrat, Nazca,
    Nueva_Chicago, Nueva_Pompeya, Nunez, Once, Palermo, Parque_Chacabuco, Parque_Chas, Parque_Patricios,
    Paternal, Presidente_Rivadavia, Presidente_Roque_Saenz_Pena, Primera_Junta, Puerto_Madero, Puerto_Nuevo,
    Pueyrredon, Ramon_L_Falcon, Recoleta, Retiro, Saavedra, San_Cristobal, San_Telmo, Simon_Bolivar, Tellier,
    Varela, Velez_Sarsfield, Versailles, Villa_Crespo, Villa_del_Parque, Villa_Devoto, Villa_General_Mitre,
    Villa_La_madrid, Villa_Lugano, Villa_Luro, Villa_Ortuzar, Villa_Real, Villa_Riachuelo, Villa_Santa_Rita,
    Villa_Soldati, Villa_Urquiza
}*/
namespace tp_final.Properties
{
    public class Class_Almacen
    {
        List<Pedido> lista_pedidos { get; }
        public Class_Almacen()
        {
            var csv_ = new csvfiles._csv();
            lista_pedidos = csv_.read_csv();
            InicializarValor();
        }

        public void InicializarValor()
        {
            for (int i = 0; i < lista_pedidos.Count; i++)
            {
                if (lista_pedidos[i].prioridad == "express")
                {
                    lista_pedidos[i].valor = 3;
                } else if (lista_pedidos[i].prioridad == "normal")
                {
                    lista_pedidos[i].valor = 2;
                }
                else
                {
                    lista_pedidos[i].valor = 1;
                }
            }
        }

        public void Actualizacionfechas() //actualizo el valor de los pedidos a partir de la cantidad de horas que pasaron desde su compra
        {
            for (int i = 0; i < lista_pedidos.Count; i++)
            {
                if (DateTime.Today.Hour - lista_pedidos[i].fecha.Hour == 48 && lista_pedidos[i].prioridad == "normal")
                {
                    lista_pedidos[i].valor = 3;
                }
                if (DateTime.Today.Hour - lista_pedidos[i].fecha.Hour == 24 && lista_pedidos[i].prioridad == "normal")
                {
                    lista_pedidos[i].valor = 2;
                }
                if (DateTime.Today.Hour - lista_pedidos[i].fecha.Hour == 24 && lista_pedidos[i].prioridad == "diferido")
                {
                    lista_pedidos[i].valor = 1;
                }
                if (DateTime.Today.Hour - lista_pedidos[i].fecha.Hour == 48 && lista_pedidos[i].prioridad == "diferido")
                {
                    lista_pedidos[i].valor = 2;
                }
                if (DateTime.Today.Hour - lista_pedidos[i].fecha.Hour == 72 && lista_pedidos[i].prioridad == "diferido")
                {
                    lista_pedidos[i].valor = 3;
                }
            }
        }

        public void Llenado(Class_Vehiculo vehiculo)
        {
            Pedido pedido_aux;
            int i, j;
            float sumVol = 0;
            int newCantPedidos = 0;
            int sumPeso = 0;

            for (i = 0; i < lista_pedidos.Count - 1; i++)    //ordeno segun prioridad de mayor prioridad a menor
            {
                for (j = i + 1; j < lista_pedidos.Count; j++)
                    if (lista_pedidos[i].valor > lista_pedidos[j].valor)
                    {
                        pedido_aux = lista_pedidos[i];
                        lista_pedidos[i] = lista_pedidos[j];
                        lista_pedidos[j] = pedido_aux;
                    }
            }

            for (i = 0; i < lista_pedidos.Count; i++)   //me fijo en terminos de volumen cuantos pedidos entran
            {
                if (sumVol + lista_pedidos[i].volumen < vehiculo.Vol_Max && lista_pedidos[i].cargado == false)
                {
                    sumVol += lista_pedidos[i].volumen;
                    newCantPedidos++;
                }
            }

            int[,] matriz = new int[newCantPedidos + 1, vehiculo.Peso_Max + 1];

            for (i = 0; i <= newCantPedidos; i++)
            {
                for (j = 0; j <= vehiculo.Peso_Max; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        matriz[i, j] = 0;
                    }
                    else if (lista_pedidos[i - 1].peso <= j)
                    {
                        matriz[i, j] = Math.Max(lista_pedidos[i - 1].valor + matriz[i - 1, j - lista_pedidos[i - 1].peso],
                                                  matriz[i - 1, j]);
                        if (lista_pedidos[i - 1].valor + matriz[i - 1, j - lista_pedidos[i - 1].peso] > matriz[i - 1, j]
                            && lista_pedidos[i - 1].cargado == false
                            && sumPeso + lista_pedidos[i - 1].peso < vehiculo.Peso_Max)
                        {
                            vehiculo.Pedidos.Add(lista_pedidos[i - 1]);
                            lista_pedidos[i - 1].cargado = true;
                            sumPeso += lista_pedidos[i - 1].peso;
                        }
                    }
                    else
                    {
                        matriz[i, j] = matriz[i - 1, j];
                    }
                }
            }
            for (int k = 0; k < lista_pedidos.Count; k++)
            {
                if (lista_pedidos[k].cargado==true)
                    lista_pedidos.Remove(lista_pedidos [k]);
            }

            for (int k = 0; k < vehiculo.Pedidos.Count; k++)
            {
                Console.WriteLine("{0}", vehiculo.Pedidos[k].producto);
            }

            Console.WriteLine("LISTA EN ALMACEN");
            for (int k = 0; k < lista_pedidos.Count; k++)
            {
                Console.WriteLine("{0}",lista_pedidos[k].producto);
            }
        }
        
    }
}
